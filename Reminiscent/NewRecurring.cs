using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

namespace Reminiscent
{
    public partial class frmNewRecurring : Form
    {
        public static string strFlag = "";

        public frmNewRecurring()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            UC_Recurring.Sort();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string strTaskName = "";
                string strDescription = "";
                string strDate = "";
                string strTime = "";
                string strRepeat = "";

                if (txtTaskName.Text != "" && txtDescription.Text != "")
                {
                    if (dtpDate.Value.Day == DateTime.Now.Day && dtpDate.Value.Month == DateTime.Now.Month && dtpDate.Value.Year == DateTime.Now.Year && dtpTime.Value < DateTime.Now)
                    {
                            MessageBox.Show("Invalid DateTime!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (strFlag == "New")
                        {
                            string Hour = dtpTime.Value.Hour.ToString();
                            string Minute = dtpTime.Value.Minute.ToString();

                            strTaskName = txtTaskName.Text;
                            strDate = dtpDate.Text;
                            strDescription = txtDescription.Text;
                            if (dtpTime.Value.ToString() != "")
                            {
                                if (dtpTime.Value.Hour < 10)
                                {
                                    Hour = "0" + dtpTime.Value.Hour.ToString();
                                }

                                if (dtpTime.Value.Minute < 10)
                                {
                                    Minute = "0" + dtpTime.Value.Minute.ToString();
                                }
                                strTime = Hour + ":" + Minute;
                            }
                            if (cbxRepeat.SelectedIndex != -1)
                                strRepeat = cbxRepeat.Text;

                            #region Tạo 1 nhắc nhở định kỳ
                            // Ghi vào tập tin Recurring.xml
                            if (!File.Exists("Recurring.xml")) // Chưa tồn tại tập tin Recurring.xml
                            {
                                XmlTextWriter writer = new XmlTextWriter("Recurring.xml", Encoding.UTF8);
                                writer.Formatting = Formatting.Indented; //Xuống dòng
                                writer.WriteStartDocument();
                                writer.WriteStartElement("Recurring");
                                writer.WriteEndElement();
                                writer.WriteEndDocument();
                                writer.Flush();
                                writer.Close();
                            }

                            // Xử lý tập tin Recurring.xml
                            int iMax = 0;
                            int iFlag = 0;
                            int iFlag2 = 0; // Task Name already exists
                            XmlDocument xd = new XmlDocument();
                            xd.Load("Recurring.xml");

                            XmlElement ele = xd.DocumentElement;
                            XmlNodeList Recurring = ele.GetElementsByTagName("TaskList");

                            if (Recurring.Count > 0) // Tồn tại ít nhất 1 công việc trong tập tin Recurring.xml
                            {
                                for (int i = 0; i < Recurring.Count; i++)
                                {
                                    string strHour = Recurring[i].ChildNodes[2].InnerText.Substring(0, 2);
                                    string strMinute = Recurring[i].ChildNodes[2].InnerText.Substring(3);

                                    if (dtpDate.Text == Recurring[i].ChildNodes[1].InnerText && strHour == dtpTime.Value.Hour.ToString() && strMinute == dtpTime.Value.Minute.ToString()) // Cùng thời gian, chèn thêm vào content
                                    {
                                        iFlag = 1;

                                        // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                        for (int j = 3; j < Recurring[i].ChildNodes.Count; j++)
                                        {
                                            if (Recurring[i].ChildNodes[j].ChildNodes[0].InnerText == txtTaskName.Text && Recurring[i].ChildNodes[j].ChildNodes[1].InnerText == txtDescription.Text && Recurring[i].ChildNodes[j].ChildNodes[2].InnerText == cbxRepeat.Text)
                                            {
                                                iFlag2 = 1;
                                                MessageBox.Show("A task with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                break;
                                            }
                                        }

                                        if (iFlag2 != 1)
                                        {
                                            XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = xd.CreateElement("Name");
                                            nodeName.InnerText = txtTaskName.Text;

                                            XmlNode nodeDes = xd.CreateElement("Description");
                                            nodeDes.InnerText = txtDescription.Text;

                                            XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                            nodeRepeat.InnerText = cbxRepeat.Text;

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            Recurring[i].AppendChild(nodeContent);
                                        }
                                    }
                                }

                                if (iFlag != 1) // Không trùng thời gian, lưu thành một công việc mới
                                {
                                    XmlNode nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                                    XmlNode nodeID = xd.CreateElement("ID");

                                    if (Recurring.Count < 1)
                                    {
                                        nodeID.InnerText = "0";
                                    }
                                    else
                                    {
                                        for (int i = 0; i < Recurring.Count; i++)
                                        {
                                            if (iMax < int.Parse(Recurring[i].ChildNodes[0].InnerText))
                                                iMax = int.Parse(Recurring[i].ChildNodes[0].InnerText);
                                        }
                                        nodeID.InnerText = (iMax + 1).ToString(); // Lấy ID cao nhất cộng thêm 1
                                    }

                                    XmlNode nodeDate = xd.CreateElement("Date");
                                    nodeDate.InnerText = dtpDate.Text;

                                    XmlNode nodeTime = xd.CreateElement("Time");
                                    nodeTime.InnerText = Hour + ":" + Minute;

                                    XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                    XmlNode nodeName = xd.CreateElement("Name");
                                    nodeName.InnerText = txtTaskName.Text;

                                    XmlNode nodeDes = xd.CreateElement("Description");
                                    nodeDes.InnerText = txtDescription.Text;

                                    XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                    nodeRepeat.InnerText = cbxRepeat.Text;

                                    nodeContent.AppendChild(nodeName);
                                    nodeContent.AppendChild(nodeDes);
                                    nodeContent.AppendChild(nodeRepeat);

                                    nodeTaskList.AppendChild(nodeID);
                                    nodeTaskList.AppendChild(nodeDate);
                                    nodeTaskList.AppendChild(nodeTime);
                                    nodeTaskList.AppendChild(nodeContent);

                                    xd.DocumentElement.AppendChild(nodeTaskList);
                                }
                            }
                            else // Không có công việc nào trong tập tin Recurring.xml
                            {
                                XmlNode nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                                XmlNode nodeID = xd.CreateElement("ID");

                                nodeID.InnerText = "0";

                                XmlNode nodeDate = xd.CreateElement("Date");
                                nodeDate.InnerText = dtpDate.Text;

                                XmlNode nodeTime = xd.CreateElement("Time");
                                nodeTime.InnerText = strTime;

                                XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                XmlNode nodeName = xd.CreateElement("Name");
                                nodeName.InnerText = txtTaskName.Text;

                                XmlNode nodeDes = xd.CreateElement("Description");
                                nodeDes.InnerText = txtDescription.Text;

                                XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                nodeRepeat.InnerText = cbxRepeat.Text;

                                nodeContent.AppendChild(nodeName);
                                nodeContent.AppendChild(nodeDes);
                                nodeContent.AppendChild(nodeRepeat);

                                nodeTaskList.AppendChild(nodeID);
                                nodeTaskList.AppendChild(nodeDate);
                                nodeTaskList.AppendChild(nodeTime);
                                nodeTaskList.AppendChild(nodeContent);

                                xd.DocumentElement.AppendChild(nodeTaskList);
                            }

                            if (iFlag2 != 1)
                            {
                                xd.Save("Recurring.xml");

                                DialogResult dr = new DialogResult();
                                dr = MessageBox.Show("Save successfully. Do you want to create a new recurring?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dr == DialogResult.Yes)
                                {
                                    txtTaskName.Text = "";
                                    txtDescription.Text = "";
                                    cbxRepeat.SelectedIndex = 0;
                                    dtpDate.Text = DateTime.Now.ToString();
                                }
                                else
                                {
                                    this.Close();
                                }
                            }
                        }
                        if (strFlag == "Edit")
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load("Recurring.xml");

                            XmlElement ele = doc.DocumentElement;
                            XmlNodeList TaskList = ele.GetElementsByTagName("TaskList");
                            int iFlag3 = 0;
                            string Hour = dtpTime.Value.Hour.ToString();
                            string Minute = dtpTime.Value.Minute.ToString();

                            if (dtpTime.Value.Hour < 10)
                                Hour = "0" + dtpTime.Value.Hour.ToString();
                            if (dtpTime.Value.Minute < 10)
                                Minute = "0" + dtpTime.Value.Minute.ToString();

                            for (int i = 0; i < TaskList.Count; i++)
                            {
                                if (UC_Recurring.iFlag == 1) // Form EditRecurring gọi
                                {
                                    if (TaskList[i].ChildNodes[0].InnerText == UC_Recurring.strRecurringID)
                                    {
                                        // Kiểm tra công việc vừa edit có cùng thời gian hay không
                                        for (int ii = 0; ii < TaskList.Count; ii++)
                                        {
                                            if (TaskList[ii].ChildNodes[0].InnerText != UC_Recurring.strRecurringID)
                                            {
                                                if (TaskList[ii].ChildNodes[1].InnerText == dtpDate.Text && TaskList[ii].ChildNodes[2].InnerText == Hour + ":" + Minute)
                                                {
                                                    iFlag3 = 1;

                                                    #region Thêm vào mục content

                                                    XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                    XmlNode nodeName = doc.CreateElement("Name");
                                                    nodeName.InnerText = txtTaskName.Text;

                                                    XmlNode nodeDes = doc.CreateElement("Description");
                                                    nodeDes.InnerText = txtDescription.Text;

                                                    XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                    nodeRepeat.InnerText = cbxRepeat.Text;

                                                    nodeContent.AppendChild(nodeName);
                                                    nodeContent.AppendChild(nodeDes);
                                                    nodeContent.AppendChild(nodeRepeat);

                                                    TaskList[ii].AppendChild(nodeContent);

                                                    #endregion

                                                    #region Xóa công việc trước khi edit

                                                    foreach (XmlNode nodeRemove in doc.SelectNodes("Recurring/TaskList"))
                                                    {
                                                        if (nodeRemove.SelectSingleNode("ID").InnerText == UC_Recurring.strRecurringID)
                                                        {
                                                            if (nodeRemove.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                            {
                                                                for (int k = 3; k < nodeRemove.ChildNodes.Count; k++)
                                                                {
                                                                    if (nodeRemove.ChildNodes[k].ChildNodes[0].InnerText == UC_Recurring.strRecurringName && nodeRemove.ChildNodes[k].ChildNodes[1].InnerText == UC_Recurring.strRecurringDes && nodeRemove.ChildNodes[k].ChildNodes[2].InnerText == UC_Recurring.strRecurringRepeat)
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
                                            if (TaskList[i].ChildNodes[1].InnerText != dtpDate.Text || TaskList[i].ChildNodes[2].InnerText != Hour + ":" + Minute) // Ngày hoặc giờ bị thay đổi
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (TaskList[i].ChildNodes[j].ChildNodes[0].InnerText == UC_Recurring.strRecurringName && TaskList[i].ChildNodes[j].ChildNodes[1].InnerText == UC_Recurring.strRecurringDes && TaskList[i].ChildNodes[j].ChildNodes[2].InnerText == UC_Recurring.strRecurringRepeat)
                                                        {
                                                            #region Tạo một nhắc nhở mới

                                                            int iMax = 0;
                                                            int iFlag = 0;
                                                            int iFlag2 = 0; // Task Name already exists

                                                            for (int k = 0; k < TaskList.Count; k++)
                                                            {
                                                                string strHour = TaskList[k].ChildNodes[2].InnerText.Substring(0, 2);
                                                                string strMinute = TaskList[k].ChildNodes[2].InnerText.Substring(3);

                                                                if (dtpDate.Text == TaskList[k].ChildNodes[1].InnerText && strHour == Hour && strMinute == Minute) // Cùng thời gian, chèn thêm vào content
                                                                {
                                                                    iFlag = 1;

                                                                    // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                                                    for (int l = 3; l < TaskList[k].ChildNodes.Count; l++)
                                                                    {
                                                                        if (TaskList[k].ChildNodes[l].ChildNodes[0].InnerText == txtTaskName.Text && TaskList[k].ChildNodes[l].ChildNodes[1].InnerText == txtDescription.Text && TaskList[k].ChildNodes[l].ChildNodes[2].InnerText == cbxRepeat.Text)
                                                                        {
                                                                            iFlag2 = 1;
                                                                            MessageBox.Show("A task with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            break;
                                                                        }
                                                                    }

                                                                    if (iFlag2 != 1)
                                                                    {
                                                                        XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                        XmlNode nodeName = doc.CreateElement("Name");
                                                                        nodeName.InnerText = txtTaskName.Text;

                                                                        XmlNode nodeDes = doc.CreateElement("Description");
                                                                        nodeDes.InnerText = txtDescription.Text;

                                                                        XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                        nodeRepeat.InnerText = cbxRepeat.Text;

                                                                        nodeContent.AppendChild(nodeName);
                                                                        nodeContent.AppendChild(nodeDes);
                                                                        nodeContent.AppendChild(nodeRepeat);

                                                                        TaskList[k].AppendChild(nodeContent);
                                                                    }
                                                                }
                                                            }

                                                            if (iFlag != 1) // Không trùng thời gian, lưu thành một công việc mới
                                                            {
                                                                XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                                XmlNode nodeID = doc.CreateElement("ID");

                                                                if (TaskList.Count < 1)
                                                                {
                                                                    nodeID.InnerText = "0";
                                                                }
                                                                else
                                                                {
                                                                    for (int m = 0; m < TaskList.Count; m++)
                                                                    {
                                                                        if (iMax < int.Parse(TaskList[m].ChildNodes[0].InnerText))
                                                                            iMax = int.Parse(TaskList[m].ChildNodes[0].InnerText);
                                                                    }
                                                                    nodeID.InnerText = (iMax + 1).ToString(); // Lấy ID cao nhất cộng thêm 1
                                                                }

                                                                XmlNode nodeDate = doc.CreateElement("Date");
                                                                nodeDate.InnerText = dtpDate.Text;

                                                                XmlNode nodeTime = doc.CreateElement("Time");
                                                                nodeTime.InnerText = Hour + ":" + Minute;

                                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                XmlNode nodeName = doc.CreateElement("Name");
                                                                nodeName.InnerText = txtTaskName.Text;

                                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                                nodeDes.InnerText = txtDescription.Text;

                                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                nodeRepeat.InnerText = cbxRepeat.Text;

                                                                nodeContent.AppendChild(nodeName);
                                                                nodeContent.AppendChild(nodeDes);
                                                                nodeContent.AppendChild(nodeRepeat);

                                                                nodeTaskList.AppendChild(nodeID);
                                                                nodeTaskList.AppendChild(nodeDate);
                                                                nodeTaskList.AppendChild(nodeTime);
                                                                nodeTaskList.AppendChild(nodeContent);

                                                                doc.DocumentElement.AppendChild(nodeTaskList);
                                                            }

                                                            #endregion

                                                            #region Xóa nhắc nhở cũ

                                                            foreach (XmlNode nodeTaskList in doc.SelectNodes("Recurring/TaskList"))
                                                            {
                                                                if (nodeTaskList.SelectSingleNode("ID").InnerText == UC_Recurring.strRecurringID)
                                                                {
                                                                    if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                                    {
                                                                        for (int k = 3; k < nodeTaskList.ChildNodes.Count; k++)
                                                                        {
                                                                            if (nodeTaskList.ChildNodes[k].ChildNodes[0].InnerText == UC_Recurring.strRecurringName && nodeTaskList.ChildNodes[k].ChildNodes[1].InnerText == UC_Recurring.strRecurringDes && nodeTaskList.ChildNodes[k].ChildNodes[2].InnerText == UC_Recurring.strRecurringRepeat)
                                                                            {
                                                                                nodeTaskList.ChildNodes[k].ParentNode.RemoveChild(nodeTaskList.ChildNodes[k]);
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
                                                    TaskList[i].ChildNodes[1].InnerText = dtpDate.Text;
                                                    TaskList[i].ChildNodes[2].InnerText = Hour + ":" + Minute;
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = txtTaskName.Text;
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = txtDescription.Text;
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = cbxRepeat.Text;
                                                }
                                            }
                                            else // Không thay đổi ngày giờ
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (TaskList[i].ChildNodes[j].ChildNodes[0].InnerText == UC_Recurring.strRecurringName && TaskList[i].ChildNodes[j].ChildNodes[1].InnerText == UC_Recurring.strRecurringDes && TaskList[i].ChildNodes[j].ChildNodes[2].InnerText == UC_Recurring.strRecurringRepeat)
                                                        {
                                                            TaskList[i].ChildNodes[j].ChildNodes[0].InnerText = txtTaskName.Text; // Name
                                                            TaskList[i].ChildNodes[j].ChildNodes[1].InnerText = txtDescription.Text; // Description
                                                            TaskList[i].ChildNodes[j].ChildNodes[2].InnerText = cbxRepeat.Text; // Repeat
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = txtTaskName.Text; // Name
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = txtDescription.Text; // Description
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = cbxRepeat.Text; // Repeat
                                                }
                                            }
                                        }
                                    }
                                }
                                else // Form Task Of The Day gọi
                                {
                                    if (TaskList[i].ChildNodes[0].InnerText == frmTaskOfTheDay.strRecurringID)
                                    {
                                        // Kiểm tra công việc vừa edit có cùng thời gian hay không
                                        for (int ii = 0; ii < TaskList.Count; ii++)
                                        {
                                            if (TaskList[ii].ChildNodes[0].InnerText != frmTaskOfTheDay.strRecurringID)
                                            {
                                                if (TaskList[ii].ChildNodes[1].InnerText == dtpDate.Text && TaskList[ii].ChildNodes[2].InnerText == Hour + ":" + Minute)
                                                {
                                                    iFlag3 = 1;

                                                    #region Thêm vào mục content

                                                    XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                    XmlNode nodeName = doc.CreateElement("Name");
                                                    nodeName.InnerText = txtTaskName.Text;

                                                    XmlNode nodeDes = doc.CreateElement("Description");
                                                    nodeDes.InnerText = txtDescription.Text;

                                                    XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                    nodeRepeat.InnerText = cbxRepeat.Text;

                                                    nodeContent.AppendChild(nodeName);
                                                    nodeContent.AppendChild(nodeDes);
                                                    nodeContent.AppendChild(nodeRepeat);

                                                    TaskList[ii].AppendChild(nodeContent);

                                                    #endregion

                                                    #region Xóa công việc trước khi edit

                                                    foreach (XmlNode nodeRemove in doc.SelectNodes("Recurring/TaskList"))
                                                    {
                                                        if (nodeRemove.SelectSingleNode("ID").InnerText == frmTaskOfTheDay.strRecurringID)
                                                        {
                                                            if (nodeRemove.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                            {
                                                                for (int k = 3; k < nodeRemove.ChildNodes.Count; k++)
                                                                {
                                                                    if (nodeRemove.ChildNodes[k].ChildNodes[0].InnerText == frmTaskOfTheDay.strRecurringName && nodeRemove.ChildNodes[k].ChildNodes[1].InnerText == frmTaskOfTheDay.strRecurringDes && nodeRemove.ChildNodes[k].ChildNodes[2].InnerText == frmTaskOfTheDay.strRecurringRepeat)
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
                                            if (TaskList[i].ChildNodes[1].InnerText != dtpDate.Text || TaskList[i].ChildNodes[2].InnerText != Hour + ":" + Minute) // Ngày hoặc giờ bị thay đổi
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (TaskList[i].ChildNodes[j].ChildNodes[0].InnerText == frmTaskOfTheDay.strRecurringName && TaskList[i].ChildNodes[j].ChildNodes[1].InnerText == frmTaskOfTheDay.strRecurringDes && TaskList[i].ChildNodes[j].ChildNodes[2].InnerText == frmTaskOfTheDay.strRecurringRepeat)
                                                        {
                                                            #region Tạo một nhắc nhở mới

                                                            int iMax = 0;
                                                            int iFlag = 0;
                                                            int iFlag2 = 0; // Task Name already exists

                                                            for (int k = 0; k < TaskList.Count; k++)
                                                            {
                                                                string strHour = TaskList[k].ChildNodes[2].InnerText.Substring(0, 2);
                                                                string strMinute = TaskList[k].ChildNodes[2].InnerText.Substring(3);

                                                                if (dtpDate.Text == TaskList[k].ChildNodes[1].InnerText && strHour == Hour && strMinute == Minute) // Cùng thời gian, chèn thêm vào content
                                                                {
                                                                    iFlag = 1;

                                                                    // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                                                    for (int l = 3; l < TaskList[k].ChildNodes.Count; l++)
                                                                    {
                                                                        if (TaskList[k].ChildNodes[l].ChildNodes[0].InnerText == txtTaskName.Text && TaskList[k].ChildNodes[l].ChildNodes[1].InnerText == txtDescription.Text && TaskList[k].ChildNodes[l].ChildNodes[2].InnerText == cbxRepeat.Text)
                                                                        {
                                                                            iFlag2 = 1;
                                                                            MessageBox.Show("A task with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                                            break;
                                                                        }
                                                                    }

                                                                    if (iFlag2 != 1)
                                                                    {
                                                                        XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                        XmlNode nodeName = doc.CreateElement("Name");
                                                                        nodeName.InnerText = txtTaskName.Text;

                                                                        XmlNode nodeDes = doc.CreateElement("Description");
                                                                        nodeDes.InnerText = txtDescription.Text;

                                                                        XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                        nodeRepeat.InnerText = cbxRepeat.Text;

                                                                        nodeContent.AppendChild(nodeName);
                                                                        nodeContent.AppendChild(nodeDes);
                                                                        nodeContent.AppendChild(nodeRepeat);

                                                                        TaskList[k].AppendChild(nodeContent);
                                                                    }
                                                                }
                                                            }

                                                            if (iFlag != 1) // Không trùng thời gian, lưu thành một công việc mới
                                                            {
                                                                XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                                XmlNode nodeID = doc.CreateElement("ID");

                                                                if (TaskList.Count < 1)
                                                                {
                                                                    nodeID.InnerText = "0";
                                                                }
                                                                else
                                                                {
                                                                    for (int m = 0; m < TaskList.Count; m++)
                                                                    {
                                                                        if (iMax < int.Parse(TaskList[m].ChildNodes[0].InnerText))
                                                                            iMax = int.Parse(TaskList[m].ChildNodes[0].InnerText);
                                                                    }
                                                                    nodeID.InnerText = (iMax + 1).ToString(); // Lấy ID cao nhất cộng thêm 1
                                                                }

                                                                XmlNode nodeDate = doc.CreateElement("Date");
                                                                nodeDate.InnerText = dtpDate.Text;

                                                                XmlNode nodeTime = doc.CreateElement("Time");
                                                                nodeTime.InnerText = Hour + ":" + Minute;

                                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                XmlNode nodeName = doc.CreateElement("Name");
                                                                nodeName.InnerText = txtTaskName.Text;

                                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                                nodeDes.InnerText = txtDescription.Text;

                                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                nodeRepeat.InnerText = cbxRepeat.Text;

                                                                nodeContent.AppendChild(nodeName);
                                                                nodeContent.AppendChild(nodeDes);
                                                                nodeContent.AppendChild(nodeRepeat);

                                                                nodeTaskList.AppendChild(nodeID);
                                                                nodeTaskList.AppendChild(nodeDate);
                                                                nodeTaskList.AppendChild(nodeTime);
                                                                nodeTaskList.AppendChild(nodeContent);

                                                                doc.DocumentElement.AppendChild(nodeTaskList);
                                                            }

                                                            #endregion

                                                            #region Xóa nhắc nhở cũ

                                                            foreach (XmlNode nodeTaskList in doc.SelectNodes("Recurring/TaskList"))
                                                            {
                                                                if (nodeTaskList.SelectSingleNode("ID").InnerText == frmTaskOfTheDay.strRecurringID)
                                                                {
                                                                    if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                                    {
                                                                        for (int k = 3; k < nodeTaskList.ChildNodes.Count; k++)
                                                                        {
                                                                            if (nodeTaskList.ChildNodes[k].ChildNodes[0].InnerText == frmTaskOfTheDay.strRecurringName && nodeTaskList.ChildNodes[k].ChildNodes[1].InnerText == frmTaskOfTheDay.strRecurringDes && nodeTaskList.ChildNodes[k].ChildNodes[2].InnerText == frmTaskOfTheDay.strRecurringRepeat)
                                                                            {
                                                                                nodeTaskList.ChildNodes[k].ParentNode.RemoveChild(nodeTaskList.ChildNodes[k]);
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
                                                    TaskList[i].ChildNodes[1].InnerText = dtpDate.Text;
                                                    TaskList[i].ChildNodes[2].InnerText = Hour + ":" + Minute;
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = txtTaskName.Text;
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = txtDescription.Text;
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = cbxRepeat.Text;
                                                }
                                            }
                                            else // Không thay đổi ngày giờ
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (TaskList[i].ChildNodes[j].ChildNodes[0].InnerText == frmTaskOfTheDay.strRecurringName && TaskList[i].ChildNodes[j].ChildNodes[1].InnerText == frmTaskOfTheDay.strRecurringDes && TaskList[i].ChildNodes[j].ChildNodes[2].InnerText == frmTaskOfTheDay.strRecurringRepeat)
                                                        {
                                                            TaskList[i].ChildNodes[j].ChildNodes[0].InnerText = txtTaskName.Text; // Name
                                                            TaskList[i].ChildNodes[j].ChildNodes[1].InnerText = txtDescription.Text; // Description
                                                            TaskList[i].ChildNodes[j].ChildNodes[2].InnerText = cbxRepeat.Text; // Repeat
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = txtTaskName.Text; // Name
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = txtDescription.Text; // Description
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = cbxRepeat.Text; // Repeat
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            doc.Save("Recurring.xml");

                            MessageBox.Show("Update successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Task name and description not empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Save Fail!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion
        }

        private void NewRecurring_Load(object sender, EventArgs e)
        {
            if (strFlag == "New")
            {
                dtpDate.CustomFormat = "dd/MM/yyyy";
                cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;

                dtpDate.MinDate = DateTime.Now;
                cbxRepeat.SelectedIndex = 0;
            }
            if (strFlag == "Edit")
            {
                this.Text = "Edit Recurring";
                if (UC_Recurring.iFlag == 1) // UC_Recurring gọi form
                {
                    txtTaskName.Text = UC_Recurring.strRecurringName;
                    txtDescription.Text = UC_Recurring.strRecurringDes;
                    dtpDate.Text = DateTime.ParseExact(UC_Recurring.strRecurringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                    dtpTime.Value = DateTime.Today.AddHours(double.Parse(UC_Recurring.strRecurringTime.Substring(0, UC_Recurring.strRecurringTime.IndexOf(":")))).AddMinutes(double.Parse(UC_Recurring.strRecurringTime.Substring(UC_Recurring.strRecurringTime.IndexOf(":") + 1)));
                    cbxRepeat.Text = UC_Recurring.strRecurringRepeat;
                }
                else // TaskOfTheDay gọi form
                {
                    txtTaskName.Text = frmTaskOfTheDay.strRecurringName;
                    txtDescription.Text = frmTaskOfTheDay.strRecurringDes;
                    dtpDate.Text = DateTime.ParseExact(frmTaskOfTheDay.strRecurringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                    dtpTime.Value = DateTime.Today.AddHours(double.Parse(frmTaskOfTheDay.strRecurringTime.Substring(0, frmTaskOfTheDay.strRecurringTime.IndexOf(":")))).AddMinutes(double.Parse(frmTaskOfTheDay.strRecurringTime.Substring(frmTaskOfTheDay.strRecurringTime.IndexOf(":") + 1)));
                    cbxRepeat.Text = frmTaskOfTheDay.strRecurringRepeat;
                }

                dtpDate.CustomFormat = "dd/MM/yyyy";
                cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                dtpDate.MinDate = DateTime.Now;
            }
        }
    }
}
