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
    public partial class UC_FavoriteVideos : UserControl
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

        public UC_FavoriteVideos()
        {
            InitializeComponent();
        }

        int iIDVideo = -1;

        private void UC_FavoriteVideos_Load(object sender, EventArgs e)
        {
            LoadListVideo();

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
                    colIDVideo.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colNameVideo.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colLocationVideo.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);

                    btnAddVideo.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnRemoveVideo.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);

                    openFileLocationToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    copyToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    deleteToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item3").InnerText);
                    propertiesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item4").InnerText);
                    break;
                }
            }
            #endregion
        }

        private void UC_FavoriteVideos_Leave(object sender, EventArgs e)
        {
            WMPVideoPlayer.Ctlcontrols.pause();
        }

        void LoadListVideo()
        {
            lstVideo.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteVideos.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteVideos.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Videos = root.GetElementsByTagName("Videos");

                for (int i = 0; i < Videos.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = frmMain.Decryption(Videos[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Videos[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Videos[i].ChildNodes[2].InnerText));
                        if (!File.Exists(frmMain.Decryption(Videos[i].ChildNodes[2].InnerText)))
                            lvi.BackColor = Color.LemonChiffon;
                        lstVideo.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("FavoriteVideos.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/FavoriteVideos.xml", "FavoriteVideos.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/FavoriteVideos.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteVideos.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Favorite");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Favorite Videos database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }

        private void lstVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVideo.SelectedItems != null)
            {
                WMPVideoPlayer.Ctlcontrols.stop();
                foreach (ListViewItem lvi in lstVideo.SelectedItems)
                {
                    iIDVideo = Convert.ToInt32(lvi.Text);
                    if (File.Exists(lvi.SubItems[2].Text))
                    {
                        WMPVideoPlayer.URL = lvi.SubItems[2].Text;
                        WMPVideoPlayer.Ctlcontrols.play();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(lvi.SubItems[1].Text + " not exist!\n\nDo you want to remove it from list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            btnRemoveVideo_Click(sender, e);
                        }
                        //LoadListVideo();
                    }
                    break;
                }
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenVideo = new OpenFileDialog();
            OpenVideo.Filter = "Video Files |*.avi;*.mov;*.mp4;*.mpeg;*.mpg;*.ts;*.wmv;*.swf|All Files |*.*";
            DialogResult VideoResult = OpenVideo.ShowDialog();
            if (VideoResult == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteVideos.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteVideos.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteVideos.xml");

                XmlNode nodeImages = xmlDoc.CreateNode(XmlNodeType.Element, "Videos", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstVideo.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstVideo.Items)
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
                nodeName.InnerText = frmMain.Encryption(OpenVideo.SafeFileName.Substring(0, OpenVideo.SafeFileName.LastIndexOf('.')));

                XmlNode nodeLocation = xmlDoc.CreateElement("Location");
                nodeLocation.InnerText = frmMain.Encryption(OpenVideo.FileName);

                nodeImages.AppendChild(nodeID);
                nodeImages.AppendChild(nodeName);
                nodeImages.AppendChild(nodeLocation);

                xmlDoc.DocumentElement.AppendChild(nodeImages);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteVideos.xml");

                LoadListVideo();
            }
        }

        private void btnRemoveVideo_Click(object sender, EventArgs e)
        {
            if (iIDVideo > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteVideos.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteVideos.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Videos"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDVideo.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteVideos.xml");

                        LoadListVideo();
                    }
                }
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstVideo.SelectedItems)
            {
                if (File.Exists(lvi.SubItems[2].Text))
                {
                    Process.Start("explorer.exe", "/select, " + lvi.SubItems[2].Text);
                }
                else
                { 
                
                }
                break;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/FavoriteVideos.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteVideos.xml");

                foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Videos"))
                {
                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDVideo.ToString())
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
            if (iIDVideo > -1)
            {
                WMPVideoPlayer.Ctlcontrols.stop();
                WMPVideoPlayer.URL = "";
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteVideos.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteVideos.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Videos"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDVideo.ToString())
                            {
                                if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                                {
                                    File.Delete(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                                }
                                node.ParentNode.RemoveChild(node);
                                break;
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteVideos.xml");

                        LoadListVideo();
                    }
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstVideo.SelectedItems)
            {
                if (File.Exists(lvi.SubItems[2].Text))
                    ShowFileProperties(lvi.SubItems[2].Text);
                break;
            } 
        }

        private void btnAddVideo_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddVideo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveVideo_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveVideo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnAddVideo_MouseLeave(object sender, EventArgs e)
        {
            btnAddVideo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveVideo_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveVideo.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void lstVideo_DoubleClick(object sender, EventArgs e)
        {
            openFileLocationToolStripMenuItem_Click(sender, e);
        }   
    }
}
