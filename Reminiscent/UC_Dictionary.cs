using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace Reminiscent
{
    public partial class UC_Dictionary : UserControl
    {
        public UC_Dictionary()
        {
            InitializeComponent();
        }

        int iFlag = 0;
        int iTemp = 0;

        private void UC_Dictionary_Load(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            cboSize.Text = "8";
            rtxShow.Text = "";
            cbxDictionary.Text = "English";

            //edit
            rtxShow.Select(0, 0);
            //rtxShow.AppendText("some text");
            rtxShow.Select(0, 0);
            rtxShow.Clear();
            rtxShow.SetLayoutType(ExtendedRichTextBox.LayoutModes.WYSIWYG);

            rtxShow.ReadOnly = true;

            #region Language
            XmlDocument xmlDocLng = new XmlDocument();
            if (frmMain.strLanguage == "English")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-English.xml");
            }
            else if (frmMain.strLanguage == "Vietnamese")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-Vietnamese.xml");
            }

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    label2.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblKeyWord.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    label1.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);

                    btnNew.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnEdit.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnDelete.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnSave.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    break;
                }
            }
            #endregion
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtKeyword.Focus();

            btnNew.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            rtxShow.ReadOnly = false;
            rtxShow.Text = "";
            txtKeyword.Text = "";

            iFlag = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKeyword.Text.Trim() != "" && rtxShow.Text.Trim() != "")
            {
                int iError = 0;

                if (iFlag == 1) // New
                {
                    #region Xử lý nút New

                    string strFolder = Application.StartupPath + "/Data/Dictionary//" + cbxDictionary.Text;

                    bool isExists = System.IO.Directory.Exists(strFolder);

                    if (!isExists)
                        System.IO.Directory.CreateDirectory(strFolder);

                    string strTemp = strFolder + "//" + txtKeyword.Text.Substring(0, 1).ToLower() + ".xml";

                    if (!File.Exists(strTemp)) // Chưa tồn tại tập tin xml
                    {
                        XmlTextWriter writer = new XmlTextWriter(strTemp, Encoding.UTF8);
                        writer.Formatting = Formatting.Indented; //Xuống dòng
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Dictionary");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.Load(strTemp);

                    XmlElement ele = doc.DocumentElement;
                    XmlNodeList WordList = ele.GetElementsByTagName("WordList");

                    string s = "";

                    if (WordList.Count < 1) // Chưa tồn tại từ nào
                    {
                        XmlNode nodeWordList = doc.CreateNode(XmlNodeType.Element, "WordList", null);

                        XmlNode nodeID = doc.CreateElement("ID");

                        nodeID.InnerText = frmMain.Encryption("0");

                        XmlNode nodeKeyWord = doc.CreateElement("KeyWord");
                        nodeKeyWord.InnerText = frmMain.Encryption(txtKeyword.Text.ToLower());

                        rtxShow.SaveFile("temp.rtf", RichTextBoxStreamType.RichText);

                        StreamReader sr = new StreamReader("temp.rtf", Encoding.Default); // Mở file rtf

                        s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                        sr.Close();

                        XmlNode nodeDes = doc.CreateElement("Description");
                        nodeDes.InnerText = frmMain.Encryption(s);

                        nodeWordList.AppendChild(nodeID);
                        nodeWordList.AppendChild(nodeKeyWord);
                        nodeWordList.AppendChild(nodeDes);

                        doc.DocumentElement.AppendChild(nodeWordList);
                    }
                    else
                    { 
                        int iDup = 0;

                        for (int i = 0; i < WordList.Count; i++)
                        {
                            if (frmMain.Decryption(WordList[i].ChildNodes[1].InnerText) == txtKeyword.Text && frmMain.Decryption(WordList[i].ChildNodes[2].InnerText) == s)
                            {
                                iDup = 1;
                                iError = 1;
                                MessageBox.Show("Keyword already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }

                        if (iDup == 0) // Không trùng từ khóa
                        {
                            XmlNode nodeWordList = doc.CreateNode(XmlNodeType.Element, "WordList", null);

                            XmlNode nodeID = doc.CreateElement("ID");

                            int iMax = 0;

                            if (WordList.Count < 1)
                            {
                                nodeID.InnerText = frmMain.Encryption("0");
                            }
                            else
                            {
                                for (int i = 0; i < WordList.Count; i++)
                                {
                                    if (iMax < int.Parse(frmMain.Decryption(WordList[i].ChildNodes[0].InnerText)))
                                        iMax = int.Parse(frmMain.Decryption(WordList[i].ChildNodes[0].InnerText));
                                }

                                nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                            }

                            XmlNode nodeKeyWord = doc.CreateElement("KeyWord");
                            nodeKeyWord.InnerText = frmMain.Encryption(txtKeyword.Text.ToLower());

                            rtxShow.SaveFile("temp.rtf", RichTextBoxStreamType.RichText);

                            StreamReader sr = new StreamReader("temp.rtf", Encoding.Default); // Mở file rtf

                            s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                            sr.Close();

                            XmlNode nodeDes = doc.CreateElement("Description");
                            nodeDes.InnerText = frmMain.Encryption(s);

                            nodeWordList.AppendChild(nodeID);
                            nodeWordList.AppendChild(nodeKeyWord);
                            nodeWordList.AppendChild(nodeDes);

                            doc.DocumentElement.AppendChild(nodeWordList);
                        }
                    }

                    if (iError == 0)
                    {
                        doc.Save(strTemp);
                    }

                    #endregion
                }
                else
                    if (iFlag == 2) // Edit
                    {
                        #region Xử lý nút Edit

                        if (lvwDE.SelectedItems.Count > 0)
                        {
                            string s = Application.StartupPath + "/Data/Dictionary//" + cbxDictionary.Text + "//" + lvwDE.SelectedItems[0].Text.Substring(0, 1).ToLower() + ".xml";

                            XmlDocument doc = new XmlDocument();
                            doc.Load(s);

                            XmlElement ele = doc.DocumentElement;
                            XmlNodeList WordList = ele.GetElementsByTagName("WordList");

                            for (int i = 0; i < WordList.Count; i++)
                            {
                                if (lvwDE.SelectedItems[0].Tag.ToString() == frmMain.Decryption(WordList[i].ChildNodes[0].InnerText.ToString()))
                                {
                                    WordList[i].ChildNodes[1].InnerText = frmMain.Encryption(txtKeyword.Text);

                                    rtxShow.SaveFile("temp.rtf", RichTextBoxStreamType.RichText);

                                    StreamReader sr = new StreamReader("temp.rtf", Encoding.Default); // Mở file rtf

                                    string str = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                    sr.Close();

                                    WordList[i].ChildNodes[2].InnerText = frmMain.Encryption(str);

                                    break;
                                }
                            }

                            doc.Save(s);
                        }

                        #endregion
                    }

                if (iError == 0)
                {
                    iFlag = 0;

                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;

                    txtKeyword.Text = "";
                    rtxShow.ReadOnly = true;
                }
                else
                {
                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    btnEdit.Enabled = false;
                }

                cbxDictionary_SelectedIndexChanged(sender, e);

            }
            else
                MessageBox.Show("Keyword or description emply.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnEdit.Enabled = false;

            rtxShow.ReadOnly = true;

            if (lvwDE.SelectedItems.Count > 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to delete '" + lvwDE.SelectedItems[0].Text + "' ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    string s = Application.StartupPath + "/Data/Dictionary//" + cbxDictionary.Text + "//" + lvwDE.SelectedItems[0].Text.Substring(0, 1).ToLower() + ".xml";

                    XmlDocument doc = new XmlDocument();
                    doc.Load(s);

                    XmlElement ele = doc.DocumentElement;
                    XmlNodeList WordList = ele.GetElementsByTagName("WordList");

                    for (int i = 0; i < WordList.Count; i++)
                    {
                        if (lvwDE.SelectedItems[0].Tag.ToString() == frmMain.Decryption(WordList[i].ChildNodes[0].InnerText.ToString()))
                        {
                            WordList[i].ParentNode.RemoveChild(WordList[i]);

                            doc.Save(s);

                            cbxDictionary_SelectedIndexChanged(sender, e);

                            break;
                        }
                    }
                }
                else
                {
                    btnNew.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = lvwDE.SelectedItems[0].Text;

            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            rtxShow.ReadOnly = false;

            iFlag = 2;
        }

        #region RichText

        private Color GetColor(Color initColor)
        {
            using (ColorDialog dlgColor = new ColorDialog())
            {
                dlgColor.Color = initColor;
                dlgColor.AllowFullOpen = true;
                dlgColor.AnyColor = true;
                dlgColor.FullOpen = true;
                dlgColor.ShowHelp = false;
                dlgColor.SolidColorOnly = false;
                if (dlgColor.ShowDialog() == DialogResult.OK)
                {
                    return dlgColor.Color;
                }
                else
                {
                    return initColor;
                }
            }
        }
        private Font GetFont(Font initFont)
        {
            using (FontDialog dlgFont = new FontDialog())
            {
                dlgFont.Font = initFont;
                dlgFont.AllowSimulations = true;
                dlgFont.AllowVectorFonts = true;
                dlgFont.AllowVerticalFonts = true;
                dlgFont.FontMustExist = true;
                dlgFont.ShowHelp = false;
                dlgFont.ShowEffects = true;
                dlgFont.ShowColor = false;
                dlgFont.ShowApply = false;
                dlgFont.FixedPitchOnly = false;

                if (dlgFont.ShowDialog() == DialogResult.OK)
                {
                    return dlgFont.Font;
                }
                else
                {
                    return initFont;
                }
            }
        }
        private string GetImagePath()
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Multiselect = false;
            dlgOpen.ShowReadOnly = false;
            dlgOpen.RestoreDirectory = true;
            dlgOpen.ReadOnlyChecked = false;
            dlgOpen.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                return dlgOpen.FileName;
            }
            else
            {
                return "";
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            rtxShow.Paste();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            rtxShow.Copy();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            rtxShow.Cut();
        }

        #region CharStyle
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtxShow.SelectionCharStyle.Bold == true)
            {
                btnBold.Checked = false;
                ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                cs.Bold = false;
                rtxShow.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                btnBold.Checked = true;
                ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                cs.Bold = true;
                rtxShow.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtxShow.SelectionCharStyle.Italic == true)
                {
                    btnItalic.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Italic = false;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnItalic.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Italic = true;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtxShow.SelectionCharStyle.Underline == true)
                {
                    btnUnderline.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Underline = false;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnUnderline.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Underline = true;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Align
        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            btnAlignLeft.Checked = true;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = false;
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = true;
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = true;
            btnAlignCenter.Checked = false;
        }
        #endregion

        private void rtxShow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Aglin
                if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                else if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = true;
                    btnAlignRight.Checked = false;
                }
                else if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = true;
                }
                else
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                #endregion

                #region Font
                FontFamily ff = new FontFamily("Tahoma");
                if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                {
                    btnBold.Enabled = true;
                    btnBold.Checked = rtxShow.SelectionCharStyle.Bold;
                }
                else
                {
                    btnBold.Enabled = false;
                    btnBold.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    btnItalic.Enabled = true;
                    btnItalic.Checked = rtxShow.SelectionCharStyle.Italic;
                }
                else
                {
                    btnItalic.Enabled = false;
                    btnItalic.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                {
                    btnUnderline.Enabled = true;
                    btnUnderline.Checked = rtxShow.SelectionCharStyle.Underline;
                }
                else
                {
                    btnUnderline.Enabled = false;
                    btnUnderline.Checked = false;
                }

                ff.Dispose();
                #endregion

                rtxShow.UpdateObjects();
            }
            catch (Exception)
            { }
        }

        private void rtxShow_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void rtxShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (rtxShow.SelectionType == RichTextBoxSelectionTypes.Object ||
                    rtxShow.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(rtxShow.SelectedObject().sizel.Width));
                }
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            try
            {
                string imgPath = GetImagePath(); //Lấy đường dẫn file ảnh

                Bitmap BitmapPic = new Bitmap(imgPath); //Tạo một Bitmap ><

                Clipboard.SetDataObject(BitmapPic); //Đặt đối tượng dử liệu vào Clipboard

                DataFormats.Format FormatPic = DataFormats.GetFormat(DataFormats.Bitmap);//Lấy định dạng của hình

                if (rtxShow.CanPaste(FormatPic)) //Nếu có thể chèn vào RTBox
                {
                    rtxShow.Paste(FormatPic); //Chèn hình vào
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                rtxShow.SelectionColor = GetColor(rtxShow.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnHighLightColor_Click(object sender, EventArgs e)
        {
            try
            {
                rtxShow.SelectionBackColor = GetColor(rtxShow.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void mnuConvert_Click(object sender, EventArgs e)
        {
            rtxShow.Text = rtxShow.Rtf;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            rtxShow.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            rtxShow.Redo();
        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboSize.Focused) return;
                rtxShow.SelectionFont = new Font(rtxShow.Font.Name, Convert.ToInt32(cboSize.Text), rtxShow.SelectionFont.Style);
            }
            catch (Exception)
            {

            }
        }

        private void cboSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    rtxShow.SelectionFont = new Font("Tahoma", Convert.ToInt32(cboSize.Text));
                    rtxShow.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        private void cboSize_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                    e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                    e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                    e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
                    e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                    e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
                    e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
                    e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete)
                {
                    //allow key
                }
                else
                {
                    e.SuppressKeyPress = true;
                }
            }
            catch(Exception) 
            { }
        }
        #endregion

        private void cbxDictionary_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtxShow.Text = "";
            lvwDE.Items.Clear();

            string strFolder = Application.StartupPath + "/Data/Dictionary//" + cbxDictionary.Text;

            bool isExists = System.IO.Directory.Exists(strFolder);

            if (!isExists)
                System.IO.Directory.CreateDirectory(strFolder);

            FolderBrowserDialog fd = new FolderBrowserDialog();

            string[] files = Directory.GetFiles(strFolder)
                              .Where(p => p.EndsWith(".xml"))
                              .ToArray();

            foreach (var path in files)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlElement ele = doc.DocumentElement;
                XmlNodeList WordList = ele.GetElementsByTagName("WordList");

                for (int j = 0; j < WordList.Count; j++)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.Tag = frmMain.Decryption(WordList[j].ChildNodes[0].InnerText); // ID
                    lvi.Text = frmMain.Decryption(WordList[j].ChildNodes[1].InnerText); // Keyword

                    lvwDE.Items.Add(lvi);
                }
            }

            //if (cbxDictionary.Text == "English")
            //{
            //    for (int i = 97; i < 123; i++) // 97 = a -> 122 = z
            //    {
            //        string temp = strFolder + "//" + Convert.ToChar(i) + ".xml";
            //        if (File.Exists(temp))
            //        {
            //            XmlDocument doc = new XmlDocument();
            //            doc.Load(temp);

            //            XmlElement ele = doc.DocumentElement;
            //            XmlNodeList WordList = ele.GetElementsByTagName("WordList");

            //            for (int j = 0; j < WordList.Count; j++)
            //            {
            //                ListViewItem lvi = new ListViewItem();

            //                lvi.Tag = WordList[j].ChildNodes[0].InnerText; // ID
            //                lvi.Text = WordList[j].ChildNodes[1].InnerText; // Keyword

            //                lvwDE.Items.Add(lvi);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    for (int i = 97; i < 123; i++)
            //    {
            //        string temp = Convert.ToChar(i) + "_Vietnamese.xml";

            //        if (File.Exists(temp))
            //        {
            //            XmlDocument doc = new XmlDocument();
            //            doc.Load(temp);

            //            XmlElement ele = doc.DocumentElement;
            //            XmlNodeList WordList = ele.GetElementsByTagName("WordList");

            //            for (int j = 0; j < WordList.Count; j++)
            //            {
            //                ListViewItem lvi = new ListViewItem();

            //                lvi.Tag = WordList[j].ChildNodes[0].InnerText; // ID
            //                lvi.Text = WordList[j].ChildNodes[1].InnerText; // Keyword

            //                lvwDE.Items.Add(lvi);
            //            }
            //        }
            //    }
            //}
        }

        private void lvwDE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwDE.SelectedItems.Count > 0)
            {
                iFlag = 0;

                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = false;
                rtxShow.ReadOnly = true;

                string strTemp = Application.StartupPath + "/Data/Dictionary//" + cbxDictionary.Text + "//" + lvwDE.SelectedItems[0].Text.Substring(0, 1).ToLower() + ".xml";

                XmlDocument doc = new XmlDocument();
                doc.Load(strTemp);

                XmlElement ele = doc.DocumentElement;
                XmlNodeList WordList = ele.GetElementsByTagName("WordList");

                for (int i = 0; i < WordList.Count; i++)
                {
                    if (frmMain.Decryption(WordList[i].ChildNodes[0].InnerText) == lvwDE.SelectedItems[0].Tag.ToString())
                    {
                        StreamWriter sw = new StreamWriter("temp.rtf");
                        sw.Write(frmMain.Decryption(WordList[i].ChildNodes[2].InnerText));
                        sw.Close();
                        try
                        {
                            rtxShow.LoadFile("temp.rtf");
                        }
                        catch
                        {
                            MessageBox.Show("Description is corrupted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else // Không có từ nào được chọn
            {
                iFlag = 0;

                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnNew.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            if (lvwDE.Items.Count > 0)
            {
                if (iFlag != 1 && iFlag != 2)
                {
                    if (txtKeyword.Text != " " && txtKeyword.Text != "")
                    {
                        for (int i = 0; i < lvwDE.Items.Count; i++)
                        {
                            if (lvwDE.Items[i].Text.Contains(txtKeyword.Text))
                            {
                                lvwDE.Items[i].Selected = true;
                                lvwDE.Items[i].BackColor = SystemColors.Highlight;
                                if (i != iTemp)
                                {
                                    lvwDE.Items[iTemp].BackColor = Color.White;
                                    iTemp = i;
                                }
                            }
                            else
                            {
                                lvwDE.Items[i].Selected = false;
                            }
                        }
                    }
                    else
                        lvwDE.Items[iTemp].BackColor = Color.White;
                }
            }
        }

        private void lvwDE_MouseClick(object sender, MouseEventArgs e)
        {
            lvwDE.Items[iTemp].BackColor = Color.White;
        }
    }
}
