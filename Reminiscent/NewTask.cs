using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Reflection;

namespace Reminiscent
{
    public partial class NewTask : Form
    {
        public NewTask()
        {
            InitializeComponent();
        }
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        public static int iID1;
        public static int iID2;
        int iIDi = 0;
        int iIDj = 0;
        int iID = 0;
        int iPbig = 0;
        string strMode = "D";

        private void NewTask_Load(object sender, EventArgs e)
        {
            #region Theme
            XmlDocument xmlDocTheme = new XmlDocument();
            if (frmMain.strTheme == "Blue")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Blue.xml");
            }
            else if (frmMain.strTheme == "White")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-White.xml");
            }
            else if (frmMain.strTheme == "Simple")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Simple.xml");
            }

            foreach (XmlNode node in xmlDocTheme.SelectNodes("Theme/Style"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == frmMain.strTheme)
                {
                    this.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg5").InnerText)));
                    break;
                }
            }
            #endregion

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

            string strDetail = "";
            string strNew = "";
            string strEdit = "";

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    strDetail = frmMain.Decryption(node.SelectSingleNode("Detail").InnerText);
                    strNew = frmMain.Decryption(node.SelectSingleNode("New").InnerText);
                    strEdit = frmMain.Decryption(node.SelectSingleNode("Edit").InnerText);

                    lblTaskName.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblPPP.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblPA.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    lblDes.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    break;
                }
            }
            #endregion

            LoadInfo();

            strMode = NewSchedule.strMode;
            if (strMode == "D")
            {
                this.Text = strDetail;
                txtTaskName.ReadOnly = true;
                txtTaskDes.ReadOnly = true;
                nPPP.Enabled = false;
                nPA.Enabled = false;
                tlsTool.Enabled = false;
                btnOK.Hide();
                btnCancel.Location = new Point(this.Size.Width / 2 - btnCancel.Size.Width / 2, btnCancel.Location.Y);
            }
            else if (strMode == "N")
            {
                this.Text = strNew;
                txtTaskName.Text = "";
                txtTaskDes.Text = "";
                nPPP.Value = 0;
                nPA.Value = 0;
            }
            else if (strMode == "E")
            {
                this.Text = strEdit;
            }
        }

        void LoadInfo()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;
            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

            for (int i = 0; i < Tasks.Count; i++)
            {
                if (iID1 == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                {
                    iIDi = i;
                    if (Tasks[i].LastChild.Name == "ChildTask" && Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count > 0)
                    {
                        for (int j = 0; j < Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                        {
                            if (iID2 == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText)))
                            {
                                iIDj = j;
                                iID = iID2;
                                txtTaskName.Text = frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Name").InnerText);
                                nPPP.Value = Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText));
                                nPA.Value = Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Accomplished").InnerText));
                                //txtTaskDes.Text = Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Description").InnerText;
                                txtTaskDes.LoadFile("Schedule/" + iID1 + "-" + iID2 + ".rtf");
                                iPbig = Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText));
                            }
                        }
                    }
                }
            }
        }

        int CalculateMaxID()
        {
            int iIDmax = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;
            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
            if (Tasks[iIDi].LastChild.Name == "ChildTask")
                for (int j = 0; j < Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                {
                    if (iIDmax < Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText)))
                        iIDmax = Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText));
                }
            iIDmax++;
            return iIDmax;
        }

        int CalculatePercent()
        {
            int iPercent = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;
            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
            if (Tasks[iIDi].LastChild.Name == "ChildTask")
                for (int j = 0; j < Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                {
                    int ippp = Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText));
                    int ipa = Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Accomplished").InnerText));
                    iPercent += ipa * ippp / 100;
                }
            return iPercent;
        }

        int CalculatePercentperProject()
        {
            int ippp = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;
            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
            if(Tasks[iIDi].LastChild.Name == "ChildTask")
                for (int j = 0; j < Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                {
                    ippp += Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText));
                }
            return ippp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int iflagerror = 0;
            #region New
            if (strMode == "N")
            {
                if (txtTaskName.Text != "")
                {
                    if (CalculatePercentperProject() != 100)
                    {
                        if (CalculatePercentperProject() + nPPP.Value <= 100)
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load("Schedule.xml");
                            XmlElement parent = xmlDoc.DocumentElement;
                            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                            XmlNode nodeChildTask;
                            if (Tasks[iIDi].LastChild.Name != "ChildTask")
                            {
                                nodeChildTask = xmlDoc.CreateNode(XmlNodeType.Element, "ChildTask", null);
                                Tasks[iIDi].AppendChild(nodeChildTask);
                            }
                            else
                            {
                                nodeChildTask = Tasks[iIDi].SelectSingleNode("ChildTask");
                            }
                            XmlNode nodeTask = xmlDoc.CreateNode(XmlNodeType.Element, "Task", null);

                            XmlNode nodeID = xmlDoc.CreateElement("ID");
                            nodeID.InnerText = frmMain.Encryption(CalculateMaxID().ToString());

                            XmlNode nodeName = xmlDoc.CreateElement("Name");
                            nodeName.InnerText = frmMain.Encryption(txtTaskName.Text);

                            XmlNode nodePercent = xmlDoc.CreateElement("Percent");
                            nodePercent.InnerText = frmMain.Encryption(nPPP.Value.ToString());

                            XmlNode nodeAccomplished = xmlDoc.CreateElement("Accomplished");
                            nodeAccomplished.InnerText = frmMain.Encryption(nPA.Value.ToString());

                            XmlNode nodeDescription = xmlDoc.CreateElement("Description");
                            nodeDescription.InnerText = frmMain.Encryption(txtTaskDes.Text);

                            nodeTask.AppendChild(nodeID);
                            nodeTask.AppendChild(nodeName);
                            nodeTask.AppendChild(nodePercent);
                            nodeTask.AppendChild(nodeAccomplished);
                            nodeTask.AppendChild(nodeDescription);

                            nodeChildTask.AppendChild(nodeTask);

                            xmlDoc.Save("Schedule.xml");

                            txtTaskDes.SaveFile("Schedule/" + iIDi + "-" + CalculateMaxID() + ".rtf");
                        }
                        else
                        {
                            iflagerror = 1;
                            MessageBox.Show("Please set percent per project of new task lower than " + (100 - CalculatePercentperProject()) + "%", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        iflagerror = 1;
                        MessageBox.Show("You can't add task anymore!\r\nPlease delete or reduce percent per project of other task", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    iflagerror = 1;
                    MessageBox.Show("You can't leave Task Name empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion

            #region Edit
            else if (strMode == "E")
            {
                if (txtTaskName.Text != "")
                {
                    if (CalculatePercentperProject() - iPbig + nPPP.Value <= 100)
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("Schedule.xml");
                        XmlElement parent = xmlDoc.DocumentElement;
                        XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                        Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[iIDj].SelectSingleNode("Name").InnerText = frmMain.Encryption(txtTaskName.Text);
                        Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[iIDj].SelectSingleNode("Percent").InnerText = frmMain.Encryption(nPPP.Value.ToString());
                        Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[iIDj].SelectSingleNode("Accomplished").InnerText = frmMain.Encryption(nPA.Value.ToString());
                        Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[iIDj].SelectSingleNode("Description").InnerText = frmMain.Encryption(txtTaskDes.Text);
                        xmlDoc.Save("Schedule.xml");

                        string streID1 = frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ID").InnerText);
                        string streID2 = frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[iIDj].SelectSingleNode("ID").InnerText);
                        txtTaskDes.SaveFile("Schedule/" + streID1 + "-" + streID2 + ".rtf");
                    }
                    else
                    {
                        iflagerror = 1;
                        MessageBox.Show("Please set percent per project of edit task lower than " + (100 - (CalculatePercentperProject() - iPbig)) + "%", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    iflagerror = 1;
                    MessageBox.Show("You can't leave Task Name empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion

            if(iflagerror == 0)
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region CharStyle
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (txtTaskDes.SelectionCharStyle.Bold == true)
            {
                btnBold.Checked = false;
                ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                cs.Bold = false;
                txtTaskDes.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                btnBold.Checked = true;
                ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                cs.Bold = true;
                txtTaskDes.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaskDes.SelectionCharStyle.Italic == true)
                {
                    btnItalic.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Italic = false;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnItalic.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Italic = true;
                    txtTaskDes.SelectionCharStyle = cs;
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
                if (txtTaskDes.SelectionCharStyle.Underline == true)
                {
                    btnUnderline.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Underline = false;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnUnderline.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Underline = true;
                    txtTaskDes.SelectionCharStyle = cs;
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
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            btnAlignLeft.Checked = true;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = false;
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = true;
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = true;
            btnAlignCenter.Checked = false;
        }
        #endregion

        private void txtTaskDes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Aglin
                if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                else if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = true;
                    btnAlignRight.Checked = false;
                }
                else if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
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
                    btnBold.Checked = txtTaskDes.SelectionCharStyle.Bold;
                }
                else
                {
                    btnBold.Enabled = false;
                    btnBold.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    btnItalic.Enabled = true;
                    btnItalic.Checked = txtTaskDes.SelectionCharStyle.Italic;
                }
                else
                {
                    btnItalic.Enabled = false;
                    btnItalic.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                {
                    btnUnderline.Enabled = true;
                    btnUnderline.Checked = txtTaskDes.SelectionCharStyle.Underline;
                }
                else
                {
                    btnUnderline.Enabled = false;
                    btnUnderline.Checked = false;
                }

                ff.Dispose();
                #endregion

                //txtTaskDes.UpdateObjects();
            }
            catch (Exception)
            { }
        }

        private void txtTaskDes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void txtTaskDes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (txtTaskDes.SelectionType == RichTextBoxSelectionTypes.Object ||
                    txtTaskDes.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(txtTaskDes.SelectedObject().sizel.Width));
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

                if (txtTaskDes.CanPaste(FormatPic)) //Nếu có thể chèn vào RTBox
                {
                    txtTaskDes.Paste(FormatPic); //Chèn hình vào
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
                txtTaskDes.SelectionColor = GetColor(txtTaskDes.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnHighLightColor_Click(object sender, EventArgs e)
        {
            try
            {
                txtTaskDes.SelectionBackColor = GetColor(txtTaskDes.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtTaskDes.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            txtTaskDes.Redo();
        }

        private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboFontSize.Focused) return;
                txtTaskDes.SelectionFont = new Font(txtTaskDes.Font.Name, Convert.ToInt32(cboFontSize.Text), txtTaskDes.SelectionFont.Style);
            }
            catch (Exception)
            {
            }
        }

        private void cboFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    txtTaskDes.SelectionFont = new Font(txtTaskDes.Font.Name, Convert.ToInt32(cboFontSize.Text));
                    txtTaskDes.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
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
        #endregion

        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
    }
}
