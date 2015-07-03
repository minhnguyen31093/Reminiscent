using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml;
using System.Reflection; // Assembly
using System.IO;

namespace Reminiscent
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
        }

        Assembly myAssembly = Assembly.GetExecutingAssembly();
        string strCustom = "";
        int iFlag = 0;

        #region Export

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cbxSelectAll.Checked == false) // Không xuất toàn bộ dữ liệu
            {
                iFlag = 1;

                if (cbxAccount.Checked)
                    strCustom += "Account ";
                if (cbxClock.Checked)
                    strCustom += "Alarm AlarmMusic ";
                if (cbxDictionary.Checked)
                    strCustom += "Dictionary ";
                if (cbxFavorite.Checked)
                    strCustom += "FavoriteFiles FavoriteFolders FavoriteImages FavoriteSV FavoriteWebsites ";
                if (cbxIdea.Checked)
                    strCustom += "Ideas ";
                if (cbxRecurring.Checked)
                    strCustom += "Recurring ";
                if (cbxSchedule.Checked)
                    strCustom += "Schedule ";
                if (cbxSticky.Checked)
                    strCustom += "StickyNote ";

                strCustom.Trim();
            }

            if (cbxAccount.Checked == false && cbxClock.Checked == false && cbxDictionary.Checked == false && cbxFavorite.Checked == false && cbxIdea.Checked == false && cbxRecurring.Checked == false && cbxSchedule.Checked == false && cbxSticky.Checked == false)
                MessageBox.Show("No item selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    sfd.Filter = "Zip File|*.zip";
                    sfd.Title = "Export file zip";
                    sfd.ShowDialog();

                    string strFileName = "";
                    strFileName = sfd.FileName;

                    CreateSample(strFileName, "", Application.StartupPath + "/Data");

                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Export failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CreateSample(string outPathname, string password, string folderName)
        {
            FileStream fsOut = File.Create(outPathname);
            ZipOutputStream zipStream = new ZipOutputStream(fsOut);

            zipStream.SetLevel(3); // Chọn mức độ nén từ 0 đến 9, 9 = cao nhất.

            zipStream.Password = password;  // Tùy chọn, nhập "" nếu không muốn đặt mật khẩu cho tập tin nén.

            // This setting will strip the leading part of the folder path in the entries, to make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign folderOffset = 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            if (iFlag == 0)
                CompressFolder(folderName, zipStream, folderOffset);
            else
                CompressFiles(folderName, zipStream, folderOffset);

            zipStream.IsStreamOwner = true; // Makes the Close also Close the underlying stream
            zipStream.Close();
        }

        private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string filename in files)
            {
                FileInfo fi = new FileInfo(filename);

                string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                ZipEntry newEntry = new ZipEntry(entryName);
                newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                // A password on the ZipOutputStream is required if using AES.
                //   newEntry.AESKeySize = 256;

                // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                // but the zip will be in Zip64 format which not all utilities can understand.
                //   zipStream.UseZip64 = UseZip64.Off;
                newEntry.Size = fi.Length;

                zipStream.PutNextEntry(newEntry);

                // Zip the file in buffered chunks
                // the "using" will close the stream even if an exception occurs
                byte[] buffer = new byte[4096];
                using (FileStream streamReader = File.OpenRead(filename))
                {
                    StreamUtils.Copy(streamReader, zipStream, buffer);
                }
                zipStream.CloseEntry();
            }

            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFolder(folder, zipStream, folderOffset);
            }
        }

        private void CompressFiles(string path, ZipOutputStream zipStream, int folderOffset)
        {
            string[] files = Directory.GetFiles(path);
            string strTemp = "";

            foreach (string filename in files)
            {
                if (filename.IndexOf("\\") == filename.LastIndexOf("\\")) // Đường dẫn có dạng "folder\file"
                {
                    strTemp = filename;
                    strTemp = strTemp.Substring(strTemp.IndexOf("\\") + 1);
                    //strTemp = strTemp.Substring(0, strTemp.IndexOf("."));
                    string[] strSplit = strTemp.Split('.');
                    strTemp = strSplit[0];
                }
                else // Đường dẫn có dạng "folder\...\file
                {
                    string[] strSplit = filename.Split('\\');
                    strTemp = strSplit[1];
                }

                if (strCustom.Contains(strTemp))
                {
                    FileInfo fi = new FileInfo(filename);

                    string entryName = filename.Substring(folderOffset); // Makes the name in zip based on the folder
                    entryName = ZipEntry.CleanName(entryName); // Removes drive from name and fixes slash direction
                    ZipEntry newEntry = new ZipEntry(entryName);
                    newEntry.DateTime = fi.LastWriteTime; // Note the zip format stores 2 second granularity

                    // Specifying the AESKeySize triggers AES encryption. Allowable values are 0 (off), 128 or 256.
                    // A password on the ZipOutputStream is required if using AES.
                    //   newEntry.AESKeySize = 256;

                    // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003, WinZip 8, Java, and other older code,
                    // you need to do one of the following: Specify UseZip64.Off, or set the Size.
                    // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, you do not need either,
                    // but the zip will be in Zip64 format which not all utilities can understand.
                    //   zipStream.UseZip64 = UseZip64.Off;
                    newEntry.Size = fi.Length;

                    zipStream.PutNextEntry(newEntry);

                    // Zip the file in buffered chunks
                    // the "using" will close the stream even if an exception occurs
                    byte[] buffer = new byte[4096];
                    using (FileStream streamReader = File.OpenRead(filename))
                    {
                        StreamUtils.Copy(streamReader, zipStream, buffer);
                    }
                    zipStream.CloseEntry();
                }
            }

            string[] folders = Directory.GetDirectories(path);
            foreach (string folder in folders)
            {
                CompressFiles(folder, zipStream, folderOffset);
            }
        }

        #endregion

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSelectAll.Checked)
            {
                cbxAccount.Checked = true;
                cbxClock.Checked = true;
                cbxDictionary.Checked = true;
                cbxFavorite.Checked = true;
                cbxIdea.Checked = true;
                cbxRecurring.Checked = true;
                cbxSchedule.Checked = true;
                cbxSticky.Checked = true;
            }
            else
            {
                cbxAccount.Checked = false;
                cbxClock.Checked = false;
                cbxDictionary.Checked = false;
                cbxFavorite.Checked = false;
                cbxIdea.Checked = false;
                cbxRecurring.Checked = false;
                cbxSchedule.Checked = false;
                cbxSticky.Checked = false;
            }
        }

        private void frmExport_Load(object sender, EventArgs e)
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
                    int ibc11 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc11").InnerText));
                    int ibc12 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc12").InnerText));
                    int ibc13 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc13").InnerText));
                    this.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
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

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    this.Text = frmMain.Decryption(node.SelectSingleNode("Text").InnerText);

                    cbxSelectAll.Text = frmMain.Decryption(node.SelectSingleNode("cbxSelectAll").InnerText);
                    cbxRecurring.Text = frmMain.Decryption(node.SelectSingleNode("cbxRecurring").InnerText);
                    cbxDictionary.Text = frmMain.Decryption(node.SelectSingleNode("cbxDictionary").InnerText);
                    cbxIdea.Text = frmMain.Decryption(node.SelectSingleNode("cbxIdea").InnerText);
                    cbxFavorite.Text = frmMain.Decryption(node.SelectSingleNode("cbxFavorite").InnerText);
                    cbxSticky.Text = frmMain.Decryption(node.SelectSingleNode("cbxSticky").InnerText);
                    cbxSchedule.Text = frmMain.Decryption(node.SelectSingleNode("cbxSchedule").InnerText);
                    cbxClock.Text = frmMain.Decryption(node.SelectSingleNode("cbxArlarm").InnerText);
                    cbxAccount.Text = frmMain.Decryption(node.SelectSingleNode("cbxAccount").InnerText);

                    btnExport.Text = frmMain.Decryption(node.SelectSingleNode("btnExport").InnerText);
                    btnCancel.Text = frmMain.Decryption(node.SelectSingleNode("btnCancel").InnerText);

                    break;
                }
            }

            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
