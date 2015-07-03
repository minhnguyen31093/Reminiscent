using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Reminiscent
{
    public partial class UC_Favorite : UserControl
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        #region Properties
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;
        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }
        #endregion

        #region Set background
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, string pvParam, uint fWinIni);
        const uint SPI_SETDESKWALLPAPER = 0x14;
        const uint SPIF_UPDATEINIFILE = 0x01;

        public void SetDWallpaper(string path)
        {
            //SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_UPDATEINIFILE);
        }
        #endregion
        UC_FavoriteAudios fa;
        UC_FavoriteVideos fv;

        public UC_Favorite()
        {
            InitializeComponent();
        }

        #region Kế thừa
        public UC_Favorite(UC_FavoriteAudios ucFavoriteAudios)
            : this()
        {
            this.fa = ucFavoriteAudios;
        }
        public UC_Favorite(UC_FavoriteVideos ucFavoriteVideos)
            : this()
        {
            this.fv = ucFavoriteVideos;
        }
        #endregion

        private void UC_Favorite_Load(object sender, EventArgs e)
        {
            fa = new UC_FavoriteAudios();
            tabPage3.Controls.Add(fa);

            fv = new UC_FavoriteVideos();
            tabPage4.Controls.Add(fv);

            //Tab S\V
            LoadListSV();
            rtxtSV.ReadOnly = true;

            //Tab Image
            LoadListImage();

            //Tab Files
            LoadListFile();

            //Tab Folders
            LoadListFolder();

            //Tab Web
            LoadListWeb();

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
                    tabPage1.Text = frmMain.Decryption(node.SelectSingleNode("tab1").InnerText);
                    tabPage2.Text = frmMain.Decryption(node.SelectSingleNode("tab2").InnerText);
                    tabPage3.Text = frmMain.Decryption(node.SelectSingleNode("tab3").InnerText);
                    tabPage4.Text = frmMain.Decryption(node.SelectSingleNode("tab4").InnerText);
                    tabPage5.Text = frmMain.Decryption(node.SelectSingleNode("tab5").InnerText);
                    tabPage6.Text = frmMain.Decryption(node.SelectSingleNode("tab6").InnerText);
                    tabPage7.Text = frmMain.Decryption(node.SelectSingleNode("tab7").InnerText);

                    //tab1
                    colSVID.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colSVDate.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colText.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    //tab2
                    colID.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colName.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colLocation.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);
                    //tab5
                    colIDFiles.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colNameFiles.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colTypeFiles.Text = frmMain.Decryption(node.SelectSingleNode("col6").InnerText);
                    colSizeFiles.Text = frmMain.Decryption(node.SelectSingleNode("col7").InnerText);
                    colLocationFiles.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);
                    //tab6
                    colIDFolders.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colNameFolders.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colLocationFolders.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);
                    //tab7
                    colWebID.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colWebTitle.Text = frmMain.Decryption(node.SelectSingleNode("col8").InnerText);
                    colWebAdd.Text = frmMain.Decryption(node.SelectSingleNode("col9").InnerText);

                    //tab1
                    btnRefreshSV.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnSaveAsSV.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnRemoveSV.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnSaveSV.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    //tab2
                    btnNewImage.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);
                    btnDelImage.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    //tab5
                    btnAddFiles.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);
                    btnRemoveFiles.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    //tab6
                    btnAddFolders.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);
                    btnRemoveFolders.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    //tab7
                    btnWebHome.Text = frmMain.Decryption(node.SelectSingleNode("btn6").InnerText);
                    btnWebReload.Text = frmMain.Decryption(node.SelectSingleNode("btn7").InnerText);
                    btnWebGo.Text = frmMain.Decryption(node.SelectSingleNode("btn8").InnerText);
                    btnAddWeb.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    btnRemoveWeb.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);

                    copyToolStripMenuItem3.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);

                    previewToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    setAsDesktopBackgroundToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item3").InnerText);
                    openFileLocationToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item4").InnerText);
                    rotateRightToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item5").InnerText);
                    rotateLeftToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item6").InnerText);
                    copyToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    deleteToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item7").InnerText);
                    largeIconToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item8").InnerText);
                    detailsToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item9").InnerText);
                    smallIconToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item10").InnerText);
                    listToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item11").InnerText);
                    tileToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item12").InnerText);
                    propertiesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item13").InnerText);

                    previewToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    setAsDesktopBackgroundToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item3").InnerText);
                    openFileLocationToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item4").InnerText);
                    rotateRightToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item5").InnerText);
                    rotateLeftToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item6").InnerText);
                    copyToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    deleteToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item7").InnerText);
                    normalToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item14").InnerText);
                    stretchImageToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item15").InnerText);
                    autoSizeToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item16").InnerText);
                    centerImageToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item17").InnerText);
                    zoomToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item18").InnerText);
                    propertiesToolStripMenuItem1.Text = frmMain.Decryption(node.SelectSingleNode("item13").InnerText);

                    cutToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item19").InnerText);
                    copyToolStripMenuItem4.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    pasteToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item20").InnerText);
                    deleteToolStripMenuItem2.Text = frmMain.Decryption(node.SelectSingleNode("item7").InnerText);
                    selectAllToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item21").InnerText);

                    openFilesLocationToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item4").InnerText);
                    copyFilesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    deleteFilesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item7").InnerText);
                    propertiesFilesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item13").InnerText);

                    openFolderToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item22").InnerText);
                    copyFolderToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    deleteFolderToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item7").InnerText);
                    propertiesFolderToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item13").InnerText);

                    openToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item23").InnerText);
                    copyToolStripMenuItem2.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    break;
                }
            }
            #endregion

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
                    int ibc11 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc11").InnerText));
                    int ibc12 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc12").InnerText));
                    int ibc13 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc13").InnerText));
                    this.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
                    tabPage1.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage3.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage4.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage5.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage6.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage7.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    break;
                }
            }
            #endregion
        }

        #region Tab S\V
        int iIDSV = -1;
        int iFlagSV = 0;
        void LoadListSV()
        {
            lstSV.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteSV.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteSV.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList SV = root.GetElementsByTagName("SV");

                for (int i = 0; i < SV.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = frmMain.Decryption(SV[i].ChildNodes[0].InnerText);
                    lvi.SubItems.Add(frmMain.Decryption(SV[i].ChildNodes[1].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(SV[i].ChildNodes[2].InnerText));
                    lstSV.Items.Add(lvi);
                }
            }
        }

        private void lstSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSV.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstSV.SelectedItems)
                {
                    if (!string.IsNullOrEmpty(lvi.SubItems[2].Text))
                    {
                        rtxtSV.Text = lvi.SubItems[2].Text;
                        iIDSV = Convert.ToInt32(lvi.SubItems[0].Text);
                        iFlagSV = 2;
                        rtxtSV.ReadOnly = false;
                        break;
                    }
                }
            }
        }

        #region Refresh
        private void btnAddSV_Click(object sender, EventArgs e)
        {
            rtxtSV.Text = "";
            iFlagSV = 1;
            rtxtSV.ReadOnly = false;
        }
        #endregion

        #region Save As
        private void btnEditSV_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "/Data/FavoriteSV.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteSV.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Favorite");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            #region New
            if (iFlagSV == 2)
            {
                if (rtxtSV.Text.Trim() != "")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/FavoriteSV.xml");

                    XmlNode nodeSV = xmlDoc.CreateNode(XmlNodeType.Element, "SV", null);

                    XmlNode nodeID = xmlDoc.CreateElement("ID");
                    if (lstSV.Items.Count > 0)
                    {
                        int iMax = 0;
                        foreach (ListViewItem items in lstSV.Items)
                        {
                            if (iMax < Convert.ToInt32(items.Text))
                                iMax = Convert.ToInt32(items.Text);
                        }
                        nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                    }
                    else
                    {
                        nodeID.InnerText = frmMain.Encryption("0");
                    }
                    XmlNode nodeDate = xmlDoc.CreateElement("Date");
                    nodeDate.InnerText = frmMain.Encryption(DateTime.Now.ToShortDateString());

                    XmlNode nodeText = xmlDoc.CreateElement("Text");
                    nodeText.InnerText = frmMain.Encryption(rtxtSV.Text);

                    nodeSV.AppendChild(nodeID);
                    nodeSV.AppendChild(nodeDate);
                    nodeSV.AppendChild(nodeText);

                    xmlDoc.DocumentElement.AppendChild(nodeSV);
                    xmlDoc.Save(Application.StartupPath + "/Data/FavoriteSV.xml");

                    LoadListSV();
                }
                else
                {
                    MessageBox.Show("Sentence or Verse text can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            rtxtSV.ReadOnly = true;
            iFlagSV = 0;
        }
        #endregion

        #region Delete
        private void btnRemoveSV_Click(object sender, EventArgs e)
        {
            if (iFlagSV == 2)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteSV.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteSV.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/SV"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDSV.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteSV.xml");
                        LoadListSV();
                        iFlagSV = 0;
                    }
                }
            }
        }
        #endregion

        #region Save
        private void btnSaveSV_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "/Data/FavoriteSV.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteSV.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("Favorite");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            #region New
            if (iFlagSV == 1)
            {
                if (rtxtSV.Text.Trim() != "")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/FavoriteSV.xml");

                    XmlNode nodeSV = xmlDoc.CreateNode(XmlNodeType.Element, "SV", null);

                    XmlNode nodeID = xmlDoc.CreateElement("ID");
                    if (lstSV.Items.Count > 0)
                    {
                        int iMax = 0;
                        foreach (ListViewItem items in lstSV.Items)
                        {
                            if (iMax < Convert.ToInt32(items.Text))
                                iMax = Convert.ToInt32(items.Text);
                        }
                        nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                    }
                    else
                    {
                        nodeID.InnerText = frmMain.Encryption("0");
                    }
                    XmlNode nodeDate = xmlDoc.CreateElement("Date");
                    nodeDate.InnerText = frmMain.Encryption(DateTime.Now.ToShortDateString());

                    XmlNode nodeText = xmlDoc.CreateElement("Text");
                    nodeText.InnerText = frmMain.Encryption(rtxtSV.Text);

                    nodeSV.AppendChild(nodeID);
                    nodeSV.AppendChild(nodeDate);
                    nodeSV.AppendChild(nodeText);

                    xmlDoc.DocumentElement.AppendChild(nodeSV);
                    xmlDoc.Save(Application.StartupPath + "/Data/FavoriteSV.xml");

                    LoadListSV();
                }
                else
                {
                    MessageBox.Show("Sentence or Verse text can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
            
            #region Edit
            if (iFlagSV == 2)
            {
                if (File.Exists(Application.StartupPath + "/Data/FavoriteSV.xml"))
                {
                    if (rtxtSV.Text != "")
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteSV.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/SV"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDSV.ToString())
                            {
                                node.SelectSingleNode("Date").InnerText = frmMain.Encryption(DateTime.Now.ToShortDateString());
                                node.SelectSingleNode("Text").InnerText = frmMain.Encryption(rtxtSV.Text);
                                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteSV.xml");
                                LoadListSV();
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sentence or Verse text can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            #endregion
            rtxtSV.ReadOnly = true;
            iFlagSV = 0;
        }
        #endregion

        private void copyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstSV.SelectedItems)
            {
                Clipboard.SetText(lvi.SubItems[2].Text);
                break;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtSV.Cut();
        }

        private void copyToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            rtxtSV.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtSV.Paste();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            rtxtSV.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtxtSV.SelectAll();
        }
        #endregion

        //=======================================================================================================================
        //=======================================================================================================================
        #region Tab Image
        int iID = -1;
        void LoadListImage()
        {
            lstImage.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Images = root.GetElementsByTagName("Images");
                IMGlist.Images.Clear();

                for (int i = 0; i < Images.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();

                        //Image
                        lvi.ImageIndex = i;

                        if (!File.Exists(frmMain.Decryption(Images[i].ChildNodes[2].InnerText)))
                        {
                            lvi.BackColor = Color.LemonChiffon;
                            //Bitmap nullbmp = new Bitmap(1, 1);
                            //IMGlist.Images.Add(nullbmp);
                        }
                        else
                        {
                            IMGlist.Images.Add(Image.FromFile(frmMain.Decryption(Images[i].ChildNodes[2].InnerText)));
                        }
                        lvi.Text = frmMain.Decryption(Images[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Images[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Images[i].ChildNodes[2].InnerText));
                        lstImage.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("FavoriteImages.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/FavoriteImages.xml", "FavoriteImages.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/FavoriteImages.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteImages.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Favorite");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Favorite Images database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }

        private void lstImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstImage.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstImage.SelectedItems)
                {
                    iID = Convert.ToInt32(lvi.Text);
                    btnDelImage.Enabled = true;
                    if (File.Exists(lvi.SubItems[2].Text))
                    {
                        ImageBox.ImageLocation = lvi.SubItems[2].Text;
                    }
                    else
                    {
                        ImageBox.ImageLocation = "";
                        DialogResult dr = MessageBox.Show(lvi.SubItems[1].Text + " not exist!\n\nDo you want to remove it from list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            btnDelImage_Click(sender, e);
                        }
                    }
                }
            }
            else
            {
                
            }
        }

        #region Image Context Menu
        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ImageBox.ImageLocation))
            {
                Process.Start("explorer.exe", ImageBox.ImageLocation);
            }
        }

        private void setAsDesktopBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ImageBox.ImageLocation))
                SetDWallpaper(ImageBox.ImageLocation);
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ImageBox.ImageLocation))
            {
                Process.Start("explorer.exe", "/select, " + ImageBox.ImageLocation);
            }
        }

        void SaveImage()
        {
            if (File.Exists(ImageBox.ImageLocation))
            {
                string strext = ImageBox.ImageLocation;
                strext = strext.Substring(strext.LastIndexOf('.'));
                if (strext == ".bmp")
                {
                    ImageBox.Image.Save(ImageBox.ImageLocation, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else if (strext == ".jpg")
                {
                    ImageBox.Image.Save(ImageBox.ImageLocation, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else if (strext == ".png")
                {
                    ImageBox.Image.Save(ImageBox.ImageLocation, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if (strext == ".gif")
                {
                    ImageBox.Image.Save(ImageBox.ImageLocation, System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
        }

        private void rotateRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = ImageBox.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            ImageBox.Image = img;
            SaveImage();
        }

        private void rotateLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = ImageBox.Image;
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            ImageBox.Image = img;
            SaveImage();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");

                foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Images"))
                {
                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                    {
                        if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                        {
                            System.Collections.Specialized.StringCollection Files = new System.Collections.Specialized.StringCollection();
                            Files.Add(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                            Clipboard.SetFileDropList(Files);
                            break;
                        }
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iID > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Images"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                            {
                                if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                                {
                                    File.Delete(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                                }
                                node.ParentNode.RemoveChild(node);
                                break;
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteImages.xml");

                        LoadListImage();
                    }
                }
            }
        }

        void ReloadImageList()
        {
            if (File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Images = root.GetElementsByTagName("Images");
                IMGlist.Images.Clear();

                for (int i = 0; i < Images.Count; i++)
                {
                    if(File.Exists(frmMain.Decryption(Images[i].ChildNodes[2].InnerText)))
                        IMGlist.Images.Add(Image.FromFile(frmMain.Decryption(Images[i].ChildNodes[2].InnerText)));
                }
            }
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGlist.ImageSize = new Size(128, 128);
            ReloadImageList();
            lstImage.View = View.LargeIcon;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGlist.ImageSize = new Size(16, 16);
            ReloadImageList();
            lstImage.View = View.Details;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGlist.ImageSize = new Size(32, 32);
            ReloadImageList();
            lstImage.View = View.SmallIcon;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGlist.ImageSize = new Size(16, 16);
            ReloadImageList();
            lstImage.View = View.List;
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IMGlist.ImageSize = new Size(32, 32);
            ReloadImageList();
            lstImage.View = View.Tile;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(ImageBox.ImageLocation))
                ShowFileProperties(ImageBox.ImageLocation);
        }
        #endregion

        #region Image Size Mode
        private void previewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            previewToolStripMenuItem_Click(sender, e);
        }

        private void setAsDesktopBackgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            setAsDesktopBackgroundToolStripMenuItem_Click(sender, e);
        }

        private void openFileLocationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileLocationToolStripMenuItem_Click(sender, e);
        }

        private void rotateRightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rotateRightToolStripMenuItem_Click(sender, e);
        }

        private void rotateLeftToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rotateLeftToolStripMenuItem_Click(sender, e);
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            propertiesToolStripMenuItem_Click(sender, e);
        }
        #endregion

        private void btnNewImage_Click(object sender, EventArgs e)
        {
            DialogResult ImageResult = OpenImage.ShowDialog();
            if (ImageResult == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteImages.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");

                XmlNode nodeImages = xmlDoc.CreateNode(XmlNodeType.Element, "Images", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstImage.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstImage.Items)
                    {
                        if (iMax < Convert.ToInt32(items.Text))
                            iMax = Convert.ToInt32(items.Text);
                    }
                    nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                }
                else
                {
                    nodeID.InnerText = frmMain.Encryption("0");
                }
                XmlNode nodeName = xmlDoc.CreateElement("Name");
                nodeName.InnerText = frmMain.Encryption(OpenImage.SafeFileName.Substring(0, OpenImage.SafeFileName.LastIndexOf('.')));

                XmlNode nodeLocation = xmlDoc.CreateElement("Location");
                nodeLocation.InnerText = frmMain.Encryption(OpenImage.FileName);

                nodeImages.AppendChild(nodeID);
                nodeImages.AppendChild(nodeName);
                nodeImages.AppendChild(nodeLocation);

                xmlDoc.DocumentElement.AppendChild(nodeImages);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteImages.xml");

                LoadListImage();
            }
        }

        private void btnDelImage_Click(object sender, EventArgs e)
        {
            if (iID > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteImages.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteImages.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Images"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteImages.xml");

                        LoadListImage();
                    }
                }
            }
        }
        #endregion

        //=======================================================================================================================
        //=======================================================================================================================

        #region Tab Files
        int iIDFiles = -1;
        private void btnAddFiles_Click(object sender, EventArgs e)
        {
            DialogResult FilesResult = OpenFile.ShowDialog();
            if (FilesResult == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteFiles.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteFiles.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFiles.xml");

                XmlNode nodeFiles = xmlDoc.CreateNode(XmlNodeType.Element, "Files", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstFiles.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstFiles.Items)
                    {
                        if (iMax < Convert.ToInt32(items.Text))
                            iMax = Convert.ToInt32(items.Text);
                    }
                    nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                }
                else
                {
                    nodeID.InnerText = frmMain.Encryption("0");
                }
                XmlNode nodeName = xmlDoc.CreateElement("Name");
                nodeName.InnerText = frmMain.Encryption(Path.GetFileNameWithoutExtension(OpenFile.FileName));

                XmlNode nodeType = xmlDoc.CreateElement("Type");
                nodeType.InnerText = frmMain.Encryption(Path.GetExtension(OpenFile.FileName).Substring(1).ToUpper());
                
                XmlNode nodeSize = xmlDoc.CreateElement("Size");
                nodeSize.InnerText = frmMain.Encryption(new FileInfo(OpenFile.FileName).Length.ToString() + " bytes");

                XmlNode nodeLocation = xmlDoc.CreateElement("Location");
                nodeLocation.InnerText = frmMain.Encryption(OpenFile.FileName);

                nodeFiles.AppendChild(nodeID);
                nodeFiles.AppendChild(nodeName);
                nodeFiles.AppendChild(nodeType);
                nodeFiles.AppendChild(nodeSize);
                nodeFiles.AppendChild(nodeLocation);

                xmlDoc.DocumentElement.AppendChild(nodeFiles);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFiles.xml");

                LoadListFile();
            }
        }

        private void btnRemoveFiles_Click(object sender, EventArgs e)
        {
            if (iIDFiles > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteFiles.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFiles.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Files"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFiles.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFiles.xml");

                        LoadListFile();
                    }
                }
            }
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstFiles.SelectedItems)
                {
                    iIDFiles = Convert.ToInt32(lvi.Text);
                }
            }
            else
            { 
            
            }
        }

        void LoadListFile()
        {
            lstFiles.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteFiles.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFiles.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Files = root.GetElementsByTagName("Files");

                for (int i = 0; i < Files.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = frmMain.Decryption(Files[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Files[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Files[i].ChildNodes[2].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Files[i].ChildNodes[3].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Files[i].ChildNodes[4].InnerText));
                        if (!File.Exists(frmMain.Decryption(Files[i].ChildNodes[4].InnerText)))
                            lvi.BackColor = Color.LemonChiffon;
                        lstFiles.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("FavoriteFiles.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/FavoriteFiles.xml", "FavoriteFiles.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/FavoriteFiles.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteFiles.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Favorite");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Favorite Files database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }

        private void openFilesLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstFiles.SelectedItems)
            {
                if (File.Exists(lvi.SubItems[4].Text))
                {
                    LoadListFile();
                    Process.Start("explorer.exe", "/select, " + lvi.SubItems[4].Text);
                    break;
                }
                else
                {
                    LoadListFile();
                    DialogResult dr = MessageBox.Show(lvi.SubItems[1].Text + " not exist!\n\nDo you want to remove it from list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        btnRemoveFiles_Click(sender, e);
                    }
                }
            }
        }

        private void copyFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/FavoriteFiles.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFiles.xml");

                foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Files"))
                {
                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFiles.ToString())
                    {
                        if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                        {
                            System.Collections.Specialized.StringCollection Files = new System.Collections.Specialized.StringCollection();
                            Files.Add(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                            Clipboard.SetFileDropList(Files);
                        }
                        break;
                    }
                }
            }
        }

        private void deleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iIDFiles > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteFiles.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFiles.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Files"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFiles.ToString())
                            {
                                if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                                {
                                    File.Delete(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                                }
                                node.ParentNode.RemoveChild(node);
                                break;
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFiles.xml");

                        LoadListFile();
                    }
                }
            }
        }

        private void propertiesFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstFiles.SelectedItems)
            {
                if (File.Exists(lvi.SubItems[4].Text))
                {
                    ShowFileProperties(lvi.SubItems[4].Text);
                    break;
                }
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e)
        {
            openFilesLocationToolStripMenuItem_Click(sender, e);
        }
        #endregion
        //=======================================================================================================================
        //=======================================================================================================================

        #region Tab Folders
        int iIDFolders = -1;
        private void btnAddFolders_Click(object sender, EventArgs e)
        {
            DialogResult FoldersResult = OpenFolder.ShowDialog();
            if (FoldersResult == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteFolders.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteFolders.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFolders.xml");

                XmlNode nodeFolders = xmlDoc.CreateNode(XmlNodeType.Element, "Folders", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstFolders.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstFolders.Items)
                    {
                        if (iMax < Convert.ToInt32(items.Text))
                            iMax = Convert.ToInt32(items.Text);
                    }
                    nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                }
                else
                {
                    nodeID.InnerText = frmMain.Encryption("0");
                }
                XmlNode nodeName = xmlDoc.CreateElement("Name");
                nodeName.InnerText = frmMain.Encryption(OpenFolder.SelectedPath.ToString().Substring(OpenFolder.SelectedPath.ToString().LastIndexOf('\\') + 1));

                XmlNode nodeLocation = xmlDoc.CreateElement("Location");
                nodeLocation.InnerText = frmMain.Encryption(OpenFolder.SelectedPath.ToString());

                nodeFolders.AppendChild(nodeID);
                nodeFolders.AppendChild(nodeName);
                nodeFolders.AppendChild(nodeLocation);

                xmlDoc.DocumentElement.AppendChild(nodeFolders);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFolders.xml");

                LoadListFolder();
            }
        }

        private void btnRemoveFolders_Click(object sender, EventArgs e)
        {
            if (iIDFolders > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteFolders.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFolders.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Folders"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFolders.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFolders.xml");

                        LoadListFolder();
                    }
                }
            }
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItems != null)
            {
                foreach (ListViewItem lvi in lstFolders.SelectedItems)
                {
                    iIDFolders = Convert.ToInt32(lvi.Text);
                }
            }
        }

        void LoadListFolder()
        {
            lstFolders.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteFolders.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFolders.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Folders = root.GetElementsByTagName("Folders");

                for (int i = 0; i < Folders.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = frmMain.Decryption(Folders[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Folders[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Folders[i].ChildNodes[2].InnerText));
                        if (!Directory.Exists(frmMain.Decryption(Folders[i].ChildNodes[2].InnerText)))
                            lvi.BackColor = Color.LemonChiffon;
                        lstFolders.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("FavoriteFolders.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/FavoriteFolders.xml", "FavoriteFolders.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/FavoriteFolders.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteFolders.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Favorite");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Favorite Folders database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstFolders.SelectedItems)
            {
                if (Directory.Exists(lvi.SubItems[2].Text))
                {
                    LoadListFolder();
                    Process.Start(lvi.SubItems[2].Text);
                    break;
                }
                else
                {
                    LoadListFolder();
                    DialogResult dr = MessageBox.Show(lvi.SubItems[1].Text + " not exist!\n\nDo you want to remove it from list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        btnRemoveFolders_Click(sender, e);
                    }
                }
            }
        }

        private void copyFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/FavoriteFolders.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFolders.xml");

                foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Folders"))
                {
                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFolders.ToString())
                    {
                        if (Directory.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                        {
                            System.Collections.Specialized.StringCollection Files = new System.Collections.Specialized.StringCollection();
                            Files.Add(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                            Clipboard.SetFileDropList(Files);
                            break;
                        }
                    }
                }
            }
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (iIDFolders > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteFolders.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteFolders.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Folders"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDFolders.ToString())
                            {
                                if (Directory.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                                {
                                    Directory.Delete(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                                }
                                node.ParentNode.RemoveChild(node);
                                break;
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteFolders.xml");

                        LoadListFolder();
                    }
                }
            }
        }

        private void propertiesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstFolders.SelectedItems)
            {
                if (Directory.Exists(lvi.SubItems[2].Text))
                {
                    ShowFileProperties(lvi.SubItems[2].Text);
                    break;
                }
            }
        }

        private void lstFolders_DoubleClick(object sender, EventArgs e)
        {
            openFolderToolStripMenuItem_Click(sender, e);
        }
        #endregion
        //=======================================================================================================================
        //=======================================================================================================================

        #region Tab Website
        string strSite = "";
        int iIDWeb = -1;
        private void WebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (AddressBar.Text != e.Url.ToString())
            {
                AddressBar.Text = e.Url.ToString();
                txtWebTitle.Text = WebBrowser.Document.Title;
            }
        }

        private void btnWebHome_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty("google.com.vn"))
            {
                WebBrowser.Navigate("google.com.vn");
                strSite = "google.com.vn";
                txtWebTitle.Text = WebBrowser.Document.Title;
            }
        }

        private void btnWebReload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(strSite))
            {
                WebBrowser.Navigate(strSite);
                txtWebTitle.Text = WebBrowser.Document.Title;
            }
        }

        private void btnWebGo_Click(object sender, EventArgs e)
        {
            strSite = "";
            if (!string.IsNullOrEmpty(AddressBar.Text))
            {
                WebBrowser.Navigate(AddressBar.Text);
                strSite = AddressBar.Text;
                txtWebTitle.Text = WebBrowser.Document.Title;
            }
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnWebGo_Click(sender, e);
            }
        }

        void LoadListWeb()
        {
            lstWebsites.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteWebsites.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteWebsites.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Websites = root.GetElementsByTagName("Websites");

                for (int i = 0; i < Websites.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = frmMain.Decryption(Websites[i].ChildNodes[0].InnerText);
                    lvi.SubItems.Add(frmMain.Decryption(Websites[i].ChildNodes[1].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(Websites[i].ChildNodes[2].InnerText));
                    lstWebsites.Items.Add(lvi);
                }
            }
        }

        int iflagweb = 0;
        private void lstWebsites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstWebsites.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstWebsites.SelectedItems)
                {
                    if (!string.IsNullOrEmpty(lvi.SubItems[2].Text))
                    {
                        WebBrowser.Navigate(lvi.SubItems[2].Text);
                        strSite = lvi.SubItems[2].Text;
                        txtWebTitle.Text = WebBrowser.Document.Title;
                        iIDWeb = Convert.ToInt32(lvi.SubItems[0].Text);
                        iflagweb = 2;
                        break;
                    }
                }
            }
        }

        private void btnAddWeb_Click(object sender, EventArgs e)
        {
            if (iflagweb != 2)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteWebsites.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteWebsites.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteWebsites.xml");

                XmlNode nodeWebsites = xmlDoc.CreateNode(XmlNodeType.Element, "Websites", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstWebsites.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstWebsites.Items)
                    {
                        if (iMax < Convert.ToInt32(items.Text))
                            iMax = Convert.ToInt32(items.Text);
                    }
                    nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString());
                }
                else
                {
                    nodeID.InnerText = frmMain.Encryption("0");
                }
                XmlNode nodeTitle = xmlDoc.CreateElement("Title");
                nodeTitle.InnerText = frmMain.Encryption(WebBrowser.Document.Title);

                XmlNode nodeAddress = xmlDoc.CreateElement("Address");
                nodeAddress.InnerText = frmMain.Encryption(AddressBar.Text);

                nodeWebsites.AppendChild(nodeID);
                nodeWebsites.AppendChild(nodeTitle);
                nodeWebsites.AppendChild(nodeAddress);

                xmlDoc.DocumentElement.AppendChild(nodeWebsites);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteWebsites.xml");

                LoadListWeb();
            }

            else if (iflagweb == 2)
            {
                if (File.Exists(Application.StartupPath + "/Data/FavoriteWebsites.xml"))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(Application.StartupPath + "/Data/FavoriteWebsites.xml");

                    foreach (XmlNode node in xDoc.SelectNodes("Favorite/Websites"))
                    {
                        if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDWeb.ToString())
                        {
                            node.SelectSingleNode("Title").InnerText = frmMain.Encryption(txtWebTitle.Text);
                            node.SelectSingleNode("Address").InnerText = frmMain.Encryption(AddressBar.Text);
                            xDoc.Save(Application.StartupPath + "/Data/FavoriteWebsites.xml");
                            LoadListWeb();
                            break;
                        }
                    }
                }
            }
            iflagweb = 0;
        }

        private void btnRemoveWeb_Click(object sender, EventArgs e)
        {
            if (iflagweb == 2)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteWebsites.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteWebsites.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Websites"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDWeb.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteWebsites.xml");
                        LoadListWeb();
                        iflagweb = 0;
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstWebsites.SelectedItems)
            {
                Process.Start(lvi.SubItems[2].Text);
                break;
            }

        }

        private void copyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstWebsites.SelectedItems)
            {
                Clipboard.SetText(lvi.SubItems[2].Text);
                break;
            }
        }
        #endregion

        #region Hover
        private void btnAddSV_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefreshSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnEditSV_MouseMove(object sender, MouseEventArgs e)
        {
            btnSaveAsSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveSV_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnSaveSV_MouseMove(object sender, MouseEventArgs e)
        {
            btnSaveSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnNewImage_MouseMove(object sender, MouseEventArgs e)
        {
            btnNewImage.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDelImage_MouseMove(object sender, MouseEventArgs e)
        {
            btnDelImage.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnAddFiles_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddFiles.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveFiles_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveFiles.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnAddFolders_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddFolders.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveFolders_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveFolders.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnAddWeb_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddWeb.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveWeb_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveWeb.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnWebHome_MouseMove(object sender, MouseEventArgs e)
        {
            btnWebHome.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnWebReload_MouseMove(object sender, MouseEventArgs e)
        {
            btnWebReload.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnWebGo_MouseMove(object sender, MouseEventArgs e)
        {
            btnWebGo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }
        //Leave
        private void btnAddSV_MouseLeave(object sender, EventArgs e)
        {
            btnRefreshSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnEditSV_MouseLeave(object sender, EventArgs e)
        {
            btnSaveAsSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveSV_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnSaveSV_MouseLeave(object sender, EventArgs e)
        {
            btnSaveSV.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnNewImage_MouseLeave(object sender, EventArgs e)
        {
            btnNewImage.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnDelImage_MouseLeave(object sender, EventArgs e)
        {
            btnDelImage.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnAddFiles_MouseLeave(object sender, EventArgs e)
        {
            btnAddFiles.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveFiles_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveFiles.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnAddFolders_MouseLeave(object sender, EventArgs e)
        {
            btnAddFolders.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveFolders_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveFolders.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnAddWeb_MouseLeave(object sender, EventArgs e)
        {
            btnAddWeb.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveWeb_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveWeb.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnWebHome_MouseLeave(object sender, EventArgs e)
        {
            btnWebHome.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnWebReload_MouseLeave(object sender, EventArgs e)
        {
            btnWebReload.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnWebGo_MouseLeave(object sender, EventArgs e)
        {
            btnWebGo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion

        public static int iTabindex = 0;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            iTabindex = TabControl1.SelectedIndex;
            frmMain.iTabChanged = 1;
        }

        #region PageUp
        //Tab 0
        internal void PgUp0()
        {
            if (lstSV.Items.Count > 0)
            {
                if (frmMain.iPage < 14)
                {
                    lstSV.Focus();
                    lstSV.EnsureVisible(0);
                    lstSV.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstSV.Focus();
                    lstSV.EnsureVisible(frmMain.iPage);
                    lstSV.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 1
        internal void PgUp1()
        {
            if (lstImage.Items.Count > 0)
            {
                if (frmMain.iPage < 44)
                {
                    lstImage.Focus();
                    lstImage.EnsureVisible(0);
                    lstImage.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstImage.Focus();
                    lstImage.EnsureVisible(frmMain.iPage);
                    lstImage.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 2
        internal void PgUp2()
        {
            if (fa.lstAudio.Items.Count > 0)
            {
                if (frmMain.iPage < 36)
                {
                    fa.lstAudio.Focus();
                    fa.lstAudio.EnsureVisible(0);
                    fa.lstAudio.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    fa.lstAudio.Focus();
                    fa.lstAudio.EnsureVisible(frmMain.iPage);
                    fa.lstAudio.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 3
        internal void PgUp3()
        {
            if (fv.lstVideo.Items.Count > 0)
            {
                if (frmMain.iPage < 48)
                {
                    fv.lstVideo.Focus();
                    fv.lstVideo.EnsureVisible(0);
                    fv.lstVideo.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    fv.lstVideo.Focus();
                    fv.lstVideo.EnsureVisible(frmMain.iPage);
                    fv.lstVideo.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 4
        internal void PgUp4()
        {
            if (lstFiles.Items.Count > 0)
            {
                if (frmMain.iPage < 48)
                {
                    lstFiles.Focus();
                    lstFiles.EnsureVisible(0);
                    lstFiles.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstFiles.Focus();
                    lstFiles.EnsureVisible(frmMain.iPage);
                    lstFiles.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 5
        internal void PgUp5()
        {
            if (lstFolders.Items.Count > 0)
            {
                if (frmMain.iPage < 44)
                {
                    lstFolders.Focus();
                    lstFolders.EnsureVisible(0);
                    lstFolders.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstFolders.Focus();
                    lstFolders.EnsureVisible(frmMain.iPage);
                    lstFolders.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 6
        internal void PgUp6()
        {
            if (lstWebsites.Items.Count > 0)
            {
                if (frmMain.iPage < 12)
                {
                    lstWebsites.Focus();
                    lstWebsites.EnsureVisible(0);
                    lstWebsites.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstWebsites.Focus();
                    lstWebsites.EnsureVisible(frmMain.iPage);
                    lstWebsites.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        #endregion

        #region PageDown
        //Tab 0
        internal void PgDn0()
        {
            if (lstSV.Items.Count > 0)
            {
                if (frmMain.iPage > lstSV.Items.Count - 1)
                {
                    lstSV.Focus();
                    lstSV.EnsureVisible(lstSV.Items.Count - 1);
                    lstSV.Items[lstSV.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstSV.Items.Count - 1;
                }
                else
                {
                    lstSV.Focus();
                    lstSV.EnsureVisible(frmMain.iPage);
                    lstSV.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 1
        internal void PgDn1()
        {
            if (lstImage.Items.Count > 0)
            {
                if (frmMain.iPage > lstImage.Items.Count - 1)
                {
                    lstImage.Focus();
                    lstImage.EnsureVisible(lstImage.Items.Count - 1);
                    lstImage.Items[lstImage.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstImage.Items.Count - 1;
                }
                else
                {
                    lstImage.Focus();
                    lstImage.EnsureVisible(frmMain.iPage);
                    lstImage.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 2
        internal void PgDn2()
        {
            if (fa.lstAudio.Items.Count > 0)
            {
                if (frmMain.iPage > fa.lstAudio.Items.Count - 1)
                {
                    fa.lstAudio.Focus();
                    fa.lstAudio.EnsureVisible(fa.lstAudio.Items.Count - 1);
                    fa.lstAudio.Items[fa.lstAudio.Items.Count - 1].Selected = true;
                    frmMain.iPage = fa.lstAudio.Items.Count - 1;
                }
                else
                {
                    fa.lstAudio.Focus();
                    fa.lstAudio.EnsureVisible(frmMain.iPage);
                    fa.lstAudio.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 3
        internal void PgDn3()
        {
            if (fv.lstVideo.Items.Count > 0)
            {
                if (frmMain.iPage > fv.lstVideo.Items.Count - 1)
                {
                    fv.lstVideo.Focus();
                    fv.lstVideo.EnsureVisible(fv.lstVideo.Items.Count - 1);
                    fv.lstVideo.Items[fv.lstVideo.Items.Count - 1].Selected = true;
                    frmMain.iPage = fv.lstVideo.Items.Count - 1;
                }
                else
                {
                    fv.lstVideo.Focus();
                    fv.lstVideo.EnsureVisible(frmMain.iPage);
                    fv.lstVideo.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 4
        internal void PgDn4()
        {
            if (lstFiles.Items.Count > 0)
            {
                if (frmMain.iPage > lstFiles.Items.Count - 1)
                {
                    lstFiles.Focus();
                    lstFiles.EnsureVisible(lstFiles.Items.Count - 1);
                    lstFiles.Items[lstFiles.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstFiles.Items.Count - 1;
                }
                else
                {
                    lstFiles.Focus();
                    lstFiles.EnsureVisible(frmMain.iPage);
                    lstFiles.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 5
        internal void PgDn5()
        {
            if (lstFolders.Items.Count > 0)
            {
                if (frmMain.iPage > lstFolders.Items.Count - 1)
                {
                    lstFolders.Focus();
                    lstFolders.EnsureVisible(lstFolders.Items.Count - 1);
                    lstFolders.Items[lstFolders.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstFolders.Items.Count - 1;
                }
                else
                {
                    lstFolders.Focus();
                    lstFolders.EnsureVisible(frmMain.iPage);
                    lstFolders.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        //Tab 6
        internal void PgDn6()
        {
            if (lstWebsites.Items.Count > 0)
            {
                if (frmMain.iPage > lstWebsites.Items.Count - 1)
                {
                    lstWebsites.Focus();
                    lstWebsites.EnsureVisible(lstWebsites.Items.Count - 1);
                    lstWebsites.Items[lstWebsites.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstWebsites.Items.Count - 1;
                }
                else
                {
                    lstWebsites.Focus();
                    lstWebsites.EnsureVisible(frmMain.iPage);
                    lstWebsites.Items[frmMain.iPage].Selected = true;
                }
            }
        }
        #endregion

        #region Search
        //Tab 0
        internal void Search0(string strSearch, string strBy)
        {
            if (lstSV.Items.Count > 0)
            {
                if (frmMain.iSearch == lstSV.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstSV.Items.Count; i++)
                {
                    if (strBy == "Date")
                    {
                        if (lstSV.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstSV.Focus();
                            lstSV.EnsureVisible(i);
                            lstSV.Items[i].Selected = true;
                            if (i == lstSV.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstSV.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Text")
                    {
                        if (lstSV.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstSV.Focus();
                            lstSV.EnsureVisible(i);
                            lstSV.Items[i].Selected = true;
                            if (i == lstSV.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstSV.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 1
        internal void Search1(string strSearch, string strBy)
        {
            if (lstImage.Items.Count > 0)
            {
                if (frmMain.iSearch == lstImage.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstImage.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (lstImage.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstImage.Focus();
                            lstImage.EnsureVisible(i);
                            lstImage.Items[i].Selected = true;
                            if (i == lstImage.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstImage.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Location")
                    {
                        if (lstImage.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstImage.Focus();
                            lstImage.EnsureVisible(i);
                            lstImage.Items[i].Selected = true;
                            if (i == lstImage.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstImage.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 2
        internal void Search2(string strSearch, string strBy)
        {
            if (fa.lstAudio.Items.Count > 0)
            {
                if (frmMain.iSearch == fa.lstAudio.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < fa.lstAudio.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (fa.lstAudio.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            fa.lstAudio.Focus();
                            fa.lstAudio.EnsureVisible(i);
                            fa.lstAudio.Items[i].Selected = true;
                            if (i == fa.lstAudio.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == fa.lstAudio.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Location")
                    {
                        if (fa.lstAudio.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            fa.lstAudio.Focus();
                            fa.lstAudio.EnsureVisible(i);
                            fa.lstAudio.Items[i].Selected = true;
                            if (i == fa.lstAudio.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == fa.lstAudio.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 3
        internal void Search3(string strSearch, string strBy)
        {
            if (fv.lstVideo.Items.Count > 0)
            {
                if (frmMain.iSearch == fv.lstVideo.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < fv.lstVideo.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (fv.lstVideo.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            fv.lstVideo.Focus();
                            fv.lstVideo.EnsureVisible(i);
                            fv.lstVideo.Items[i].Selected = true;
                            if (i == fv.lstVideo.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == fv.lstVideo.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Location")
                    {
                        if (fv.lstVideo.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            fv.lstVideo.Focus();
                            fv.lstVideo.EnsureVisible(i);
                            fv.lstVideo.Items[i].Selected = true;
                            if (i == fv.lstVideo.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == fv.lstVideo.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 4
        internal void Search4(string strSearch, string strBy)
        {
            if (lstFiles.Items.Count > 0)
            {
                if (frmMain.iSearch == lstFiles.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstFiles.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (lstFiles.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFiles.Focus();
                            lstFiles.EnsureVisible(i);
                            lstFiles.Items[i].Selected = true;
                            if (i == lstFiles.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFiles.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Type")
                    {
                        if (lstFiles.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFiles.Focus();
                            lstFiles.EnsureVisible(i);
                            lstFiles.Items[i].Selected = true;
                            if (i == lstFiles.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFiles.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Size")
                    {
                        if (lstFiles.Items[i].SubItems[3].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFiles.Focus();
                            lstFiles.EnsureVisible(i);
                            lstFiles.Items[i].Selected = true;
                            if (i == lstFiles.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFiles.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Location")
                    {
                        if (lstFiles.Items[i].SubItems[4].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFiles.Focus();
                            lstFiles.EnsureVisible(i);
                            lstFiles.Items[i].Selected = true;
                            if (i == lstFiles.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFiles.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 5
        internal void Search5(string strSearch, string strBy)
        {
            if (lstFolders.Items.Count > 0)
            {
                if (frmMain.iSearch == lstFolders.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstFolders.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (lstFolders.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFolders.Focus();
                            lstFolders.EnsureVisible(i);
                            lstFolders.Items[i].Selected = true;
                            if (i == lstFolders.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFolders.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Location")
                    {
                        if (lstFolders.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstFolders.Focus();
                            lstFolders.EnsureVisible(i);
                            lstFolders.Items[i].Selected = true;
                            if (i == lstFolders.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstFolders.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        //Tab 6
        internal void Search6(string strSearch, string strBy)
        {
            if (lstWebsites.Items.Count > 0)
            {
                if (frmMain.iSearch == lstWebsites.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstWebsites.Items.Count; i++)
                {
                    if (strBy == "Title")
                    {
                        if (lstWebsites.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstWebsites.Focus();
                            lstWebsites.EnsureVisible(i);
                            lstWebsites.Items[i].Selected = true;
                            if (i == lstWebsites.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstWebsites.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Address")
                    {
                        if (lstWebsites.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstWebsites.Focus();
                            lstWebsites.EnsureVisible(i);
                            lstWebsites.Items[i].Selected = true;
                            if (i == lstWebsites.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstWebsites.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
