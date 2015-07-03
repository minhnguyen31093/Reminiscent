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
    public partial class UC_FavoriteAudios : UserControl
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

        public UC_FavoriteAudios()
        {
            InitializeComponent();
        }

        int iIDAudio = -1;

        private void UC_FavoriteAudios_Load(object sender, EventArgs e)
        {
            LoadListAudio();

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
                    colIDAudio.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colNameAudio.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colLocationAudio.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);

                    btnAddAudio.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnRemoveAudio.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);

                    openFileLocationToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    copyToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    deleteToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item3").InnerText);
                    propertiesToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item4").InnerText);

                    break;
                }
            }
            #endregion
        }

        private void UC_FavoriteAudios_Leave(object sender, EventArgs e)
        {
            WMPAudioPlayer.Ctlcontrols.pause();
        }

        void LoadListAudio()
        {
            lstAudio.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/FavoriteAudios.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteAudios.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Audios = root.GetElementsByTagName("Audios");

                for (int i = 0; i < Audios.Count; i++)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = frmMain.Decryption(Audios[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Audios[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Audios[i].ChildNodes[2].InnerText));
                        if (!File.Exists(frmMain.Decryption(Audios[i].ChildNodes[2].InnerText)))
                            lvi.BackColor = Color.LemonChiffon;
                        lstAudio.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("FavoriteAudios.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/FavoriteAudios.xml", "FavoriteAudios.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/FavoriteAudios.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteAudios.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Favorite");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Favorite Audios database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }

        private void lstAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAudio.SelectedItems != null)
            {
                WMPAudioPlayer.Ctlcontrols.stop();
                foreach (ListViewItem lvi in lstAudio.SelectedItems)
                {
                    iIDAudio = Convert.ToInt32(lvi.Text);
                    if (File.Exists(lvi.SubItems[2].Text))
                    {
                        WMPAudioPlayer.URL = lvi.SubItems[2].Text;
                        WMPAudioPlayer.Ctlcontrols.play();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show(lvi.SubItems[1].Text + " not exist!\n\nDo you want to remove it from list?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            btnRemoveAudio_Click(sender, e);
                        }
                        //LoadListAudio();
                    }
                    break;
                }
            }
        }

        private void btnAddAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenAudio = new OpenFileDialog();
            OpenAudio.Filter = "Audio Files |*.aac;*.midi;*.mp4;*.mp3;*.m4a;*.wav;*.wma|All Files |*.*";
            DialogResult AudioResult = OpenAudio.ShowDialog();
            if (AudioResult == DialogResult.OK)
            {
                if (!File.Exists(Application.StartupPath + "/Data/FavoriteAudios.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/FavoriteAudios.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Favorite");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteAudios.xml");

                XmlNode nodeImages = xmlDoc.CreateNode(XmlNodeType.Element, "Audios", null);

                XmlNode nodeID = xmlDoc.CreateElement("ID");
                if (lstAudio.Items.Count > 0)
                {
                    int iMax = 0;
                    foreach (ListViewItem items in lstAudio.Items)
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
                nodeName.InnerText = frmMain.Encryption(OpenAudio.SafeFileName.Substring(0, OpenAudio.SafeFileName.LastIndexOf('.')));

                XmlNode nodeLocation = xmlDoc.CreateElement("Location");
                nodeLocation.InnerText = frmMain.Encryption(OpenAudio.FileName);

                nodeImages.AppendChild(nodeID);
                nodeImages.AppendChild(nodeName);
                nodeImages.AppendChild(nodeLocation);

                xmlDoc.DocumentElement.AppendChild(nodeImages);
                xmlDoc.Save(Application.StartupPath + "/Data/FavoriteAudios.xml");

                LoadListAudio();
            }
        }

        private void btnRemoveAudio_Click(object sender, EventArgs e)
        {
            if (iIDAudio > -1)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to Remove?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteAudios.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteAudios.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Audios"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDAudio.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteAudios.xml");

                        btnRemoveAudio.Enabled = false;
                        LoadListAudio();
                    }
                }
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstAudio.SelectedItems)
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
            if (File.Exists(Application.StartupPath + "/Data/FavoriteAudios.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/FavoriteAudios.xml");

                foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Audios"))
                {
                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDAudio.ToString())
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
            if (iIDAudio > -1)
            {
                WMPAudioPlayer.Ctlcontrols.stop();
                WMPAudioPlayer.URL = "";
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/FavoriteAudios.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/FavoriteAudios.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Favorite/Audios"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iIDAudio.ToString())
                            {
                                if (File.Exists(frmMain.Decryption(node.SelectSingleNode("Location").InnerText)))
                                {
                                    File.Delete(frmMain.Decryption(node.SelectSingleNode("Location").InnerText));
                                }
                                node.ParentNode.RemoveChild(node);
                                break;
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/FavoriteAudios.xml");

                        LoadListAudio();
                    }
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lstAudio.SelectedItems)
            {
                if(File.Exists(lvi.SubItems[2].Text))
                    ShowFileProperties(lvi.SubItems[2].Text);
                break;
            } 
        }

        #region Hover
        private void btnAddAudio_MouseMove(object sender, MouseEventArgs e)
        {
            btnAddAudio.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnRemoveAudio_MouseMove(object sender, MouseEventArgs e)
        {
            btnRemoveAudio.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnAddAudio_MouseLeave(object sender, EventArgs e)
        {
            btnAddAudio.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnRemoveAudio_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveAudio.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion

        private void lstAudio_DoubleClick(object sender, EventArgs e)
        {
            openFileLocationToolStripMenuItem_Click(sender, e);
        }
    }
}
