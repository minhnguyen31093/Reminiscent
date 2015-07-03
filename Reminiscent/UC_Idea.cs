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
using System.Xml.Linq;
using System.Globalization;

namespace Reminiscent
{
    public partial class UC_Idea : UserControl
    {
        public UC_Idea()
        {
            InitializeComponent();
        }

        int iFlag = 0;

        public static string strRecurringID = "";
        public static string strRecurringName = "";
        public static string strRecurringDes = "";
        public static string strRecurringDate = "";

        private void UC_Idea_Load(object sender, EventArgs e)
        {
            txtName.Text = "";
            cboSize.Text = "8";
            rtxShow.Text = "";

            //edit
            rtxShow.Select(0, 0);
            //rtxShow.AppendText("some text");
            rtxShow.Select(0, 0);
            rtxShow.Clear();
            rtxShow.SetLayoutType(ExtendedRichTextBox.LayoutModes.WYSIWYG);

            dtpDate.Value = DateTime.Now;

            lvwIdeas.View = View.Details;

            LoadListView();

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
                    lblAlarmTitle.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);

                    label3.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    label1.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    label2.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);

                    btnRefresh.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnSaveAs.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnDelete.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnSave.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);

                    clDate.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    clName.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    clDes.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    break;
                }
            }
            #endregion
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            iFlag = 3;

            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            rtxShow.ReadOnly = true;

            #region Xóa một nhắc nhở

            if (lvwIdeas.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwIdeas.SelectedItems)
                {
                    strRecurringID = lvi.Tag.ToString();
                    strRecurringName = lvi.SubItems[1].Text;
                    strRecurringDes = lvi.SubItems[2].Text;
                }

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to delete item '" + strRecurringName + "'", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + "/Data/Ideas.xml");

                    foreach (XmlNode nodeIdeaList in doc.SelectNodes("Ideas/IdeaList"))
                    {
                        if (frmMain.Decryption(nodeIdeaList.SelectSingleNode("ID").InnerText) == strRecurringID)
                        {
                            if (nodeIdeaList.ChildNodes.Count > 3) // Nhiều công việc cùng một thời điểm
                            {
                                for (int i = 2; i < nodeIdeaList.ChildNodes.Count; i++)
                                {
                                    if (frmMain.Decryption(nodeIdeaList.ChildNodes[i].ChildNodes[0].InnerText) == strRecurringName && GetText(frmMain.Decryption(nodeIdeaList.ChildNodes[i].ChildNodes[1].InnerText)) == strRecurringDes)
                                    {
                                        nodeIdeaList.ChildNodes[i].ParentNode.RemoveChild(nodeIdeaList.ChildNodes[i]);
                                        i--;
                                    }
                                }
                            }
                            else
                            {
                                nodeIdeaList.ParentNode.RemoveChild(nodeIdeaList);
                            }
                        }
                    }

                    doc.Save(Application.StartupPath + "/Data/Ideas.xml");

                    txtName.Text = "";
                    rtxShow.Text = "";
                    dtpDate.Value = DateTime.Now;
                }
            }
            else
                MessageBox.Show("No item selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            #endregion

            LoadListView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            rtxShow.ReadOnly = true;

            string s = "";

            if (txtName.Text.Trim() != "" && rtxShow.Text.Trim() != "")
            {
                int iTemp2 = 0;

                if (iFlag == 1) // New
                {
                    #region Tạo ý tưởng mới

                    // Ghi vào tập tin Ideas.xml
                    if (!File.Exists(Application.StartupPath + "/Data/Ideas.xml")) // Chưa tồn tại tập tin Ideas.xml
                    {
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Ideas.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented; //Xuống dòng
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Ideas");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                    }

                    // Xử lý tập tin Ideas.xml
                    int iMax = 0;
                    int iTemp = 0;

                    XmlDocument xd = new XmlDocument();
                    xd.Load(Application.StartupPath + "/Data/Ideas.xml");

                    XmlElement ele = xd.DocumentElement;
                    XmlNodeList Idea = ele.GetElementsByTagName("IdeaList");

                    if (Idea.Count > 0) // Tồn tại ít nhất 1 công việc trong tập tin Ideas.xml
                    {
                        for (int i = 0; i < Idea.Count; i++)
                        {
                            if (dtpDate.Text == frmMain.Decryption(Idea[i].ChildNodes[1].InnerText)) // Cùng thời gian, chèn thêm vào content
                            {
                                iTemp = 1;

                                // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                                {
                                    if (frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && GetText(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText)) == rtxShow.Text)
                                    {
                                        iTemp2 = 1;
                                        MessageBox.Show("A idea with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }

                                if (iTemp2 == 1)
                                {
                                    btnRefresh_Click(sender, e);
                                    break;
                                }

                                if (iTemp2 != 1)
                                {
                                    XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                    XmlNode nodeName = xd.CreateElement("Name");
                                    nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                    rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                    StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                    s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                    sr.Close();

                                    s = s.Replace("\0", "");

                                    XmlNode nodeDes = xd.CreateElement("Description");
                                    nodeDes.InnerText = frmMain.Encryption(s);

                                    nodeContent.AppendChild(nodeName);
                                    nodeContent.AppendChild(nodeDes);

                                    Idea[i].AppendChild(nodeContent);
                                }
                            }
                        }
                        if (iTemp != 1) // Không trùng thời gian, lưu thành một công việc mới
                        {
                            XmlNode nodeIdeaList = xd.CreateNode(XmlNodeType.Element, "IdeaList", null);

                            XmlNode nodeID = xd.CreateElement("ID");

                            if (Idea.Count < 1)
                            {
                                nodeID.InnerText = frmMain.Encryption("0");
                            }
                            else
                            {
                                for (int i = 0; i < Idea.Count; i++)
                                {
                                    if (iMax < int.Parse(frmMain.Decryption(Idea[i].ChildNodes[0].InnerText)))
                                        iMax = int.Parse(frmMain.Decryption(Idea[i].ChildNodes[0].InnerText));
                                }
                                nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                            }

                            XmlNode nodeDate = xd.CreateElement("Date");
                            nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                            XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                            XmlNode nodeName = xd.CreateElement("Name");
                            nodeName.InnerText = frmMain.Encryption(txtName.Text);

                            rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                            StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                            s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                            sr.Close();

                            s = s.Replace("\0", "");

                            XmlNode nodeDes = xd.CreateElement("Description");
                            nodeDes.InnerText = frmMain.Encryption(s);

                            nodeContent.AppendChild(nodeName);
                            nodeContent.AppendChild(nodeDes);

                            nodeIdeaList.AppendChild(nodeID);
                            nodeIdeaList.AppendChild(nodeDate);
                            nodeIdeaList.AppendChild(nodeContent);

                            xd.DocumentElement.AppendChild(nodeIdeaList);
                        }
                    }
                    else // Không có công việc nào trong tập tin Ideas.xml
                    {
                        XmlNode nodeIdeaList = xd.CreateNode(XmlNodeType.Element, "IdeaList", null);

                        XmlNode nodeID = xd.CreateElement("ID");

                        nodeID.InnerText = frmMain.Encryption("0");

                        XmlNode nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                        XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                        XmlNode nodeName = xd.CreateElement("Name");
                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                        rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                        StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                        s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                        sr.Close();

                        s = s.Replace("\0", ""); // Sửa lỗi hiển thị ký tự lạ "&#x0" trong file xml

                        XmlNode nodeDes = xd.CreateElement("Description");
                        nodeDes.InnerText = frmMain.Encryption(s);

                        nodeContent.AppendChild(nodeName);
                        nodeContent.AppendChild(nodeDes);

                        nodeIdeaList.AppendChild(nodeID);
                        nodeIdeaList.AppendChild(nodeDate);
                        nodeIdeaList.AppendChild(nodeContent);

                        xd.DocumentElement.AppendChild(nodeIdeaList);
                    }

                    if (iTemp2 != 1)
                    {
                        xd.Save(Application.StartupPath + "/Data/Ideas.xml");
                    }

                    #endregion
                }
                else
                    if (iFlag == 2) // Edit
                    {
                        #region Sửa một ý tưởng

                        XmlDocument doc = new XmlDocument();
                        doc.Load(Application.StartupPath + "/Data/Ideas.xml");

                        XmlElement ele = doc.DocumentElement;
                        XmlNodeList Idea = ele.GetElementsByTagName("IdeaList");
                        int iFlag3 = 0; // Đánh dấu ý tưởng vừa edit, thời gian có thay đổi không

                        for (int i = 0; i < Idea.Count; i++)
                        {
                            if (frmMain.Decryption(Idea[i].ChildNodes[0].InnerText) == strRecurringID)
                            {
                                // Kiểm tra ý tưởng vừa edit có cùng thời gian với các ý tưởng khác hay không
                                for (int ii = 0; ii < Idea.Count; ii++)
                                {
                                    if (frmMain.Decryption(Idea[ii].ChildNodes[0].InnerText) != strRecurringID)
                                    {
                                        if (frmMain.Decryption(Idea[ii].ChildNodes[1].InnerText) == dtpDate.Text)
                                        {
                                            iFlag3 = 1;

                                            #region Thêm vào mục content

                                            XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                            rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                            StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                            s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                            sr.Close();

                                            s = s.Replace("\0", "");

                                            XmlNode nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(s);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);

                                            Idea[ii].AppendChild(nodeContent);

                                            #endregion

                                            #region Xóa ý tưởng trước khi edit

                                            foreach (XmlNode nodeRemove in doc.SelectNodes("Ideas/IdeaList"))
                                            {
                                                if (frmMain.Decryption(nodeRemove.SelectSingleNode("ID").InnerText) == strRecurringID)
                                                {
                                                    if (nodeRemove.ChildNodes.Count > 3) // Nhiều ý tưởng cùng một thời điểm
                                                    {
                                                        for (int k = 2; k < nodeRemove.ChildNodes.Count; k++)
                                                        {
                                                            if (frmMain.Decryption(nodeRemove.ChildNodes[k].ChildNodes[0].InnerText) == strRecurringName && GetText(frmMain.Decryption(nodeRemove.ChildNodes[k].ChildNodes[1].InnerText)) == strRecurringDes)
                                                            {
                                                                nodeRemove.ChildNodes[k].ParentNode.RemoveChild(nodeRemove.ChildNodes[k]);
                                                                k--;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        nodeRemove.ParentNode.RemoveChild(nodeRemove);
                                                    }
                                                }
                                            }

                                            #endregion
                                        }
                                    }
                                }

                                if (iFlag3 != 1)
                                {
                                    if (frmMain.Decryption(Idea[i].ChildNodes[1].InnerText) != dtpDate.Text) // Ngày bị thay đổi
                                    {
                                        if (Idea[i].ChildNodes.Count > 3) // Nhiều ý tưởng cùng một thời điểm
                                        {
                                            for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                                            {
                                                if (frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText) == strRecurringName &&  GetText(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText)) == strRecurringDes)
                                                {
                                                    #region Tạo một ý tưởng mới

                                                    int iMax = 0;
                                                    int iTemp3 = 0;
                                                    int iTemp4 = 0; // Name already exists

                                                    for (int k = 0; k < Idea.Count; k++)
                                                    {
                                                        if (dtpDate.Text == frmMain.Decryption(Idea[k].ChildNodes[1].InnerText)) // Cùng thời gian, chèn thêm vào content
                                                        {
                                                            iTemp3 = 1;

                                                            // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                                            for (int l = 2; l < Idea[k].ChildNodes.Count; l++)
                                                            {
                                                                if (frmMain.Decryption(Idea[k].ChildNodes[l].ChildNodes[0].InnerText) == txtName.Text && GetText(frmMain.Decryption(Idea[k].ChildNodes[l].ChildNodes[1].InnerText)) == rtxShow.Text)
                                                                {
                                                                    iTemp4 = 1;
                                                                    MessageBox.Show("A ideas with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                    break;
                                                                }
                                                            }

                                                            if (iTemp4 != 1)
                                                            {
                                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                XmlNode nodeName = doc.CreateElement("Name");
                                                                nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                                                rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                                                StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                                                s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                                                sr.Close();

                                                                s = s.Replace("\0", "");

                                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                                nodeDes.InnerText = frmMain.Encryption(s);

                                                                nodeContent.AppendChild(nodeName);
                                                                nodeContent.AppendChild(nodeDes);

                                                                Idea[k].AppendChild(nodeContent);
                                                            }
                                                        }
                                                    }

                                                    if (iTemp3 != 1) // Không trùng thời gian, lưu thành một công việc mới
                                                    {
                                                        XmlNode nodeIdeaList = doc.CreateNode(XmlNodeType.Element, "IdeaList", null);

                                                        XmlNode nodeID = doc.CreateElement("ID");

                                                        if (Idea.Count < 1)
                                                        {
                                                            nodeID.InnerText = frmMain.Encryption("0");
                                                        }
                                                        else
                                                        {
                                                            for (int m = 0; m < Idea.Count; m++)
                                                            {
                                                                if (iMax < int.Parse(Idea[m].ChildNodes[0].InnerText))
                                                                    iMax = int.Parse(Idea[m].ChildNodes[0].InnerText);
                                                            }
                                                            nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                                                        }

                                                        XmlNode nodeDate = doc.CreateElement("Date");
                                                        nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                                                        XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                        XmlNode nodeName = doc.CreateElement("Name");
                                                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                                        rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                                        StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                                        s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                                        sr.Close();

                                                        s = s.Replace("\0", "");

                                                        XmlNode nodeDes = doc.CreateElement("Description");
                                                        nodeDes.InnerText = frmMain.Encryption(s);

                                                        nodeContent.AppendChild(nodeName);
                                                        nodeContent.AppendChild(nodeDes);

                                                        nodeIdeaList.AppendChild(nodeID);
                                                        nodeIdeaList.AppendChild(nodeDate);
                                                        nodeIdeaList.AppendChild(nodeContent);

                                                        doc.DocumentElement.AppendChild(nodeIdeaList);
                                                    }

                                                    #endregion

                                                    #region Xóa ý tưởng cũ

                                                    foreach (XmlNode nodeIdeaList in doc.SelectNodes("Ideas/IdeaList"))
                                                    {
                                                        if (frmMain.Decryption(nodeIdeaList.SelectSingleNode("ID").InnerText) == strRecurringID)
                                                        {
                                                            if (nodeIdeaList.ChildNodes.Count > 3) // Nhiều công việc cùng một thời điểm
                                                            {
                                                                for (int k = 2; k < nodeIdeaList.ChildNodes.Count; k++)
                                                                {
                                                                    if (frmMain.Decryption(nodeIdeaList.ChildNodes[k].ChildNodes[0].InnerText) == strRecurringName && GetText(frmMain.Decryption(nodeIdeaList.ChildNodes[k].ChildNodes[1].InnerText)) == strRecurringDes)
                                                                    {
                                                                        nodeIdeaList.ChildNodes[k].ParentNode.RemoveChild(nodeIdeaList.ChildNodes[k]);
                                                                        k--;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                    #endregion
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Idea[i].ChildNodes[1].InnerText = frmMain.Encryption(dtpDate.Text);
                                            Idea[i].ChildNodes[2].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text);

                                            rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                            StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                            s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                            sr.Close();

                                            s = s.Replace("\0", "");

                                            Idea[i].ChildNodes[2].ChildNodes[1].InnerText = frmMain.Encryption(s);
                                        }
                                    }
                                    else // Không thay đổi ngày giờ
                                    {
                                        if (Idea[i].ChildNodes.Count > 3) // Nhiều công việc cùng một thời điểm
                                        {
                                            for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                                            {
                                                if (frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText) == strRecurringName && GetText(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText)) == strRecurringDes)
                                                {
                                                    Idea[i].ChildNodes[j].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text); // Name

                                                    rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                                    StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                                    s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                                    sr.Close();

                                                    s = s.Replace("\0", "");

                                                    Idea[i].ChildNodes[j].ChildNodes[1].InnerText = frmMain.Encryption(s); // Description
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Idea[i].ChildNodes[2].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text); // Name

                                            rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                            StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                            s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                            sr.Close();

                                            s = s.Replace("\0", "");

                                            Idea[i].ChildNodes[2].ChildNodes[1].InnerText = frmMain.Encryption(s); // Description
                                        }
                                    }
                                }
                            }
                        }

                        doc.Save(Application.StartupPath + "/Data/Ideas.xml");

                        #endregion
                    }

                LoadListView();

                txtName.Text = "";
                rtxShow.Text = "";
            }
            else
            {
                MessageBox.Show("Name or description not empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (iFlag == 1)
                    btnRefresh_Click(sender, e);
                else
                {
                    dtpDate.Enabled = false;
                    txtName.ReadOnly = true;
                    rtxShow.ReadOnly = true;
                }
            }

        }

        private void LoadListView()
        {
            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            rtxShow.ReadOnly = true;

            Sort();

            lvwIdeas.Items.Clear();

            if (File.Exists(Application.StartupPath + "/Data/Ideas.xml"))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Ideas.xml");
                    XmlElement root = xmlDoc.DocumentElement;
                    XmlNodeList Idea = root.GetElementsByTagName("IdeaList");

                    for (int i = 0; i < Idea.Count; i++)
                    {
                        if (Idea[i].ChildNodes.Count > 3) // Nhiều ý tưởng chung một thời điểm
                        {
                            for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                            {
                                ListViewItem lvi = new ListViewItem();

                                lvi.Tag = frmMain.Decryption(Idea[i].ChildNodes[0].InnerText); // ID
                                lvi.Text = frmMain.Decryption(Idea[i].ChildNodes[1].InnerText); // Date
                                lvi.SubItems.Add(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText)); // Name
                                lvi.SubItems.Add(GetText(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText))); // Description

                                lvwIdeas.Items.Add(lvi);
                            }
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem();

                            lvi.Tag = frmMain.Decryption(Idea[i].ChildNodes[0].InnerText); // ID
                            lvi.Text = frmMain.Decryption(Idea[i].ChildNodes[1].InnerText); // Date
                            lvi.SubItems.Add(frmMain.Decryption(Idea[i].ChildNodes[2].ChildNodes[0].InnerText)); // Name
                            lvi.SubItems.Add(GetText(frmMain.Decryption(Idea[i].ChildNodes[2].ChildNodes[1].InnerText))); // Description

                            lvwIdeas.Items.Add(lvi);
                        }
                    }

                }
                catch
                {
                    File.Delete(Application.StartupPath + "/Data/Ideas.xml.bk");
                    File.Copy(Application.StartupPath + "/Data/Ideas.xml", Application.StartupPath + "/Data/Ideas.xml.bk");
                    File.Delete(Application.StartupPath + "/Data/Ideas.xml");
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Ideas.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    //Create XML
                    writer.WriteStartDocument();
                    //Create Root
                    writer.WriteStartElement("Ideas");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    MessageBox.Show("Your Ideas database have been corrupted! \n\n It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void Sort()
        {
            if (File.Exists(Application.StartupPath + "/Data/Ideas.xml"))
            {
                // Sắp xếp lại thứ tự công việc trong tập tin Ideas.xml
                //XmlDocument doc = new XmlDocument();
                //doc.Load(Application.StartupPath + "/Data/Ideas.xml");

                //XmlElement ele = doc.DocumentElement;
                //XmlNodeList Idea = ele.GetElementsByTagName("IdeaList");

                //for (int i = 0; i < Idea.Count; i++)
                //{ 
                //    if (i+1 < Idea.Count)
                //        if (DateTime.Parse(Idea[i].ChildNodes[1].InnerText) > DateTime.Parse(Idea[i+1].ChildNodes[1].InnerText))
                //        {
                            
                //        }
                //}

                XElement root = XElement.Load(Application.StartupPath + "/Data/Ideas.xml");
                var orderedtabs = root.Elements("IdeaList")
                                      .OrderBy(xtab => DateTime.ParseExact(frmMain.Decryption(xtab.Element("Date").Value.ToString()), "d/M/yyyy", CultureInfo.InvariantCulture))
                                      .ToArray();
                root.RemoveAll();
                foreach (XElement tab in orderedtabs)
                    root.Add(tab);
                root.Save(Application.StartupPath + "/Data/Ideas.xml");
            }
        }

        private void lvwIdeas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwIdeas.SelectedItems.Count > 0)
            {
                iFlag = 2; // Edit

                dtpDate.Enabled = true;
                txtName.ReadOnly = false;
                rtxShow.ReadOnly = false;

                dtpDate.Text = DateTime.ParseExact(lvwIdeas.SelectedItems[0].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                txtName.Text = lvwIdeas.SelectedItems[0].SubItems[1].Text;

                XmlDocument xd = new XmlDocument();
                xd.Load(Application.StartupPath + "/Data/Ideas.xml");

                XmlElement ele = xd.DocumentElement;
                XmlNodeList Idea = ele.GetElementsByTagName("IdeaList");

                for (int i = 0; i < Idea.Count; i++)
                {
                    if (frmMain.Decryption(Idea[i].ChildNodes[0].InnerText) == lvwIdeas.SelectedItems[0].Tag.ToString())
                    {
                        if (Idea[i].ChildNodes.Count < 4)
                        {
                            StreamWriter sw = new StreamWriter("Ideas.rtf");
                            sw.Write(frmMain.Decryption(Idea[i].ChildNodes[2].ChildNodes[1].InnerText));
                            sw.Close();
                        }
                        else // Nhiều ý tưởng chung một thời điểm
                        {
                            for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                            {
                                if (frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText) == lvwIdeas.SelectedItems[0].SubItems[1].Text)
                                {
                                    StreamWriter sw = new StreamWriter("Ideas.rtf");
                                    sw.Write(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText));
                                    sw.Close();
                                    break;
                                }
                            }
                        }
                        try
                        {
                            rtxShow.LoadFile("Ideas.rtf");
                        }
                        catch
                        {
                            MessageBox.Show("Description is corrupted!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                strRecurringID = lvwIdeas.SelectedItems[0].Tag.ToString();
                strRecurringDate = lvwIdeas.SelectedItems[0].Text;
                strRecurringName = lvwIdeas.SelectedItems[0].SubItems[1].Text;
                strRecurringDes = rtxShow.Text;
            }
            else
            {
                dtpDate.Enabled = false;
                txtName.ReadOnly = true;
                rtxShow.ReadOnly = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            iFlag = 1;

            dtpDate.Enabled = true;
            txtName.ReadOnly = false;
            rtxShow.ReadOnly = false;

            dtpDate.Value = DateTime.Now;
            txtName.Text = "";
            rtxShow.Text = "";
        }

        //internal string GetText(string text) // Lấy nội dung trong file rtf
        //{
        //    using (RichTextBox rtb = new RichTextBox())
        //    {
        //        rtb.Rtf = text;
        //        return rtb.Text;
        //    }
        //}

        public string GetText(string str)
        {
            StreamWriter sw = new StreamWriter("Ideas.rtf");
            sw.Write(str);
            sw.Close();

            RichTextBox rtx = new RichTextBox();
            rtx.LoadFile("Ideas.rtf");

            return rtx.Text;
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
            catch (Exception)
            { }
        }
        #endregion

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && rtxShow.Text.Trim() != "")
            {
                #region Tạo ý tưởng mới

                // Ghi vào tập tin Ideas.xml
                if (!File.Exists(Application.StartupPath + "/Data/Ideas.xml")) // Chưa tồn tại tập tin Ideas.xml
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Ideas.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented; //Xuống dòng
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Ideas");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                // Xử lý tập tin Ideas.xml
                int iMax = 0;
                int iTemp = 0;
                int iTemp2 = 0;
                string s = "";

                XmlDocument xd = new XmlDocument();
                xd.Load(Application.StartupPath + "/Data/Ideas.xml");

                XmlElement ele = xd.DocumentElement;
                XmlNodeList Idea = ele.GetElementsByTagName("IdeaList");

                if (Idea.Count > 0) // Tồn tại ít nhất 1 công việc trong tập tin Ideas.xml
                {
                    for (int i = 0; i < Idea.Count; i++)
                    {
                        if (dtpDate.Text == frmMain.Decryption(Idea[i].ChildNodes[1].InnerText)) // Cùng thời gian, chèn thêm vào content
                        {
                            iTemp = 1;

                            // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                            for (int j = 2; j < Idea[i].ChildNodes.Count; j++)
                            {
                                if (frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && GetText(frmMain.Decryption(Idea[i].ChildNodes[j].ChildNodes[1].InnerText)) == rtxShow.Text)
                                {
                                    iTemp2 = 1;
                                    MessageBox.Show("A idea with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    txtName.ReadOnly = false;
                                    rtxShow.ReadOnly = false;
                                    dtpDate.Enabled = true;

                                    break;
                                }
                            }

                            if (iTemp2 == 1)
                            {
                                break;
                            }

                            if (iTemp2 != 1)
                            {
                                XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                XmlNode nodeName = xd.CreateElement("Name");
                                nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                                StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                                s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                                sr.Close();

                                s = s.Replace("\0", "");

                                XmlNode nodeDes = xd.CreateElement("Description");
                                nodeDes.InnerText = frmMain.Encryption(s);

                                nodeContent.AppendChild(nodeName);
                                nodeContent.AppendChild(nodeDes);

                                Idea[i].AppendChild(nodeContent);
                            }
                        }
                    }
                    if (iTemp != 1) // Không trùng thời gian, lưu thành một công việc mới
                    {
                        XmlNode nodeIdeaList = xd.CreateNode(XmlNodeType.Element, "IdeaList", null);

                        XmlNode nodeID = xd.CreateElement("ID");

                        if (Idea.Count < 1)
                        {
                            nodeID.InnerText = frmMain.Encryption("0");
                        }
                        else
                        {
                            for (int i = 0; i < Idea.Count; i++)
                            {
                                if (iMax < int.Parse(Idea[i].ChildNodes[0].InnerText))
                                    iMax = int.Parse(Idea[i].ChildNodes[0].InnerText);
                            }
                            nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                        }

                        XmlNode nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                        XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                        XmlNode nodeName = xd.CreateElement("Name");
                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                        rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                        StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                        s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                        sr.Close();

                        s = s.Replace("\0", "");

                        XmlNode nodeDes = xd.CreateElement("Description");
                        nodeDes.InnerText = frmMain.Encryption(s);

                        nodeContent.AppendChild(nodeName);
                        nodeContent.AppendChild(nodeDes);

                        nodeIdeaList.AppendChild(nodeID);
                        nodeIdeaList.AppendChild(nodeDate);
                        nodeIdeaList.AppendChild(nodeContent);

                        xd.DocumentElement.AppendChild(nodeIdeaList);
                    }
                }
                else // Không có công việc nào trong tập tin Ideas.xml
                {
                    XmlNode nodeIdeaList = xd.CreateNode(XmlNodeType.Element, "IdeaList", null);

                    XmlNode nodeID = xd.CreateElement("ID");

                    nodeID.InnerText = frmMain.Encryption("0");

                    XmlNode nodeDate = xd.CreateElement("Date");
                    nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                    XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                    XmlNode nodeName = xd.CreateElement("Name");
                    nodeName.InnerText = frmMain.Encryption(txtName.Text);

                    rtxShow.SaveFile("Ideas.rtf", RichTextBoxStreamType.RichText);

                    StreamReader sr = new StreamReader("Ideas.rtf", Encoding.Default); // Mở file rtf

                    s = sr.ReadToEnd(); // Đọc hết nội dung trong file rtf
                    sr.Close();

                    s = s.Replace("\0", ""); // Sửa lỗi hiển thị ký tự lạ "&#x0" trong file xml

                    XmlNode nodeDes = xd.CreateElement("Description");
                    nodeDes.InnerText = frmMain.Encryption(s);

                    nodeContent.AppendChild(nodeName);
                    nodeContent.AppendChild(nodeDes);

                    nodeIdeaList.AppendChild(nodeID);
                    nodeIdeaList.AppendChild(nodeDate);
                    nodeIdeaList.AppendChild(nodeContent);

                    xd.DocumentElement.AppendChild(nodeIdeaList);
                }

                if (iTemp2 != 1)
                {
                    txtName.Text = "";
                    rtxShow.Text = "";

                    txtName.ReadOnly = true;
                    rtxShow.ReadOnly = true;
                    dtpDate.Enabled = false;

                    xd.Save(Application.StartupPath + "/Data/Ideas.xml");

                    LoadListView();
                }

                #endregion
            }
            else
            {
                MessageBox.Show("Name or description not empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.ReadOnly = false;
                rtxShow.ReadOnly = false;
                dtpDate.Enabled = true;
            }
        }

        internal void Search(string strSearch, string strBy)
        {
            if (lvwIdeas.Items.Count > 0)
            {
                for (int i = frmMain.iSearch; i < lvwIdeas.Items.Count; i++)
                {
                    #region Tìm theo tên

                    if (strBy == "Name")
                    {
                        if (lvwIdeas.Items[i].SubItems[1].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lvwIdeas.Focus();
                            lvwIdeas.EnsureVisible(i);
                            lvwIdeas.Items[i].Selected = true;

                            if (i == lvwIdeas.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }

                        if (i == lvwIdeas.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }

                    #endregion

                    else

                        #region Tìm theo ngày

                        if (strBy == "Date")
                        {
                            if (lvwIdeas.Items[i].SubItems[0].Text.ToLower().Contains(strSearch.ToLower()))
                            {
                                lvwIdeas.Focus();
                                lvwIdeas.EnsureVisible(i);
                                lvwIdeas.Items[i].Selected = true;

                                if (i == lvwIdeas.Items.Count - 1)
                                {
                                    frmMain.iSearch = 0;
                                    i = 0;
                                }
                                else
                                    frmMain.iSearch = i + 1;
                                break;
                            }

                            if (i == lvwIdeas.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                                break;
                            }
                        }

                        #endregion

                        else

                            #region Tìm theo nội dung mô tả

                            if (strBy == "Description")
                            {
                                if (lvwIdeas.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                                {
                                    lvwIdeas.Focus();
                                    lvwIdeas.EnsureVisible(i);
                                    lvwIdeas.Items[i].Selected = true;

                                    if (i == lvwIdeas.Items.Count - 1)
                                    {
                                        frmMain.iSearch = 0;
                                        i = 0;
                                    }
                                    else
                                        frmMain.iSearch = i + 1;
                                    break;
                                }

                                if (i == lvwIdeas.Items.Count - 1)
                                {
                                    frmMain.iSearch = 0;
                                    i = 0;
                                    break;
                                }
                            }

                            #endregion

                }
            }
        }
    }
}
