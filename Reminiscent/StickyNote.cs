using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;//DllImportAttribute
using System.Xml;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace Reminiscent
{
    public partial class frmStickyNote : Form
    {
        string strDTNow = "";
        private string strTextNote = "";
        private string strOnTop = "No";
        private string strColor = "Yellow";
        private int iID = 0;
        private int iSizeX = 300;
        private int iSizeY = 500;
        private int iLocationX = 0;
        private int iLocationY = 0;
        XmlDocument doc = new XmlDocument();
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        #region Moveable with Panel\\
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public frmStickyNote()
        {
            InitializeComponent();
        }

        #region Remove Title and Control Box\\
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x00C00000; //WS_CAPTION;  
                cp.ClassStyle |= 0x00020000; //CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        #region Moveable with Panel\\
        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region DateTimeNow
        void DateTimeNow()
        {
            strDTNow = "";
            if (DateTime.Now.Day < 10)
            {
                strDTNow += "0" + DateTime.Now.Day + "/";
            }
            else
            {
                strDTNow += DateTime.Now.Day + "/";
            }

            if (DateTime.Now.Month < 10)
            {
                strDTNow += "0" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            }
            else
            {
                strDTNow += DateTime.Now.Month + "/" + DateTime.Now.Year;
            }
        }
        #endregion

        #region Page Load\\
        private void StickyNote_Load(object sender, EventArgs e)
        {
            DateTimeNow();
            strTextNote = classShowSticky.strTextNote;
            strOnTop = classShowSticky.strOnTop;
            strColor = classShowSticky.strColor;
            iID = classShowSticky.iID;
            iSizeX = classShowSticky.iSizeX;
            iSizeY = classShowSticky.iSizeY;
            iLocationX = classShowSticky.iLocationX;
            iLocationY = classShowSticky.iLocationY;

            //this.FormBorderStyle = FormBorderStyle.None;
            //this.ControlBox = false;
            this.BackColor = Color.FromArgb(248, 247, 182);
            this.Location = new Point(iLocationX, iLocationY);
            this.Size = new Size(iSizeX, iSizeY);

            txtNote.Text = strTextNote;

            if (strColor == "Blue")
                blueToolStripMenuItem_Click(sender, e);

            if (strColor == "Pink")
                pinkToolStripMenuItem_Click(sender, e);

            if (strColor == "Green")
                greenToolStripMenuItem_Click(sender, e);

            if (strColor == "Purple")
                purpleToolStripMenuItem_Click(sender, e);

            if (strColor == "White")
                whiteToolStripMenuItem_Click(sender, e);

            if (strColor == "Yellow")
                yellowToolStripMenuItem_Click(sender, e);

            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;

            pasteToolStripMenuItem.Enabled = true;
            //Timer.Start();

            if (strOnTop == "Yes")
            {
                onTopToolStripMenuItem.Checked = true;
                this.TopMost = true;
            }

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
                if (node.SelectSingleNode("Name").InnerText == this.Name)
                {
                    this.Text = node.SelectSingleNode("Text").InnerText;

                    cutToolStripMenuItem.Text = node.SelectSingleNode("item1").InnerText;
                    copyToolStripMenuItem.Text = node.SelectSingleNode("item2").InnerText;
                    pasteToolStripMenuItem.Text = node.SelectSingleNode("item3").InnerText;
                    deleteToolStripMenuItem.Text = node.SelectSingleNode("item4").InnerText;

                    selectAllToolStripMenuItem.Text = node.SelectSingleNode("item5").InnerText;

                    blueToolStripMenuItem.Text = node.SelectSingleNode("item6").InnerText;
                    pinkToolStripMenuItem.Text = node.SelectSingleNode("item7").InnerText;
                    greenToolStripMenuItem.Text = node.SelectSingleNode("item8").InnerText;
                    purpleToolStripMenuItem.Text = node.SelectSingleNode("item9").InnerText;
                    whiteToolStripMenuItem.Text = node.SelectSingleNode("item10").InnerText;
                    yellowToolStripMenuItem.Text = node.SelectSingleNode("item11").InnerText;

                    newToolStripMenuItem.Text = node.SelectSingleNode("item12").InnerText;
                    onTopToolStripMenuItem.Text = node.SelectSingleNode("item13").InnerText;
                    exitToolStripMenuItem.Text = node.SelectSingleNode("item14").InnerText;
                    break;
                }
            }
            #endregion
        }
        #endregion

        #region Set hotkey to button\\
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control|Keys.N))
            {
                btnNew.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.D))
            {
                btnClose.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.T))
            {
                onTopToolStripMenuItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.X))
            {
                cutToolStripMenuItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.C))
            {
                copyToolStripMenuItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.V))
            {
                pasteToolStripMenuItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Control | Keys.A))
            {
                selectAllToolStripMenuItem.PerformClick();
                return true;
            }

            if (keyData == (Keys.Delete))
            {
                deleteToolStripMenuItem.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        #region Title Button\\
        #region New
        private void btnNew_Click(object sender, EventArgs e)
        {
            XmlDocument xd = new XmlDocument();
            //Load StickyNote.xml
            xd.Load(Application.StartupPath + "/Data/StickyNote.xml");
            int iMax = 0;
            //Search in Root/Node
            foreach (XmlNode node in xd.SelectNodes("Sticky/Notes"))
            {
                if (iMax < Convert.ToInt32(node.SelectSingleNode("ID").InnerText))
                {
                    iMax = Convert.ToInt32(node.SelectSingleNode("ID").InnerText);
                }
            }
            iMax++;
            classShowSticky.iID = iMax;


            frmStickyNote sn = new frmStickyNote();
            classShowSticky.strTextNote = "";
            classShowSticky.iLocationX = this.Location.X + 10;
            classShowSticky.iLocationY = this.Location.Y + 10;
            classShowSticky.iSizeX = this.Size.Width;
            classShowSticky.iSizeY = this.Size.Height;
            classShowSticky.strColor = strColor;
            classShowSticky.strOnTop = strOnTop;

            #region New
            DateTimeNow();
            XmlNode nodeNotes = xd.CreateNode(XmlNodeType.Element, "Notes", null);

            XmlNode nodeID = xd.CreateElement("ID");
            nodeID.InnerText = classShowSticky.iID.ToString();

            XmlNode nodeDate = xd.CreateElement("Date");
            nodeDate.InnerText = strDTNow;

            XmlNode nodeNote = xd.CreateElement("Text");
            nodeNote.InnerText = classShowSticky.strTextNote;

            XmlNode nodeWidth = xd.CreateElement("Width");
            nodeWidth.InnerText = classShowSticky.iSizeX.ToString();

            XmlNode nodeHeight = xd.CreateElement("Height");
            nodeHeight.InnerText = classShowSticky.iSizeY.ToString();

            XmlNode nodeLocationX = xd.CreateElement("LocationX");
            nodeLocationX.InnerText = classShowSticky.iLocationX.ToString();

            XmlNode nodeLocationY = xd.CreateElement("LocationY");
            nodeLocationY.InnerText = classShowSticky.iLocationY.ToString();

            XmlNode nodeColor = xd.CreateElement("Color");
            nodeColor.InnerText = classShowSticky.strColor;

            XmlNode nodeOnTop = xd.CreateElement("OnTop");
            nodeOnTop.InnerText = classShowSticky.strOnTop;

            XmlNode nodeShow = xd.CreateElement("Show");
            nodeShow.InnerText = "Yes";

            nodeNotes.AppendChild(nodeID);
            nodeNotes.AppendChild(nodeDate);
            nodeNotes.AppendChild(nodeNote);
            nodeNotes.AppendChild(nodeWidth);
            nodeNotes.AppendChild(nodeHeight);
            nodeNotes.AppendChild(nodeLocationX);
            nodeNotes.AppendChild(nodeLocationY);
            nodeNotes.AppendChild(nodeColor);
            nodeNotes.AppendChild(nodeOnTop);
            nodeNotes.AppendChild(nodeShow);

            xd.DocumentElement.AppendChild(nodeNotes);

            xd.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();
            #endregion

            sn.Show();
            frmMain.strRefeshUC = "Yes";
        }
        #endregion

        #region Delete
        private void btnClose_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Trim();
            DialogResult drDeleteNote = new DialogResult();
            drDeleteNote = MessageBox.Show("Delete Note\r\nAre you sure you want to delete this note?","Sticky Notes", MessageBoxButtons.YesNo);
            if (drDeleteNote == DialogResult.Yes)
            {
                if (File.Exists(Application.StartupPath + "/Data/StickyNote.xml"))
                {
                    doc.Load(Application.StartupPath + "/Data/StickyNote.xml");

                    foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
                    {
                        if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                        {
                            if (txtNote.Text == "")
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                            else
                            {
                                node.SelectSingleNode("Show").InnerText = "No";
                            }
                        }
                    }
                    doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
                    frmMain.Upload();
                }
                frmMain.strRefeshUC = "Yes";
                this.Close();
            }
        }
        #endregion
        #endregion

        #region Mouse hover
        private void frmStickyNote_Activated(object sender, EventArgs e)
        {
            TitlePanel.MouseMove -= new MouseEventHandler(TitlePanel_MouseMove);
            TitlePanel.MouseLeave -= new EventHandler(TitlePanel_MouseLeave);
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.New.png"));
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
        }

        private void frmStickyNote_Deactivate(object sender, EventArgs e)
        {
            TitlePanel.MouseMove += new MouseEventHandler(TitlePanel_MouseMove);
            TitlePanel.MouseLeave += new EventHandler(TitlePanel_MouseLeave);
            btnNew.Image = null;
            btnClose.Image = null;
        }

        private void TitlePanel_MouseMove(object sender, MouseEventArgs e)
        {
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.New.png"));
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
        }

        private void btnNew_MouseMove(object sender, MouseEventArgs e)
        {
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.NewHover.png"));
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
        }

        private void btnClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Closehover.png"));
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.New.png"));
        }

        //Leave
        private void TitlePanel_MouseLeave(object sender, EventArgs e)
        {
            btnNew.Image = null;
            btnClose.Image = null;
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.New.png"));
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.New.png"));
        }

        //Down
        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.CloseClick.png"));
        }

        private void btnNew_MouseDown(object sender, MouseEventArgs e)
        {
            btnNew.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.NewClick.png"));

            //Show Resource name
            //string[] names = myAssembly.GetManifestResourceNames();
            //foreach (string name in names)
            //{
            //    MessageBox.Show(name);
            //}
        }
        #endregion

        #region Menu tool\\
        #region New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNew_Click(sender, e);
        }
        #endregion

        #region Delete
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }
        #endregion

        #region On Top
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTimeNow();
            if (onTopToolStripMenuItem.Checked == true)
            {
                this.TopMost = true;
                strOnTop = "Yes";
            }
            else
            {
                this.TopMost = false;
                strOnTop = "No";
            }

            //Load StickyNote.xml
            doc.Load(Application.StartupPath + "/Data/StickyNote.xml");
            //Search in Root/Node
            foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
            {
                if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                {
                    node.SelectSingleNode("Date").InnerText = strDTNow;
                    node.SelectSingleNode("OnTop").InnerText = strOnTop;
                }
            }
            //Save XML
            doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            frmMain.strRefeshUC = "Yes";
        }
        #endregion

        #region Blue
        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "Blue";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(201, 236, 248);

            btnNew.BackColor = Color.FromArgb(201, 236, 248);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(201, 236, 248);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(201, 236, 248);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(201, 236, 248);

            btnClose.BackColor = Color.FromArgb(201, 236, 248);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(201, 236, 248);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(201, 236, 248);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(201, 236, 248);

            NotePanel.BackColor = Color.FromArgb(184, 219, 244);
            txtNote.BackColor = Color.FromArgb(184, 219, 244);
            PanelBottom.BackColor = Color.FromArgb(184, 219, 244);
            lblSize.BackColor = Color.FromArgb(184, 219, 244);
        }
        #endregion

        #region Pink
        private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "Pink";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(241, 195, 241);

            btnNew.BackColor = Color.FromArgb(241, 195, 241);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 195, 241);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 195, 241);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(241, 195, 241);

            btnClose.BackColor = Color.FromArgb(241, 195, 241);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 195, 241);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 195, 241);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(241, 195, 241);

            NotePanel.BackColor = Color.FromArgb(235, 174, 235);
            txtNote.BackColor = Color.FromArgb(235, 174, 235);
            PanelBottom.BackColor = Color.FromArgb(235, 174, 235);
            lblSize.BackColor = Color.FromArgb(235, 174, 235);
        }
        #endregion

        #region Green
        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "Green";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(197, 247, 193);

            btnNew.BackColor = Color.FromArgb(197, 247, 193);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 247, 193);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(197, 247, 193);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(197, 247, 193);

            btnClose.BackColor = Color.FromArgb(197, 247, 193);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(197, 247, 193);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(197, 247, 193);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(197, 247, 193);

            NotePanel.BackColor = Color.FromArgb(177, 232, 174);
            txtNote.BackColor = Color.FromArgb(177, 232, 174);
            PanelBottom.BackColor = Color.FromArgb(177, 232, 174);
            lblSize.BackColor = Color.FromArgb(177, 232, 174);
        }
        #endregion

        #region Purple
        private void purpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "Purple";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(212, 205, 243);

            btnNew.BackColor = Color.FromArgb(212, 205, 243);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(212, 205, 243);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 205, 243);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(212, 205, 243);

            btnClose.BackColor = Color.FromArgb(212, 205, 243);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(212, 205, 243);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 205, 243);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(212, 205, 243);

            NotePanel.BackColor = Color.FromArgb(205, 195, 255);
            txtNote.BackColor = Color.FromArgb(205, 195, 255);
            PanelBottom.BackColor = Color.FromArgb(205, 195, 255);
            lblSize.BackColor = Color.FromArgb(205, 195, 255);
        }
        #endregion

        #region White
        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "White";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(245, 245, 245);

            btnNew.BackColor = Color.FromArgb(245, 245, 245);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 245, 245);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(245, 245, 245);

            btnClose.BackColor = Color.FromArgb(245, 245, 245);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 245, 245);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(245, 245, 245);

            NotePanel.BackColor = Color.FromArgb(240, 240, 240);
            txtNote.BackColor = Color.FromArgb(240, 240, 240);
            PanelBottom.BackColor = Color.FromArgb(240, 240, 240);
            lblSize.BackColor = Color.FromArgb(240, 240, 240);
        }
        #endregion

        #region Yellow
        private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            strColor = "Yellow";
            ColorChange();
            TitlePanel.BackColor = Color.FromArgb(248, 247, 182);

            btnNew.BackColor = Color.FromArgb(248, 247, 182);
            btnNew.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 247, 182);
            btnNew.FlatAppearance.MouseDownBackColor = Color.FromArgb(248, 247, 182);
            btnNew.FlatAppearance.BorderColor = Color.FromArgb(248, 247, 182);

            btnClose.BackColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(248, 247, 182);

            NotePanel.BackColor = Color.FromArgb(252, 251, 181);
            txtNote.BackColor = Color.FromArgb(252, 251, 181);
            PanelBottom.BackColor = Color.FromArgb(252, 251, 181);
            lblSize.BackColor = Color.FromArgb(252, 251, 181);
        }
        #endregion

        #region ColorChange
        void ColorChange()
        {
            DateTimeNow();
            //Load StickyNote.xml
            doc.Load(Application.StartupPath + "/Data/StickyNote.xml");
            //Search in Root/Node
            foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
            {
                if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                {
                    node.SelectSingleNode("Date").InnerText = strDTNow;
                    node.SelectSingleNode("Color").InnerText = strColor;
                }
            }
            //Save XML
            doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            frmMain.strRefeshUC = "Yes";
        }
        #endregion

        #region Check text is null
        private void txtNote_TextChanged(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Trim();
            if (txtNote.Text == "")
            {
                selectAllToolStripMenuItem.Enabled = false;
            }
            else
            {
                selectAllToolStripMenuItem.Enabled = true;
            }

            //Load StickyNote.xml
            doc.Load(Application.StartupPath + "/Data/StickyNote.xml");
            //Search in Root/Node
            foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
            {
                if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                {
                    node.SelectSingleNode("Date").InnerText = strDTNow;
                    node.SelectSingleNode("Text").InnerText = txtNote.Text;
                }
            }
            //Save XML
            doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            frmMain.strRefeshUC = "Yes";
        }
        #endregion

        #region Check selected text
        private void txtNote_SelectionChanged(object sender, EventArgs e)
        {
            if (txtNote.SelectedText == "")
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
        }
        #endregion

        #region Cut
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Cut();
        }
        #endregion

        #region Copy
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Copy();
        }
        #endregion

        #region Paste
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.Paste();
        }
        #endregion

        #region Delete
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectedText = "";
        }
        #endregion

        #region Select All
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNote.SelectAll();
        }
        #endregion

        #region Check ClipBoard
        private void Timer_Tick(object sender, EventArgs e)
        {
            string strCB = Clipboard.GetText();

            if (strCB == "")
            {
                pasteToolStripMenuItem.Enabled = false;
            }
            else
            {
                pasteToolStripMenuItem.Enabled = true;
            }
        }
        #endregion
        #endregion

        #region Location Change
        private void frmStickyNote_LocationChanged(object sender, EventArgs e)
        {
            DateTimeNow();
            iLocationX = this.Location.X;
            iLocationY = this.Location.Y;

            //Load StickyNote.xml
            doc.Load(Application.StartupPath + "/Data/StickyNote.xml");
            //Search in Root/Node
            foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
            {
                if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                {
                    node.SelectSingleNode("Date").InnerText = strDTNow;
                    node.SelectSingleNode("LocationX").InnerText = iLocationX.ToString();
                    node.SelectSingleNode("LocationY").InnerText = iLocationY.ToString();
                }
            }
            //Save XML
            doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            frmMain.strRefeshUC = "Yes";
        }
        #endregion

        #region Size Change
        private void frmStickyNote_ResizeEnd(object sender, EventArgs e)
        {
            DateTimeNow();
            iSizeX = this.Size.Width;
            iSizeY = this.Size.Height;

            //Load StickyNote.xml
            doc.Load(Application.StartupPath + "/Data/StickyNote.xml");
            //Search in Root/Node
            foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
            {
                if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                {
                    node.SelectSingleNode("Date").InnerText = strDTNow;
                    node.SelectSingleNode("Width").InnerText = iSizeX.ToString();
                    node.SelectSingleNode("Height").InnerText = iSizeY.ToString();
                }
            }
            //Save XML
            doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            frmMain.strRefeshUC = "Yes";
        }
        #endregion
    }
}