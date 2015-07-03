using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;

namespace Reminiscent
{
    public partial class frmEditRecurring : Form
    {
        public frmEditRecurring()
        {
            InitializeComponent();
        }

        private void EditRecurring_Load(object sender, EventArgs e)
        {
            if (UC_Recurring.iFlag == 1) // UC_Recurring gọi form
            {
                txtTaskName.Text = UC_Recurring.strRecurringName;
                txtDescription.Text = UC_Recurring.strRecurringDes;
                dtpDate.Text = DateTime.ParseExact(UC_Recurring.strRecurringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                cbxHours.Text = UC_Recurring.strRecurringTime.Substring(0, UC_Recurring.strRecurringTime.IndexOf(":"));
                cbxMinutes.Text = UC_Recurring.strRecurringTime.Substring(UC_Recurring.strRecurringTime.IndexOf(":") + 1);
                cbxRepeat.Text = UC_Recurring.strRecurringRepeat; 
            }
            else // TaskOfTheDay gọi form
            {
                txtTaskName.Text = frmTaskOfTheDay.strRecurringName;
                txtDescription.Text = frmTaskOfTheDay.strRecurringDes;
                dtpDate.Text = DateTime.ParseExact(frmTaskOfTheDay.strRecurringDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                cbxHours.Text = frmTaskOfTheDay.strRecurringTime.Substring(0, frmTaskOfTheDay.strRecurringTime.IndexOf(":"));
                cbxMinutes.Text = frmTaskOfTheDay.strRecurringTime.Substring(frmTaskOfTheDay.strRecurringTime.IndexOf(":") + 1);
                cbxRepeat.Text = frmTaskOfTheDay.strRecurringRepeat;
            }

            dtpDate.CustomFormat = "dd/MM/yyyy";
            cbxHours.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMinutes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpDate.MinDate = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region Cập nhật lại nhắc nhở

            if (txtTaskName.Text != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Recurring.xml");

                XmlElement ele = doc.DocumentElement;
                XmlNodeList TaskList = ele.GetElementsByTagName("TaskList");
                int iFlag3 = 0;

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
                                    if (TaskList[ii].ChildNodes[1].InnerText == dtpDate.Text && TaskList[ii].ChildNodes[2].InnerText == cbxHours.Text + ":" + cbxMinutes.Text)
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
                                if (TaskList[i].ChildNodes[1].InnerText != dtpDate.Text || TaskList[i].ChildNodes[2].InnerText != cbxHours.Text + ":" + cbxMinutes.Text) // Ngày hoặc giờ bị thay đổi
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

                                                    if (dtpDate.Text == TaskList[k].ChildNodes[1].InnerText && strHour == cbxHours.Text && strMinute == cbxMinutes.Text) // Cùng thời gian, chèn thêm vào content
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
                                                    nodeTime.InnerText = cbxHours.Text + ":" + cbxMinutes.Text;

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
                                        TaskList[i].ChildNodes[2].InnerText = cbxHours.Text + ":" + cbxMinutes.Text;
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
                                    if (TaskList[ii].ChildNodes[1].InnerText == dtpDate.Text && TaskList[ii].ChildNodes[2].InnerText == cbxHours.Text + ":" + cbxMinutes.Text)
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
                                if (TaskList[i].ChildNodes[1].InnerText != dtpDate.Text || TaskList[i].ChildNodes[2].InnerText != cbxHours.Text + ":" + cbxMinutes.Text) // Ngày hoặc giờ bị thay đổi
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

                                                    if (dtpDate.Text == TaskList[k].ChildNodes[1].InnerText && strHour == cbxHours.Text && strMinute == cbxMinutes.Text) // Cùng thời gian, chèn thêm vào content
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
                                                    nodeTime.InnerText = cbxHours.Text + ":" + cbxMinutes.Text;

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
                                        TaskList[i].ChildNodes[2].InnerText = cbxHours.Text + ":" + cbxMinutes.Text;
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
            else
            {
                MessageBox.Show("Task name not empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }
    }
}
