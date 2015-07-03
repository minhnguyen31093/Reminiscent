using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Globalization;

namespace Reminiscent
{
    public partial class UC_Recurring : UserControl
    {
        public UC_Recurring() 
        {
            InitializeComponent();
        }

        public static int iFlag = 0;
        public static string strRecurringID = "";
        public static string strRecurringName = "";
        public static string strRecurringDes = "";
        public static string strRecurringDate = "";
        public static string strRecurringTime = "";
        public static string strRecurringRepeat = "";

        private void UC_Recurring_Load(object sender, EventArgs e)
        {
            UpdateTime();

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
                    groupBox3.Text = frmMain.Decryption(node.SelectSingleNode("gb1").InnerText);
                    groupBox1.Text = frmMain.Decryption(node.SelectSingleNode("gb2").InnerText);
                    groupBox2.Text = frmMain.Decryption(node.SelectSingleNode("gb3").InnerText);
                    groupBox4.Text = frmMain.Decryption(node.SelectSingleNode("gb4").InnerText);

                    colName.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colDescription.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colDate.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    colTime.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colRepeat.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);

                    columnHeader1.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    columnHeader2.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    columnHeader3.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    columnHeader4.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    columnHeader5.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);

                    columnHeader6.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    columnHeader7.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    columnHeader8.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    columnHeader9.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    columnHeader10.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);

                    label1.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    label2.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    label3.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    label4.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    label5.Text = frmMain.Decryption(node.SelectSingleNode("lbl5").InnerText);
                    lblCompleted.Text = frmMain.Decryption(node.SelectSingleNode("lbl6").InnerText);
                    lblToDay.Text = frmMain.Decryption(node.SelectSingleNode("lbl7").InnerText);

                    btnRefresh.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnSaveAs.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnDelete.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnSave.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    break;
                }
            }
            #endregion
        }

        private void UpdateTime()
        {
            if (File.Exists(Application.StartupPath + "/Data/Recurring.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "/Data/Recurring.xml");
                XmlElement ele = doc.DocumentElement;
                XmlNodeList TaskList = ele.GetElementsByTagName("TaskList");

                string strDay, strMonth, strYear, strToDay, strHour, strMinute, strTime;
                int iMax = 0;
                int j = 3;
                int iChange = 0;

                if (DateTime.Now.Hour < 10)
                    strHour = "0" + DateTime.Now.Hour;
                else
                    strHour = DateTime.Now.Hour.ToString();

                if (DateTime.Now.Minute < 10)
                    strMinute = "0" + DateTime.Now.Minute;
                else
                    strMinute = DateTime.Now.Minute.ToString();

                strTime = strHour + ":" + strMinute;

                if (DateTime.Now.Day < 10)
                    strDay = "0" + DateTime.Now.Day;
                else
                    strDay = DateTime.Now.Day.ToString();

                if (DateTime.Now.Month < 10)
                    strMonth = "0" + DateTime.Now.Month;
                else
                    strMonth = DateTime.Now.Month.ToString();

                strYear = DateTime.Now.Year.ToString();

                strToDay = strDay + "/" + strMonth + "/" + strYear;

                for (int i = 0; i < TaskList.Count; i++)
                {
                    if (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture)) // Ngày nhỏ hơn ngày hiện tại
                    {
                        #region Ngày nhỏ hơn ngày hiện tại

                        if (TaskList[i].ChildNodes.Count < 5)
                        {
                            #region Một công việc trong cùng thời điểm

                            if (DateTime.Parse(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)) <= DateTime.Parse(strTime)) // Giờ nhỏ hơn giờ hiện tại
                            {
                                iChange = 1;

                                if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Daily")
                                {
                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))));
                                }
                                else
                                    if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Monthly")
                                    {
                                        while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                        {
                                            TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1))));
                                        }
                                    }
                                    else
                                        if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Yearly")
                                        {
                                            while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1))));
                                            }
                                        }
                                        else
                                            if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Weekly")
                                            {
                                                while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                                {
                                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7))));
                                                }
                                            }
                            }
                            else
                            {
                                if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Daily")
                                {
                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(strToDay);
                                }
                                else
                                    if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Monthly")
                                    {
                                        while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                        {
                                            TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1))));
                                        }
                                    }
                                    else
                                        if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Yearly")
                                        {
                                            while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1))));
                                            }
                                        }
                                        else
                                            if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Weekly")
                                            {
                                                while (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                                {
                                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7))));
                                                }
                                            }
                            }

                            #endregion

                            if (iChange == 1)
                                TaskList[i].ParentNode.RemoveChild(TaskList[i]);
                        }
                        else // Nhiều công việc cùng thời điểm
                        {
                            #region Nhiều công việc trong cùng thời điểm

                            for (j = 3; j < TaskList[i].ChildNodes.Count; j++)
                            {
                                if (DateTime.Parse(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)) <= DateTime.Parse(strTime)) // Giờ nhỏ hơn giờ hiện tại
                                {
                                    iChange = 1;

                                    #region Hằng ngày

                                    if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Daily")
                                    {
                                        int iFlag = 0;

                                        foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                        {
                                            if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                            {
                                                iFlag = 1;

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                node2.AppendChild(nodeContent);
                                            }
                                        }

                                        if (iFlag != 1) // Tạo công việc mới
                                        {
                                            XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                            XmlNode nodeID = doc.CreateElement("ID");

                                            if (TaskList.Count < 1)
                                            {
                                                nodeID.InnerText = frmMain.Encryption("0");
                                            }
                                            else
                                            {
                                                for (int k = 0; k < TaskList.Count; k++)
                                                {
                                                    if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                        iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                }
                                                iMax += 1;
                                                nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                            }

                                            XmlNode nodeDate = doc.CreateElement("Date");
                                            nodeDate.InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))));

                                            XmlNode nodeTime = doc.CreateElement("Time");
                                            nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                            nodeTaskList.AppendChild(nodeID);
                                            nodeTaskList.AppendChild(nodeDate);
                                            nodeTaskList.AppendChild(nodeTime);

                                            XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                            XmlNode nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                            XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            nodeTaskList.AppendChild(nodeContent);

                                            doc.DocumentElement.AppendChild(nodeTaskList);
                                        }
                                    }

                                    #endregion

                                    else
                                    {
                                        string dtTemp = frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText);

                                        #region Hằng tháng

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Monthly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1));
                                            }
                                        }

                                        #endregion

                                        #region Hằng năm

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Yearly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1));
                                            }
                                        }

                                        #endregion

                                        #region Hằng tuần

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Weekly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7));
                                            }
                                        }

                                        #endregion

                                        #region Xử lý

                                        foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                        {
                                            if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                            {
                                                iFlag = 1;

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                node2.AppendChild(nodeContent);
                                            }
                                        }

                                        if (iFlag != 1) // Tạo công việc mới
                                        {
                                            XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                            XmlNode nodeID = doc.CreateElement("ID");

                                            if (TaskList.Count < 1)
                                            {
                                                nodeID.InnerText = frmMain.Encryption("0");
                                            }
                                            else
                                            {
                                                for (int k = 0; k < TaskList.Count; k++)
                                                {
                                                    if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                        iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                }
                                                iMax += 1;
                                                nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                            }

                                            XmlNode nodeDate = doc.CreateElement("Date");
                                            nodeDate.InnerText = frmMain.Encryption(GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

                                            XmlNode nodeTime = doc.CreateElement("Time");
                                            nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                            nodeTaskList.AppendChild(nodeID);
                                            nodeTaskList.AppendChild(nodeDate);
                                            nodeTaskList.AppendChild(nodeTime);

                                            XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                            XmlNode nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                            XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            nodeTaskList.AppendChild(nodeContent);

                                            doc.DocumentElement.AppendChild(nodeTaskList);
                                        }

                                        #endregion
                                    }
                                }
                                else // Giờ lớn hơn giờ hiện tại
                                {
                                    iChange = 1;

                                    #region Hằng ngày

                                    if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Daily")
                                    {
                                        int iFlag = 0;

                                        foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                        {
                                            if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                            {
                                                iFlag = 1;

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                node2.AppendChild(nodeContent);
                                            }
                                        }

                                        if (iFlag != 1) // Tạo công việc mới
                                        {
                                            XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                            XmlNode nodeID = doc.CreateElement("ID");

                                            if (TaskList.Count < 1)
                                            {
                                                nodeID.InnerText = frmMain.Encryption("0");
                                            }
                                            else
                                            {
                                                for (int k = 0; k < TaskList.Count; k++)
                                                {
                                                    if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                        iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                }
                                                iMax += 1;
                                                nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                            }

                                            XmlNode nodeDate = doc.CreateElement("Date");
                                            nodeDate.InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))));

                                            XmlNode nodeTime = doc.CreateElement("Time");
                                            nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                            nodeTaskList.AppendChild(nodeID);
                                            nodeTaskList.AppendChild(nodeDate);
                                            nodeTaskList.AppendChild(nodeTime);

                                            XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                            XmlNode nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                            XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            nodeTaskList.AppendChild(nodeContent);

                                            doc.DocumentElement.AppendChild(nodeTaskList);
                                        }
                                    }

                                    #endregion

                                    else
                                    {
                                        string dtTemp = TaskList[i].ChildNodes[1].InnerText;

                                        #region Hằng tháng

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Monthly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1));
                                            }
                                        }

                                        #endregion

                                        #region Hằng năm

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Yearly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1));
                                            }
                                        }

                                        #endregion

                                        #region Hằng tuần

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Weekly")
                                        {
                                            while (DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7));
                                            }
                                        }

                                        #endregion

                                        #region Xử lý

                                        foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                        {
                                            if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                            {
                                                iFlag = 1;

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                node2.AppendChild(nodeContent);
                                            }
                                        }

                                        if (iFlag != 1) // Tạo công việc mới
                                        {
                                            XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                            XmlNode nodeID = doc.CreateElement("ID");

                                            if (TaskList.Count < 1)
                                            {
                                                nodeID.InnerText = frmMain.Encryption("0");
                                            }
                                            else
                                            {
                                                for (int k = 0; k < TaskList.Count; k++)
                                                {
                                                    if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                        iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                }
                                                iMax += 1;
                                                nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                            }

                                            XmlNode nodeDate = doc.CreateElement("Date");
                                            nodeDate.InnerText = frmMain.Encryption(GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

                                            XmlNode nodeTime = doc.CreateElement("Time");
                                            nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                            nodeTaskList.AppendChild(nodeID);
                                            nodeTaskList.AppendChild(nodeDate);
                                            nodeTaskList.AppendChild(nodeTime);

                                            XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                            XmlNode nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                            XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            nodeTaskList.AppendChild(nodeContent);

                                            doc.DocumentElement.AppendChild(nodeTaskList);
                                        }

                                        #endregion
                                    }
                                }

                                if (TaskList[i].ChildNodes.Count > 4 && iChange == 1)
                                {
                                    TaskList[i].ChildNodes[j].ParentNode.RemoveChild(TaskList[i].ChildNodes[j]);
                                    j = j - 1;
                                }
                                else
                                    if (iChange == 1)
                                    {
                                        TaskList[i].ParentNode.RemoveChild(TaskList[i]);
                                        break;
                                    }
                            }

                            #endregion
                        }

                        #endregion
                    }
                    else
                        #region Ngày là ngày hiện tại

                        if (DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture) == DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        {
                            if (TaskList[i].ChildNodes.Count < 5)
                            {
                                #region Một công việc trong cùng thời điểm

                                if (DateTime.Parse(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)) <= DateTime.Parse(strTime)) // Giờ nhỏ hơn giờ hiện tại
                                {
                                    iChange = 1;

                                    if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Daily")
                                    {
                                        TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))));
                                    }
                                    else
                                        if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Monthly")
                                        {
                                            TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1))));
                                        }
                                        else
                                            if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Yearly")
                                            {
                                                TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1))));
                                            }
                                            else
                                                if (frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText) == "Weekly")
                                                {
                                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7))));
                                                }
                                }

                                #endregion

                                if (iChange == 1)
                                    TaskList[i].ParentNode.RemoveChild(TaskList[i]);
                            }
                            else // Nhiều công việc cùng thời điểm
                            {
                                #region Nhiều công việc trong cùng thời điểm

                                for (j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                {
                                    if (DateTime.Parse(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)) <= DateTime.Parse(strTime)) // Giờ nhỏ hơn giờ hiện tại
                                    {
                                        iChange = 1;

                                        #region Hằng ngày

                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Daily")
                                        {
                                            int iFlag = 0;

                                            foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                            {
                                                if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                                {
                                                    iFlag = 1;

                                                    XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                    XmlNode nodeName = doc.CreateElement("Name");
                                                    nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                    XmlNode nodeDes = doc.CreateElement("Description");
                                                    nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                    XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                    nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                    nodeContent.AppendChild(nodeName);
                                                    nodeContent.AppendChild(nodeDes);
                                                    nodeContent.AppendChild(nodeRepeat);

                                                    node2.AppendChild(nodeContent);
                                                }
                                            }

                                            if (iFlag != 1) // Tạo công việc mới
                                            {
                                                XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                XmlNode nodeID = doc.CreateElement("ID");

                                                if (TaskList.Count < 1)
                                                {
                                                    nodeID.InnerText = frmMain.Encryption("0");
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < TaskList.Count; k++)
                                                    {
                                                        if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                            iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                    }
                                                    iMax += 1;
                                                    nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                                }

                                                XmlNode nodeDate = doc.CreateElement("Date");
                                                nodeDate.InnerText = frmMain.Encryption(GetDay((DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1))));

                                                XmlNode nodeTime = doc.CreateElement("Time");
                                                nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                                nodeTaskList.AppendChild(nodeID);
                                                nodeTaskList.AppendChild(nodeDate);
                                                nodeTaskList.AppendChild(nodeTime);

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                nodeTaskList.AppendChild(nodeContent);

                                                doc.DocumentElement.AppendChild(nodeTaskList);
                                            }
                                        }

                                        #endregion

                                        else
                                        {
                                            string dtTemp = frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText);

                                            #region Hằng tháng

                                            if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Monthly")
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1));
                                            }

                                            #endregion

                                            #region Hằng năm

                                            if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Yearly")
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddYears(1));
                                            }

                                            #endregion

                                            #region Hằng tuần

                                            if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == "Weekly")
                                            {
                                                dtTemp = GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(7));
                                            }

                                            #endregion

                                            #region Xử lý

                                            foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                            {
                                                if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) && GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)) == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                                {
                                                    iFlag = 1;

                                                    XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                    XmlNode nodeName = doc.CreateElement("Name");
                                                    nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                    XmlNode nodeDes = doc.CreateElement("Description");
                                                    nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                    XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                    nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                    nodeContent.AppendChild(nodeName);
                                                    nodeContent.AppendChild(nodeDes);
                                                    nodeContent.AppendChild(nodeRepeat);

                                                    node2.AppendChild(nodeContent);
                                                }
                                            }

                                            if (iFlag != 1) // Tạo công việc mới
                                            {
                                                XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                XmlNode nodeID = doc.CreateElement("ID");

                                                if (TaskList.Count < 1)
                                                {
                                                    nodeID.InnerText = frmMain.Encryption("0");
                                                }
                                                else
                                                {
                                                    for (int k = 0; k < TaskList.Count; k++)
                                                    {
                                                        if (iMax < int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText)))
                                                            iMax = int.Parse(frmMain.Decryption(TaskList[k].ChildNodes[0].InnerText));
                                                    }
                                                    iMax += 1;
                                                    nodeID.InnerText = frmMain.Encryption((iMax).ToString()); // Lấy ID cao nhất cộng thêm 1
                                                }

                                                XmlNode nodeDate = doc.CreateElement("Date");
                                                nodeDate.InnerText = frmMain.Encryption(GetDay(DateTime.ParseExact(dtTemp, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

                                                XmlNode nodeTime = doc.CreateElement("Time");
                                                nodeTime.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[2].InnerText);

                                                nodeTaskList.AppendChild(nodeID);
                                                nodeTaskList.AppendChild(nodeDate);
                                                nodeTaskList.AppendChild(nodeTime);

                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                XmlNode nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText);

                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText);

                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = frmMain.Encryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText);

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                nodeTaskList.AppendChild(nodeContent);

                                                doc.DocumentElement.AppendChild(nodeTaskList);
                                            }

                                            #endregion
                                        }
                                    }

                                    if (TaskList[i].ChildNodes.Count > 4 && iChange == 1)
                                    {
                                        TaskList[i].ChildNodes[j].ParentNode.RemoveChild(TaskList[i].ChildNodes[j]);
                                        j = j - 1;
                                    }
                                    else
                                        if (iChange == 1)
                                        {
                                            TaskList[i].ParentNode.RemoveChild(TaskList[i]);
                                            break;
                                        }
                                }

                                #endregion
                            }
                        }

                        #endregion
                }

                doc.Save(Application.StartupPath + "/Data/Recurring.xml"); ; ;
            }
        }

        internal void LoadListView()
        {
            Sort();

            lvwListRecurring.Items.Clear();

            if (File.Exists(Application.StartupPath + "/Data/Recurring.xml"))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Recurring.xml");
                    XmlElement root = xmlDoc.DocumentElement;
                    XmlNodeList TaskList = root.GetElementsByTagName("TaskList");

                    #region List Recurring

                    for (int i = 0; i < TaskList.Count; i++)
                    {
                        if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc chung một thời điểm
                        {
                            for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                            {
                                ListViewItem lvi = new ListViewItem();

                                lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                                lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText); // Name
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText)); // Description
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText)); // Repeat

                                lvwListRecurring.Items.Add(lvi);
                            }
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem();

                            lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                            lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[0].InnerText); // Name
                            lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[1].InnerText)); // Description
                            lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                            lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                            lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText)); // Repeat

                            lvwListRecurring.Items.Add(lvi);
                        }
                    }

                    #endregion

                    #region Tô màu những dòng công việc hết hạn

                    string strDay, strMonth, strYear, strToDay, strHour, strMinute, strTime;

                    if (DateTime.Now.Hour < 10)
                        strHour = "0" + DateTime.Now.Hour;
                    else
                        strHour = DateTime.Now.Hour.ToString();

                    if (DateTime.Now.Minute < 10)
                        strMinute = "0" + DateTime.Now.Minute;
                    else
                        strMinute = DateTime.Now.Minute.ToString();

                    strTime = strHour + ":" + strMinute;

                    if (DateTime.Now.Day < 10)
                        strDay = "0" + DateTime.Now.Day;
                    else
                        strDay = DateTime.Now.Day.ToString();

                    if (DateTime.Now.Month < 10)
                        strMonth = "0" + DateTime.Now.Month;
                    else
                        strMonth = DateTime.Now.Month.ToString();

                    strYear = DateTime.Now.Year.ToString();

                    strToDay = strDay + "/" + strMonth + "/" + strYear;

                    for (int i = 0; i < lvwListRecurring.Items.Count; i++)
                    {
                        if (DateTime.ParseExact(lvwListRecurring.Items[i].SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                        {
                            lvwListRecurring.Items[i].BackColor = Color.Yellow;
                        }
                        else
                            if (DateTime.ParseExact(lvwListRecurring.Items[i].SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) == DateTime.ParseExact(strToDay, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                            {
                                if (DateTime.Parse(lvwListRecurring.Items[i].SubItems[3].Text) < DateTime.Parse(strTime))
                                    lvwListRecurring.Items[i].BackColor = Color.Yellow;
                            }
                            else
                                lvwListRecurring.Items[i].BackColor = Color.Transparent;

                    }

                    #endregion

                    #region Task Of The Day

                    lvwTOTD.Items.Clear();

                    string strRecurringDate = "";
                    int iDay, iMonth, iYear;

                    string strDateNow = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                    for (int i = 0; i < TaskList.Count; i++)
                    {
                        strRecurringDate = frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText);

                        iDay = int.Parse(strRecurringDate.Substring(0, strRecurringDate.IndexOf("/")));
                        iMonth = int.Parse(strRecurringDate.Substring(strRecurringDate.IndexOf("/") + 1, strRecurringDate.LastIndexOf("/") - 3));
                        iYear = int.Parse(strRecurringDate.Substring(strRecurringDate.LastIndexOf("/") + 1));

                        strRecurringDate = iDay.ToString() + "/" + iMonth.ToString() + "/" + iYear.ToString();

                        if (strRecurringDate == strDateNow)
                        {
                            if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc chung một thời điểm
                            {
                                for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                {
                                    ListViewItem lvi = new ListViewItem();

                                    lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                                    lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText); // Name
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText)); // Description
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText)); // Repeat

                                    lvwTOTD.Items.Add(lvi);
                                }
                            }
                            else
                            {
                                ListViewItem lvi = new ListViewItem();

                                lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                                lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[0].InnerText); // Name
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[1].InnerText)); // Description
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText)); // Repeat

                                lvwTOTD.Items.Add(lvi);
                            }
                        }
                    }

                    if (lvwTOTD.Items.Count > 9)
                        lblTOTD.Text = lvwTOTD.Items.Count.ToString();
                    else
                        lblTOTD.Text = " " + lvwTOTD.Items.Count.ToString();

                    if (lvwTOTD.Items.Count > 0)
                        lblTOTD.ForeColor = Color.Red;
                    else
                        lblTOTD.ForeColor = Color.Black;

                    #region Tô màu những dòng công việc hết hạn

                    for (int i = 0; i < lvwTOTD.Items.Count; i++)
                    {
                        if (DateTime.Parse(lvwTOTD.Items[i].SubItems[3].Text) < DateTime.Parse(strTime))
                            lvwTOTD.Items[i].BackColor = Color.Yellow;
                        else
                            lvwTOTD.Items[i].BackColor = Color.Transparent;
                    }

                    #endregion

                    #endregion

                    #region Task Complete

                    lvwTaskComplete.Items.Clear();

                    if (File.Exists(Application.StartupPath + "/Data/History.xml"))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Application.StartupPath + "/Data/History.xml");
                        XmlElement ele = doc.DocumentElement;
                        XmlNodeList TaskList2 = ele.GetElementsByTagName("TaskList");

                        #region Sắp xếp listview "Task Complete"

                        int[] iArray = new int[TaskList2.Count]; // Mảng chứa id của những phần tử đã xuất

                        for (int j = 0; j < iArray.Length; j++)
                        {
                            iArray[j] = -1;
                        }

                        int iDem = 0;

                        for (int i = 0; i < TaskList2.Count; i++)
                        {
                            int iFlag = 0;

                            for (int j = 0; j < iArray.Length; j++)
                            {
                                if (frmMain.Decryption(TaskList2[i].ChildNodes[0].InnerText) == iArray[j].ToString())
                                    iFlag = 1;
                            }

                            if (iFlag != 1) // Phần tử chưa xuất ra listview
                            {
                                DateTime dtMaxDay = DateTime.ParseExact(frmMain.Decryption(TaskList2[i].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                DateTime dtMaxTime = DateTime.Parse(frmMain.Decryption(TaskList2[i].ChildNodes[2].InnerText));

                                int iRow = i;
                                int iTemp = 0;
                                for (int k = 0; k < TaskList2.Count; k++)
                                {
                                    int iFlag2 = 0;

                                    for (int j = 0; j < iArray.Length; j++)
                                    {
                                        if (frmMain.Decryption(TaskList2[k].ChildNodes[0].InnerText) == iArray[j].ToString())
                                        {
                                            iFlag2 = 1;
                                        }
                                    }

                                    if (iFlag2 != 1 && frmMain.Decryption(TaskList2[i].ChildNodes[0].InnerText) != frmMain.Decryption(TaskList2[k].ChildNodes[0].InnerText))
                                    {
                                        if (dtMaxDay < DateTime.ParseExact(frmMain.Decryption(TaskList2[k].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                        {
                                            dtMaxDay = DateTime.ParseExact(frmMain.Decryption(TaskList2[k].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                            dtMaxTime = DateTime.Parse(frmMain.Decryption(TaskList2[k].ChildNodes[2].InnerText));
                                            iRow = k;
                                            iTemp = 1;
                                        }
                                        else
                                            if (dtMaxDay == DateTime.ParseExact(frmMain.Decryption(TaskList2[k].ChildNodes[1].InnerText), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                                            {
                                                if (dtMaxTime < DateTime.Parse(frmMain.Decryption(TaskList2[k].ChildNodes[2].InnerText)))
                                                {
                                                    dtMaxTime = DateTime.Parse(frmMain.Decryption(TaskList2[k].ChildNodes[2].InnerText));
                                                    iRow = k;
                                                    iTemp = 1;
                                                }
                                            }
                                    }
                                }

                                if (iTemp == 1)
                                    i -= 1;

                                iArray[iDem] = int.Parse(frmMain.Decryption(TaskList2[iRow].ChildNodes[0].InnerText)); // Thêm id vào mảng những id đã xuất
                                iDem += 1;

                                if (TaskList2[iRow].ChildNodes.Count > 4) // Nhiều công việc chung một thời điểm
                                {
                                    for (int j = 3; j < TaskList2[iRow].ChildNodes.Count; j++)
                                    {
                                        ListViewItem lvi = new ListViewItem();

                                        lvi.Tag = frmMain.Decryption(TaskList2[iRow].ChildNodes[0].InnerText); // ID
                                        lvi.Text = frmMain.Decryption(TaskList2[iRow].ChildNodes[j].ChildNodes[0].InnerText); // Name
                                        lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[j].ChildNodes[1].InnerText)); // Description
                                        lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[1].InnerText)); // Date
                                        lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[2].InnerText)); // Time
                                        lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[j].ChildNodes[2].InnerText)); // Repeat

                                        lvwTaskComplete.Items.Add(lvi);
                                    }
                                }
                                else
                                {
                                    ListViewItem lvi = new ListViewItem();

                                    lvi.Tag = frmMain.Decryption(TaskList2[iRow].ChildNodes[0].InnerText); // ID
                                    lvi.Text = frmMain.Decryption(TaskList2[iRow].ChildNodes[3].ChildNodes[0].InnerText); // Name
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[3].ChildNodes[1].InnerText)); // Description
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[1].InnerText)); // Date
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[2].InnerText)); // Time
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList2[iRow].ChildNodes[3].ChildNodes[2].InnerText)); // Repeat

                                    lvwTaskComplete.Items.Add(lvi);
                                }
                            }
                        }

                        #endregion
                    }

                    #region Tô màu Task Complete

                    if (lvwTaskComplete.Items.Count > 9)
                        lblTaskComplete.Text = lvwTaskComplete.Items.Count.ToString();
                    else
                        lblTaskComplete.Text = " " + lvwTaskComplete.Items.Count.ToString();

                    if (lvwTaskComplete.Items.Count > 0)
                        lblTaskComplete.ForeColor = Color.Red;
                    else
                        lblTaskComplete.ForeColor = Color.Black;

                    #endregion

                    #endregion
                }
                catch (Exception)
                {
                    File.Delete(Application.StartupPath + "/Data/Recurring.xml.bk");
                    File.Copy(Application.StartupPath + "/Data/Recurring.xml", Application.StartupPath + "/Data/Recurring.xml.bk");
                    File.Delete(Application.StartupPath + "/Data/Recurring.xml");
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Recurring.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    //Create XML
                    writer.WriteStartDocument();
                    //Create Root
                    writer.WriteStartElement("Recurring");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    MessageBox.Show("Your Recurring database have been corrupted! \n\n It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public static void Sort()
        {
            if (File.Exists(Application.StartupPath + "/Data/Recurring.xml"))
            {
                // Sắp xếp lại thứ tự công việc trong tập tin Recurring.xml
                XElement root = XElement.Load(Application.StartupPath + "/Data/Recurring.xml");
                var orderedtabs = root.Elements("TaskList")
                                      .OrderBy(xtab => frmMain.Decryption(xtab.Element("Time").Value.ToString()))
                                      .ToArray();
                root.RemoveAll();
                foreach (XElement tab in orderedtabs)
                    root.Add(tab);
                root.Save(Application.StartupPath + "/Data/Recurring.xml");
            }
        }

        public void btnDel_Click(object sender, EventArgs e)
        {
            #region Xóa một nhắc nhở

            if (lvwListRecurring.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwListRecurring.SelectedItems)
                {
                    strRecurringID = lvi.Tag.ToString();
                    strRecurringName = lvi.Text;
                    strRecurringDes = lvi.SubItems[1].Text;
                    strRecurringRepeat = lvi.SubItems[4].Text;
                }

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to delete item '" + strRecurringName + "'", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + "/Data/Recurring.xml");

                    foreach (XmlNode nodeTaskList in doc.SelectNodes("Recurring/TaskList"))
                    {
                        if (frmMain.Decryption(nodeTaskList.SelectSingleNode("ID").InnerText) == strRecurringID)
                        {
                            if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                            {
                                for (int i = 3; i < nodeTaskList.ChildNodes.Count; i++)
                                {
                                    if (frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[0].InnerText) == strRecurringName && frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[1].InnerText) == strRecurringDes && frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[2].InnerText) == strRecurringRepeat)
                                    {
                                        nodeTaskList.ChildNodes[i].ParentNode.RemoveChild(nodeTaskList.ChildNodes[i]);
                                        i--;
                                    }
                                }
                            }
                            else
                            {
                                nodeTaskList.ParentNode.RemoveChild(nodeTaskList);
                            }
                        }
                    }

                    doc.Save(Application.StartupPath + "/Data/Recurring.xml");
                    MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadListView();
                }

            }
            else
                MessageBox.Show("No item selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            #endregion
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            iFlag = 1;

            dtpDate.CustomFormat = "dd/MM/yyyy";
            cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpDate.MinDate = DateTime.Now;
            cbxRepeat.SelectedIndex = 0;

            dtpDate.Enabled = true;
            txtName.ReadOnly = false;
            txtDes.ReadOnly = false;
            dtpTime.Enabled = true;

            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            txtName.Text = "";
            txtDes.Text = "";
            cbxRepeat.Enabled = true;
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "" && txtDes.Text.Trim() != "")
            {
                if (dtpDate.Value.Day == DateTime.Now.Day && dtpDate.Value.Month == DateTime.Now.Month && dtpDate.Value.Year == DateTime.Now.Year && dtpTime.Value < DateTime.Now)
                {
                    MessageBox.Show("Invalid DateTime!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                    dtpDate.Enabled = true;
                    txtName.ReadOnly = false;
                    txtDes.ReadOnly = false;
                    dtpTime.Enabled = true;
                    cbxRepeat.Enabled = true;
                }

                else
                {
                    iFlag = 2;

                    dtpDate.CustomFormat = "dd/MM/yyyy";
                    cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;

                    string Hour = dtpTime.Value.Hour.ToString();
                    string Minute = dtpTime.Value.Minute.ToString();

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
                    }

                    #region Tạo 1 nhắc nhở định kỳ

                    // Ghi vào tập tin Recurring.xml
                    if (!File.Exists(Application.StartupPath + "/Data/Recurring.xml")) // Chưa tồn tại tập tin Recurring.xml
                    {
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Recurring.xml", Encoding.UTF8);
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
                    int iTemp = 0;
                    int iFlag2 = 0; // Task Name already exists
                    XmlDocument xd = new XmlDocument();
                    xd.Load(Application.StartupPath + "/Data/Recurring.xml");

                    XmlElement ele = xd.DocumentElement;
                    XmlNodeList Recurring = ele.GetElementsByTagName("TaskList");

                    if (Recurring.Count > 0) // Tồn tại ít nhất 1 công việc trong tập tin Recurring.xml
                    {
                        for (int i = 0; i < Recurring.Count; i++)
                        {
                            string strHour = frmMain.Decryption(Recurring[i].ChildNodes[2].InnerText).Substring(0, 2);
                            string strMinute = frmMain.Decryption(Recurring[i].ChildNodes[2].InnerText).Substring(3);

                            string TempHour, TempMinute;

                            if (dtpTime.Value.Hour < 10)
                                TempHour = "0" + dtpTime.Value.Hour;
                            else
                                TempHour = dtpTime.Value.Hour.ToString();

                            if (dtpTime.Value.Minute < 10)
                                TempMinute = "0" + dtpTime.Value.Minute;
                            else
                                TempMinute = dtpTime.Value.Minute.ToString();


                            if (dtpDate.Text == frmMain.Decryption(Recurring[i].ChildNodes[1].InnerText) && strHour == TempHour && strMinute == TempMinute) // Cùng thời gian, chèn thêm vào content
                            {
                                iTemp = 1;

                                // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                for (int j = 3; j < Recurring[i].ChildNodes.Count; j++)
                                {
                                    if (frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[1].InnerText) == txtDes.Text && frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[2].InnerText) == cbxRepeat.Text)
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
                                    nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                    XmlNode nodeDes = xd.CreateElement("Description");
                                    nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                    XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                    nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

                                    nodeContent.AppendChild(nodeName);
                                    nodeContent.AppendChild(nodeDes);
                                    nodeContent.AppendChild(nodeRepeat);

                                    Recurring[i].AppendChild(nodeContent);
                                }
                                else
                                    break;
                            }
                        }

                        if (iTemp != 1) // Không trùng thời gian, lưu thành một công việc mới
                        {
                            XmlNode nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                            XmlNode nodeID = xd.CreateElement("ID");

                            if (Recurring.Count < 1)
                            {
                                nodeID.InnerText = frmMain.Encryption("0");
                            }
                            else
                            {
                                for (int i = 0; i < Recurring.Count; i++)
                                {
                                    if (iMax < int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText)))
                                        iMax = int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText));
                                }

                                nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                            }

                            XmlNode nodeDate = xd.CreateElement("Date");
                            nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                            XmlNode nodeTime = xd.CreateElement("Time");
                            nodeTime.InnerText = frmMain.Encryption(Hour + ":" + Minute);

                            XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                            XmlNode nodeName = xd.CreateElement("Name");
                            nodeName.InnerText = frmMain.Encryption(txtName.Text);

                            XmlNode nodeDes = xd.CreateElement("Description");
                            nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                            XmlNode nodeRepeat = xd.CreateElement("Repeat");
                            nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

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

                        nodeID.InnerText = frmMain.Encryption("0");

                        XmlNode nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                        XmlNode nodeTime = xd.CreateElement("Time");
                        nodeTime.InnerText = frmMain.Encryption(Hour + ":" + Minute);

                        XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                        XmlNode nodeName = xd.CreateElement("Name");
                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                        XmlNode nodeDes = xd.CreateElement("Description");
                        nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                        XmlNode nodeRepeat = xd.CreateElement("Repeat");
                        nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

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
                        xd.Save(Application.StartupPath + "/Data/Recurring.xml");

                        LoadListView();

                        txtName.Text = "";
                        txtName.ReadOnly = true;
                        txtDes.ReadOnly = true;
                        txtDes.Text = "";
                        dtpDate.Enabled = false;
                        dtpTime.Enabled = false;
                        cbxRepeat.Enabled = false;

                    }

                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Task name or description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                dtpDate.Enabled = true;
                txtName.ReadOnly = false;
                txtDes.ReadOnly = false;
                dtpTime.Enabled = true;
                cbxRepeat.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            iFlag = 3;

            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            txtDes.ReadOnly = true;
            cbxRepeat.Enabled = false;
            dtpTime.Enabled = false;

            #region Xóa một nhắc nhở

            if (lvwListRecurring.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwListRecurring.SelectedItems)
                {
                    strRecurringID = lvi.Tag.ToString();
                    strRecurringName = lvi.Text;
                    strRecurringDes = lvi.SubItems[1].Text;
                    strRecurringRepeat = lvi.SubItems[4].Text;
                }

                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to delete item '" + strRecurringName + "'", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + "/Data/Recurring.xml");

                    foreach (XmlNode nodeTaskList in doc.SelectNodes("Recurring/TaskList"))
                    {
                        if (frmMain.Decryption(nodeTaskList.SelectSingleNode("ID").InnerText) == strRecurringID)
                        {
                            if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                            {
                                for (int i = 3; i < nodeTaskList.ChildNodes.Count; i++)
                                {
                                    if (frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[0].InnerText) == strRecurringName && frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[1].InnerText) == strRecurringDes && frmMain.Decryption(nodeTaskList.ChildNodes[i].ChildNodes[2].InnerText) == strRecurringRepeat)
                                    {
                                        nodeTaskList.ChildNodes[i].ParentNode.RemoveChild(nodeTaskList.ChildNodes[i]);
                                        i--;
                                    }
                                }
                            }
                            else
                            {
                                nodeTaskList.ParentNode.RemoveChild(nodeTaskList);
                            }
                        }
                    }

                    doc.Save(Application.StartupPath + "/Data/Recurring.xml");

                    dtpDate.Value = DateTime.Now;
                    txtName.Text = "";
                    txtDes.Text = "";
                }
            }
            else
                MessageBox.Show("No items selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            LoadListView();

            #endregion
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            txtDes.ReadOnly = true;
            dtpTime.Enabled = false;
            cbxRepeat.Enabled = false;

            try
            {
                string strTaskName = "";
                string strDescription = "";
                string strDate = "";
                string strTime = "";
                string strRepeat = "";

                if (txtName.Text.Trim() != "" && txtDes.Text.Trim() != "")
                {
                    if (dtpDate.Value.Day == DateTime.Now.Day && dtpDate.Value.Month == DateTime.Now.Month && dtpDate.Value.Year == DateTime.Now.Year && dtpTime.Value < DateTime.Now)
                    {
                        MessageBox.Show("Invalid DateTime!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                        dtpDate.Enabled = true;
                        txtName.ReadOnly = false;
                        txtDes.ReadOnly = false;
                        dtpTime.Enabled = true;
                        cbxRepeat.Enabled = true;
                    }
                    else
                    {
                        if (iFlag == 1) // New
                        {
                            #region New

                            string Hour = dtpTime.Value.Hour.ToString();
                            string Minute = dtpTime.Value.Minute.ToString();

                            strTaskName = txtName.Text;
                            strDate = dtpDate.Text;
                            strDescription = txtDes.Text;
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
                            if (!File.Exists(Application.StartupPath + "/Data/Recurring.xml")) // Chưa tồn tại tập tin Recurring.xml
                            {
                                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Recurring.xml", Encoding.UTF8);
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
                            int iTemp = 0;
                            int iFlag2 = 0; // Task Name already exists
                            XmlDocument xd = new XmlDocument();
                            xd.Load(Application.StartupPath + "/Data/Recurring.xml");

                            XmlElement ele = xd.DocumentElement;
                            XmlNodeList Recurring = ele.GetElementsByTagName("TaskList");

                            if (Recurring.Count > 0) // Tồn tại ít nhất 1 công việc trong tập tin Recurring.xml
                            {
                                for (int i = 0; i < Recurring.Count; i++)
                                {
                                    string strHour = frmMain.Decryption(Recurring[i].ChildNodes[2].InnerText).Substring(0, 2);
                                    string strMinute = frmMain.Decryption(Recurring[i].ChildNodes[2].InnerText).Substring(3);

                                    string TempHour, TempMinute;

                                    if (dtpTime.Value.Hour < 10)
                                        TempHour = "0" + dtpTime.Value.Hour;
                                    else
                                        TempHour = dtpTime.Value.Hour.ToString();

                                    if (dtpTime.Value.Minute < 10)
                                        TempMinute = "0" + dtpTime.Value.Minute;
                                    else
                                        TempMinute = dtpTime.Value.Minute.ToString();


                                    if (dtpDate.Text == frmMain.Decryption(Recurring[i].ChildNodes[1].InnerText) && strHour == TempHour && strMinute == TempMinute) // Cùng thời gian, chèn thêm vào content
                                    {
                                        iTemp = 1;

                                        // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                        for (int j = 3; j < Recurring[i].ChildNodes.Count; j++)
                                        {
                                            if (frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[1].InnerText) == txtDes.Text && frmMain.Decryption(Recurring[i].ChildNodes[j].ChildNodes[2].InnerText) == cbxRepeat.Text)
                                            {
                                                iFlag2 = 1;
                                                MessageBox.Show("A task with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                btnNew_Click(sender, e);
                                                break;
                                            }
                                        }

                                        if (iFlag2 != 1)
                                        {
                                            XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                            XmlNode nodeName = xd.CreateElement("Name");
                                            nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                            XmlNode nodeDes = xd.CreateElement("Description");
                                            nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                            XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                            nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            Recurring[i].AppendChild(nodeContent);
                                        }
                                        else
                                            break;
                                    }
                                }

                                if (iTemp != 1) // Không trùng thời gian, lưu thành một công việc mới
                                {
                                    XmlNode nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                                    XmlNode nodeID = xd.CreateElement("ID");

                                    if (Recurring.Count < 1)
                                    {
                                        nodeID.InnerText = frmMain.Encryption("0");
                                    }
                                    else
                                    {
                                        for (int i = 0; i < Recurring.Count; i++)
                                        {
                                            if (iMax < int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText)))
                                                iMax = int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText));
                                        }

                                        nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                                    }

                                    XmlNode nodeDate = xd.CreateElement("Date");
                                    nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                                    XmlNode nodeTime = xd.CreateElement("Time");
                                    nodeTime.InnerText = frmMain.Encryption(Hour + ":" + Minute);

                                    XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                    XmlNode nodeName = xd.CreateElement("Name");
                                    nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                    XmlNode nodeDes = xd.CreateElement("Description");
                                    nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                    XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                    nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

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

                                nodeID.InnerText = frmMain.Encryption("0");

                                XmlNode nodeDate = xd.CreateElement("Date");
                                nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                                XmlNode nodeTime = xd.CreateElement("Time");
                                nodeTime.InnerText = frmMain.Encryption(strTime);

                                XmlNode nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                                XmlNode nodeName = xd.CreateElement("Name");
                                nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                XmlNode nodeDes = xd.CreateElement("Description");
                                nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                XmlNode nodeRepeat = xd.CreateElement("Repeat");
                                nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

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
                                xd.Save(Application.StartupPath + "/Data/Recurring.xml");
                            }

                            #endregion

                            #endregion
                        }

                        if (iFlag == 2) // Edit
                        {
                            if (lvwListRecurring.SelectedItems.Count > 0)
                            {
                                #region Edit

                                XmlDocument doc = new XmlDocument();
                                doc.Load(Application.StartupPath + "/Data/Recurring.xml");

                                XmlElement ele = doc.DocumentElement;
                                XmlNodeList TaskList = ele.GetElementsByTagName("TaskList");
                                int iFlag3 = 0;
                                string Hour = dtpTime.Value.Hour.ToString();
                                string Minute = dtpTime.Value.Minute.ToString();

                                if (dtpTime.Value.Hour < 10)
                                    Hour = "0" + dtpTime.Value.Hour.ToString();
                                if (dtpTime.Value.Minute < 10)
                                    Minute = "0" + dtpTime.Value.Minute.ToString();

                                int iFlag2 = 0; // Task name exists

                                for (int i = 0; i < TaskList.Count; i++)
                                {
                                    if (frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText) == lvwListRecurring.SelectedItems[0].Tag.ToString())
                                    {
                                        // Kiểm tra công việc vừa edit có cùng thời gian hay không
                                        for (int ii = 0; ii < TaskList.Count; ii++)
                                        {
                                            if (frmMain.Decryption(TaskList[ii].ChildNodes[0].InnerText) != lvwListRecurring.SelectedItems[0].Tag.ToString())
                                            {
                                                if (frmMain.Decryption(TaskList[ii].ChildNodes[1].InnerText) == dtpDate.Text && frmMain.Decryption(TaskList[ii].ChildNodes[2].InnerText) == Hour + ":" + Minute)
                                                {
                                                    iFlag3 = 1;

                                                    // Kiểm tra công việc vừa sửa có trùng với dữ liệu hay không
                                                    for (int j = 3; j < TaskList[ii].ChildNodes.Count; j++)
                                                    {
                                                        if (frmMain.Decryption(TaskList[ii].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && frmMain.Decryption(TaskList[ii].ChildNodes[j].ChildNodes[1].InnerText) == txtDes.Text && frmMain.Decryption(TaskList[ii].ChildNodes[j].ChildNodes[2].InnerText) == cbxRepeat.Text)
                                                        {
                                                            iFlag2 = 1;
                                                            MessageBox.Show("A task with this name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                            dtpDate.CustomFormat = "dd/MM/yyyy";
                                                            cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;

                                                            dtpDate.MinDate = DateTime.Now;
                                                            cbxRepeat.SelectedIndex = 0;

                                                            dtpDate.Enabled = true;
                                                            txtName.ReadOnly = false;
                                                            txtDes.ReadOnly = false;
                                                            cbxRepeat.Enabled = true;
                                                            dtpTime.Enabled = true;
                                                            break;
                                                        }
                                                    }

                                                    if (iFlag2 != 1)
                                                    {
                                                        #region Thêm vào mục content

                                                        XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                        XmlNode nodeName = doc.CreateElement("Name");
                                                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                                        XmlNode nodeDes = doc.CreateElement("Description");
                                                        nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                                        XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                        nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

                                                        nodeContent.AppendChild(nodeName);
                                                        nodeContent.AppendChild(nodeDes);
                                                        nodeContent.AppendChild(nodeRepeat);

                                                        TaskList[ii].AppendChild(nodeContent);

                                                        #endregion

                                                        #region Xóa công việc trước khi edit

                                                        foreach (XmlNode nodeRemove in doc.SelectNodes("Recurring/TaskList"))
                                                        {
                                                            if (frmMain.Decryption(nodeRemove.SelectSingleNode("ID").InnerText) == lvwListRecurring.SelectedItems[0].Tag.ToString())
                                                            {
                                                                if (nodeRemove.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                                {
                                                                    for (int k = 3; k < nodeRemove.ChildNodes.Count; k++)
                                                                    {
                                                                        if (frmMain.Decryption(nodeRemove.ChildNodes[k].ChildNodes[0].InnerText) == strRecurringName && frmMain.Decryption(nodeRemove.ChildNodes[k].ChildNodes[1].InnerText) == strRecurringDes && frmMain.Decryption(nodeRemove.ChildNodes[k].ChildNodes[2].InnerText) == strRecurringRepeat)
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
                                                    else
                                                        break;
                                                }
                                            }
                                        }

                                        if (iFlag3 != 1)
                                        {
                                            if (frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText) != dtpDate.Text || frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText) != Hour + ":" + Minute) // Ngày hoặc giờ bị thay đổi
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText) == txtName.Text && frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText) == txtDes.Text && frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == cbxRepeat.Text)
                                                        {
                                                            #region Tạo một nhắc nhở mới

                                                            int iMax = 0;
                                                            int iTemp = 0;

                                                            for (int k = 0; k < TaskList.Count; k++)
                                                            {
                                                                string strHour = frmMain.Decryption(TaskList[k].ChildNodes[2].InnerText).Substring(0, 2);
                                                                string strMinute = frmMain.Decryption(TaskList[k].ChildNodes[2].InnerText).Substring(3);

                                                                if (dtpDate.Text == frmMain.Decryption(TaskList[k].ChildNodes[1].InnerText) && strHour == Hour && strMinute == Minute) // Cùng thời gian, chèn thêm vào content
                                                                {
                                                                    iTemp = 1;

                                                                    // Kiểm tra công việc vừa nhập có trùng với dữ liệu hay không
                                                                    for (int l = 3; l < TaskList[k].ChildNodes.Count; l++)
                                                                    {
                                                                        if (frmMain.Decryption(TaskList[k].ChildNodes[l].ChildNodes[0].InnerText) == txtName.Text && frmMain.Decryption(TaskList[k].ChildNodes[l].ChildNodes[1].InnerText) == txtDes.Text && frmMain.Decryption(TaskList[k].ChildNodes[l].ChildNodes[2].InnerText) == cbxRepeat.Text)
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
                                                                        nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                                                        XmlNode nodeDes = doc.CreateElement("Description");
                                                                        nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                                                        XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                        nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

                                                                        nodeContent.AppendChild(nodeName);
                                                                        nodeContent.AppendChild(nodeDes);
                                                                        nodeContent.AppendChild(nodeRepeat);

                                                                        TaskList[k].AppendChild(nodeContent);
                                                                    }
                                                                }
                                                            }

                                                            if (iTemp != 1) // Không trùng thời gian, lưu thành một công việc mới
                                                            {
                                                                XmlNode nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                                XmlNode nodeID = doc.CreateElement("ID");

                                                                if (TaskList.Count < 1)
                                                                {
                                                                    nodeID.InnerText = frmMain.Encryption("0");
                                                                }
                                                                else
                                                                {
                                                                    for (int m = 0; m < TaskList.Count; m++)
                                                                    {
                                                                        if (iMax < int.Parse(frmMain.Decryption(TaskList[m].ChildNodes[0].InnerText)))
                                                                            iMax = int.Parse(frmMain.Decryption(TaskList[m].ChildNodes[0].InnerText));
                                                                    }
                                                                    nodeID.InnerText = frmMain.Encryption((iMax + 1).ToString()); // Lấy ID cao nhất cộng thêm 1
                                                                }

                                                                XmlNode nodeDate = doc.CreateElement("Date");
                                                                nodeDate.InnerText = frmMain.Encryption(dtpDate.Text);

                                                                XmlNode nodeTime = doc.CreateElement("Time");
                                                                nodeTime.InnerText = frmMain.Encryption(Hour + ":" + Minute);

                                                                XmlNode nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                                XmlNode nodeName = doc.CreateElement("Name");
                                                                nodeName.InnerText = frmMain.Encryption(txtName.Text);

                                                                XmlNode nodeDes = doc.CreateElement("Description");
                                                                nodeDes.InnerText = frmMain.Encryption(txtDes.Text);

                                                                XmlNode nodeRepeat = doc.CreateElement("Repeat");
                                                                nodeRepeat.InnerText = frmMain.Encryption(cbxRepeat.Text);

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
                                                                if (frmMain.Decryption(nodeTaskList.SelectSingleNode("ID").InnerText) == lvwListRecurring.SelectedItems[0].Tag.ToString())
                                                                {
                                                                    if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                                    {
                                                                        for (int k = 3; k < nodeTaskList.ChildNodes.Count; k++)
                                                                        {
                                                                            if (frmMain.Decryption(nodeTaskList.ChildNodes[k].ChildNodes[0].InnerText) == UC_Recurring.strRecurringName && frmMain.Decryption(nodeTaskList.ChildNodes[k].ChildNodes[1].InnerText) == UC_Recurring.strRecurringDes && frmMain.Decryption(nodeTaskList.ChildNodes[k].ChildNodes[2].InnerText) == UC_Recurring.strRecurringRepeat)
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
                                                    TaskList[i].ChildNodes[1].InnerText = frmMain.Encryption(dtpDate.Text);
                                                    TaskList[i].ChildNodes[2].InnerText = frmMain.Encryption(Hour + ":" + Minute);
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text);
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = frmMain.Encryption(txtDes.Text);
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = frmMain.Encryption(cbxRepeat.Text);
                                                }
                                            }
                                            else // Không thay đổi ngày giờ
                                            {
                                                if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
                                                {
                                                    for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                                    {
                                                        if (frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText) == strRecurringName && frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText) == strRecurringDes && frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText) == strRecurringRepeat)
                                                        {
                                                            TaskList[i].ChildNodes[j].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text); // Name
                                                            TaskList[i].ChildNodes[j].ChildNodes[1].InnerText = frmMain.Encryption(txtDes.Text); // Description
                                                            TaskList[i].ChildNodes[j].ChildNodes[2].InnerText = frmMain.Encryption(cbxRepeat.Text); // Repeat
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    TaskList[i].ChildNodes[3].ChildNodes[0].InnerText = frmMain.Encryption(txtName.Text); // Name
                                                    TaskList[i].ChildNodes[3].ChildNodes[1].InnerText = frmMain.Encryption(txtDes.Text); // Description
                                                    TaskList[i].ChildNodes[3].ChildNodes[2].InnerText = frmMain.Encryption(cbxRepeat.Text); // Repeat
                                                }
                                            }
                                        }
                                    }

                                    if (iFlag2 == 1)
                                        break;
                                }

                                if (iFlag2 != 1)
                                {
                                    doc.Save(Application.StartupPath + "/Data/Recurring.xml");
                                }

                                #endregion
                            }
                            else
                                MessageBox.Show("No items selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        txtName.Text = "";
                        txtDes.Text = "";
                        LoadListView();
                    }
                }
                else
                {
                    MessageBox.Show("Task name or description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                    dtpDate.Enabled = true;
                    txtName.ReadOnly = false;
                    txtDes.ReadOnly = false;
                    dtpTime.Enabled = true;
                    cbxRepeat.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Fail! " + ex, "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvwListRecurring_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwListRecurring.SelectedItems.Count > 0)
            {
                iFlag = 2;

                cbxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
                dtpDate.Enabled = true;
                txtName.ReadOnly = false;
                txtDes.ReadOnly = false;
                dtpTime.Enabled = true;
                cbxRepeat.Enabled = true;

                txtName.Text = lvwListRecurring.SelectedItems[0].Text;
                strRecurringName = lvwListRecurring.SelectedItems[0].Text;

                txtDes.Text = lvwListRecurring.SelectedItems[0].SubItems[1].Text;
                strRecurringDes = lvwListRecurring.SelectedItems[0].SubItems[1].Text;

                dtpDate.MinDate = DateTime.Parse("01/01/1900");
                dtpDate.Text = DateTime.ParseExact(lvwListRecurring.SelectedItems[0].SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                dtpTime.Text = lvwListRecurring.SelectedItems[0].SubItems[3].Text;

                cbxRepeat.Text = lvwListRecurring.SelectedItems[0].SubItems[4].Text;
                strRecurringRepeat = lvwListRecurring.SelectedItems[0].SubItems[4].Text;

            }
            else
            {
                dtpDate.Enabled = false;
                txtName.ReadOnly = true;
                txtDes.ReadOnly = true;
                dtpTime.Enabled = false;
                cbxRepeat.Enabled = false;
            }
        }

        private void lvwTaskComplete_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = false;
            txtName.ReadOnly = true;
            txtDes.ReadOnly = true;
            dtpTime.Enabled = false;
            cbxRepeat.Enabled = false;

            if (lvwTaskComplete.SelectedItems.Count > 0)
            {
                txtName.Text = lvwTaskComplete.SelectedItems[0].Text;
                txtDes.Text = lvwTaskComplete.SelectedItems[0].SubItems[1].Text;
                dtpDate.MinDate = DateTime.Parse("01/01/1900");
                dtpDate.Text = DateTime.ParseExact(lvwTaskComplete.SelectedItems[0].SubItems[2].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                dtpTime.Text = lvwTaskComplete.SelectedItems[0].SubItems[3].Text;
                cbxRepeat.Text = lvwTaskComplete.SelectedItems[0].SubItems[4].Text;
            }
        }

        internal void Search(string strSearch, string strBy)
        {
            if (lvwListRecurring.Items.Count > 0)
            {
                for (int i = frmMain.iSearch; i < lvwListRecurring.Items.Count; i++)
                {
                    #region Tìm theo tên

                    if (strBy == "Name")
                    {
                        if (lvwListRecurring.Items[i].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lvwListRecurring.Focus();
                            lvwListRecurring.EnsureVisible(i);
                            lvwListRecurring.Items[i].Selected = true;

                            if (i == lvwListRecurring.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }

                        if (i == lvwListRecurring.Items.Count - 1)
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
                            if (lvwListRecurring.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                            {
                                lvwListRecurring.Focus();
                                lvwListRecurring.EnsureVisible(i);
                                lvwListRecurring.Items[i].Selected = true;

                                if (i == lvwListRecurring.Items.Count - 1)
                                {
                                    frmMain.iSearch = 0;
                                    i = 0;
                                }
                                else
                                    frmMain.iSearch = i + 1;
                                break;
                            }

                            if (i == lvwListRecurring.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                                break;
                            }
                        }

                        #endregion

                        else

                            #region Tìm theo giờ

                            if (strBy == "Time")
                            {
                                if (lvwListRecurring.Items[i].SubItems[3].Text.ToLower().Contains(strSearch.ToLower()))
                                {
                                    lvwListRecurring.Focus();
                                    lvwListRecurring.EnsureVisible(i);
                                    lvwListRecurring.Items[i].Selected = true;

                                    if (i == lvwListRecurring.Items.Count - 1)
                                    {
                                        frmMain.iSearch = 0;
                                        i = 0;
                                    }
                                    else
                                        frmMain.iSearch = i + 1;
                                    break;
                                }

                                if (i == lvwListRecurring.Items.Count - 1)
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

        private string GetDay(DateTime dt)
        {
            DateTime datetime;

            string strDay, strMonth, strYear, strTotal;

            datetime = dt;

            strDay = datetime.Day.ToString();
            strMonth = datetime.Month.ToString();
            strYear = datetime.Year.ToString();

            if (int.Parse(strDay) < 10)
                strDay = "0" + strDay;

            if (int.Parse(strMonth) < 10)
                strMonth = "0" + strMonth;

            strTotal = strDay + "/" + strMonth + "/" + strYear;

            return strTotal;
        }
    }
}