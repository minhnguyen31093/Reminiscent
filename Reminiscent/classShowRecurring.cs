using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Timers;

namespace Reminiscent
{
    public static class classShowRecurring
    {
        public static string strRecurringID = "";
        public static string strRecurringName = "";
        public static string strRecurringDes = "";
        public static string strRecurringDate = "";
        public static string strRecurringTime = "";
        public static string strRecurringRepeat = "";

        public static string strTimeMain = "";
        public static string strRefresh = "";
        public static double dDelayTime = -1;

        public static int iMin = 0;

        public static void Load()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(frmMain.strStartupPath + "/Data/Recurring.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList TaskList = root.GetElementsByTagName("TaskList");

            string strArray = "";

            for (int i = 0; i < TaskList.Count; i++)
            {
                // Chuyển định dạng trong máy sang dạng dd/MM/yyyy
                strRecurringDate = frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText);

                int iDay = int.Parse(strRecurringDate.Substring(0, strRecurringDate.IndexOf("/")));
                int iMonth = int.Parse(strRecurringDate.Substring(strRecurringDate.IndexOf("/") + 1, strRecurringDate.LastIndexOf("/") - 3));
                int iYear = int.Parse(strRecurringDate.Substring(strRecurringDate.LastIndexOf("/") + 1));

                strRecurringDate = iDay.ToString() + "/" + iMonth.ToString() + "/" + iYear.ToString();

                // Lọc ra danh sách các công việc cần làm trong ngày hôm nay
                string strDateNow = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                if (strRecurringDate == strDateNow)
                {
                    strArray += i + "-"; // Lưu những dòng có công việc cần làm trong ngày.
                }
            }
            string[] strList = strArray.Split('-'); // Danh sách các công việc trong ngày

            if (strList.Length > 1)
            {
                // Duyệt từng công việc trong ngày
                double dDelay;
                double dMin = 24 * 3600 * 1000; // Thời gian chờ ngắn nhất

                for (int i = 0; i < strList.Length - 1; i++)
                {
                    int iTemp = int.Parse(strList[i]); // Lấy ra "dòng" công việc trong ngày

                    strRecurringTime = frmMain.Decryption(TaskList[iTemp].ChildNodes[2].InnerText);

                    double dHour = double.Parse(strRecurringTime.Substring(0, 2));
                    double dMinute = double.Parse(strRecurringTime.Substring(3));

                    // Thời gian chờ = Thời gian đến công việc gần nhất - Thời gian hiện tại
                    dDelay = (dHour * 3600 + dMinute * 60) -
                        (double.Parse(DateTime.Now.Hour.ToString()) * 3600
                        + double.Parse(DateTime.Now.Minute.ToString()) * 60
                        + double.Parse(DateTime.Now.Second.ToString()));

                    dDelay = dDelay * 1000;

                    if (dMin > dDelay && dDelay >= 0)
                    {
                        dMin = dDelay;
                        iMin = iTemp;
                    }
                }
                //timerMain.Interval = Convert.ToInt32(dMin);

                dDelayTime = dMin;
                if (dDelayTime < 0)
                    dDelayTime = -1;
            }
        }

        //public static void Delayed()
        //{
        //    System.Windows.Forms.Timer delaytime = new System.Windows.Forms.Timer();
        //    delaytime.Interval = delay;
        //    delaytime.Tick += (s, e) =>
        //    {
        //        //action();
        //        delaytime.Stop();
        //    };
        //    delaytime.Start();
        //}

        public static int GetMaxDay(int iMonth, int iYear) //Lấy ngày cuối cùng của tháng
        {
            int iDay = DateTime.DaysInMonth(iYear, iMonth);
            return iDay;
        }

        public static void Save()
        {
            dDelayTime = -1;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(frmMain.strStartupPath + "/Data/Recurring.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList TaskList = root.GetElementsByTagName("TaskList");

            strRecurringID = frmMain.Decryption(TaskList[iMin].ChildNodes[0].InnerText);
            strRecurringDate = frmMain.Decryption(TaskList[iMin].ChildNodes[1].InnerText);
            strRecurringTime = frmMain.Decryption(TaskList[iMin].ChildNodes[2].InnerText);

            strRecurringName = "";
            strRecurringDes = "";
            strRecurringRepeat = "";

            for (int i = 3; i < TaskList[iMin].ChildNodes.Count; i++)
            {
                strRecurringName = strRecurringName + " + " + frmMain.Decryption(TaskList[iMin].ChildNodes[i].ChildNodes[0].InnerText);
                strRecurringDes = strRecurringDes + " + " + frmMain.Decryption(TaskList[iMin].ChildNodes[i].ChildNodes[1].InnerText);
                strRecurringRepeat = strRecurringRepeat + " + " + frmMain.Decryption(TaskList[iMin].ChildNodes[i].ChildNodes[2].InnerText);
            }

            strRecurringName = strRecurringName.Substring(3);
            strRecurringDes = strRecurringDes.Substring(3);
            strRecurringRepeat = strRecurringRepeat.Substring(3);

            //strList = strRecurringRepeat.Split('+');

            strTimeMain = "Stop";
                    
            frmShowRecurring2 sr2 = new frmShowRecurring2();
            sr2.ShowDialog();

            #region Tạo tập tin History.xml

            if (!File.Exists(frmMain.strStartupPath + "/Data/History.xml")) // Chưa tồn tại tập tin History.xml
            {
                XmlTextWriter writer = new XmlTextWriter(frmMain.strStartupPath + "/Data/History.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented; //Xuống dòng
                writer.WriteStartDocument();
                writer.WriteStartElement("Recurring");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            #endregion

            #region Xử lý tập tin History.xml

            XmlNode nodeContent;

            XmlNode nodeName;
            XmlNode nodeDes;
            XmlNode nodeRepeat;

            XmlNode nodeTaskList;
            XmlNode nodeID;
            XmlNode nodeDate;
            XmlNode nodeTime;

            if (TaskList[iMin].ChildNodes.Count < 5) // Không có nhiều công việc cùng một thời điểm
            {
                if (frmMain.Decryption(TaskList[iMin].ChildNodes[3].ChildNodes[2].InnerText) == "Never")
                {
                    XmlDocument xd = new XmlDocument();
                    xd.Load(frmMain.strStartupPath + "/Data/History.xml");

                    XmlElement ele = xd.DocumentElement;

                    XmlNodeList Recurring = ele.GetElementsByTagName("TaskList");

                    nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                    nodeID = xd.CreateElement("ID");

                    if (Recurring.Count < 1)
                    {
                        nodeID.InnerText = "0";
                    }
                    else
                    {
                        int iMax = 0;

                        for (int i = 0; i < Recurring.Count; i++)
                        {
                            if (iMax < int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText)))
                                iMax = int.Parse(frmMain.Decryption(Recurring[i].ChildNodes[0].InnerText));
                        }

                        nodeID.InnerText = (iMax + 1).ToString(); // Lấy ID cao nhất cộng thêm 1
                    }

                    string strDay, strMonth, strYear;

                    if (DateTime.Now.Day < 10)
                        strDay = "0" + DateTime.Now.Day;
                    else
                        strDay = DateTime.Now.Day.ToString();

                    if (DateTime.Now.Month < 10)
                        strMonth = "0" + DateTime.Now.Month;
                    else
                        strMonth = DateTime.Now.Month.ToString();

                    strYear = DateTime.Now.Year.ToString();

                    nodeDate = xd.CreateElement("Date");
                    nodeDate.InnerText = strDay + "/" + strMonth + "/" + strYear;

                    nodeTime = xd.CreateElement("Time");
                    nodeTime.InnerText = strRecurringTime;

                    nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                    nodeName = xd.CreateElement("Name");
                    nodeDes = xd.CreateElement("Description");
                    nodeRepeat = xd.CreateElement("Repeat");

                    nodeName.InnerText = strRecurringName;
                    nodeDes.InnerText = strRecurringDes;
                    nodeRepeat.InnerText = TaskList[iMin].ChildNodes[3].ChildNodes[2].InnerText;

                    nodeName.InnerText = frmMain.Encryption(nodeName.InnerText);
                    nodeDes.InnerText = frmMain.Encryption(nodeDes.InnerText);
                    nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);
                    nodeDate.InnerText = frmMain.Encryption(nodeDate.InnerText);
                    nodeTime.InnerText = frmMain.Encryption(nodeTime.InnerText);

                    nodeContent.AppendChild(nodeName);
                    nodeContent.AppendChild(nodeDes);
                    nodeContent.AppendChild(nodeRepeat);

                    nodeTaskList.AppendChild(nodeID);
                    nodeTaskList.AppendChild(nodeDate);
                    nodeTaskList.AppendChild(nodeTime);
                    nodeTaskList.AppendChild(nodeContent);

                    xd.DocumentElement.AppendChild(nodeTaskList);

                    xd.Save(frmMain.strStartupPath + "/Data/History.xml");
                }
            }
            else // Nhiều công việc chung một thời điểm
            {
                for (int i = 3; i < TaskList[iMin].ChildNodes.Count; i++)
                {
                    if (frmMain.Decryption(TaskList[iMin].ChildNodes[i].ChildNodes[2].InnerText) == "Never")
                    {
                        XmlDocument xd = new XmlDocument();
                        xd.Load(frmMain.strStartupPath + "/Data/History.xml");

                        XmlElement ele = xd.DocumentElement;

                        XmlNodeList Recurring = ele.GetElementsByTagName("TaskList");

                        nodeTaskList = xd.CreateNode(XmlNodeType.Element, "TaskList", null);

                        nodeID = xd.CreateElement("ID");

                        if (Recurring.Count < 1)
                        {
                            nodeID.InnerText = "0";
                        }
                        else
                        {
                            int iMax = 0;

                            for (int a = 0; a < Recurring.Count; a++)
                            {
                                if (iMax < int.Parse(frmMain.Decryption(Recurring[a].ChildNodes[0].InnerText)))
                                    iMax = int.Parse(frmMain.Decryption(Recurring[a].ChildNodes[0].InnerText));
                            }

                            nodeID.InnerText = (iMax + 1).ToString(); // Lấy ID cao nhất cộng thêm 1
                        }

                        string strDay, strMonth, strYear;

                        if (DateTime.Now.Day < 10)
                            strDay = "0" + DateTime.Now.Day;
                        else
                            strDay = DateTime.Now.Day.ToString();

                        if (DateTime.Now.Month < 10)
                            strMonth = "0" + DateTime.Now.Month;
                        else
                            strMonth = DateTime.Now.Month.ToString();

                        strYear = DateTime.Now.Year.ToString();

                        nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = strDay + "/" + strMonth + "/" + strYear;

                        nodeTime = xd.CreateElement("Time");
                        nodeTime.InnerText = strRecurringTime;

                        nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);

                        nodeName = xd.CreateElement("Name");
                        nodeDes = xd.CreateElement("Description");
                        nodeRepeat = xd.CreateElement("Repeat");

                        nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);
                        nodeDate.InnerText = frmMain.Encryption(nodeDate.InnerText);
                        nodeTime.InnerText = frmMain.Encryption(nodeTime.InnerText);

                        nodeTaskList.AppendChild(nodeID);
                        nodeTaskList.AppendChild(nodeDate);
                        nodeTaskList.AppendChild(nodeTime);

                        nodeName.InnerText = TaskList[iMin].ChildNodes[i].ChildNodes[0].InnerText;
                        nodeDes.InnerText = TaskList[iMin].ChildNodes[i].ChildNodes[1].InnerText;
                        nodeRepeat.InnerText = TaskList[iMin].ChildNodes[i].ChildNodes[2].InnerText;

                        nodeContent.AppendChild(nodeName);
                        nodeContent.AppendChild(nodeDes);
                        nodeContent.AppendChild(nodeRepeat);

                        nodeTaskList.AppendChild(nodeContent);


                        //for (int b = 3; b < TaskList[iMin].ChildNodes.Count; b++)
                        //{
                        //    nodeContent = xd.CreateNode(XmlNodeType.Element, "Content", null);
                        //    nodeName = xd.CreateElement("Name");
                        //    nodeDes = xd.CreateElement("Description");
                        //    nodeRepeat = xd.CreateElement("Repeat");

                        //    nodeName.InnerText = TaskList[iMin].ChildNodes[b].ChildNodes[0].InnerText;
                        //    nodeDes.InnerText = TaskList[iMin].ChildNodes[b].ChildNodes[1].InnerText;
                        //    nodeRepeat.InnerText = TaskList[iMin].ChildNodes[b].ChildNodes[2].InnerText;

                        //    nodeContent.AppendChild(nodeName);
                        //    nodeContent.AppendChild(nodeDes);
                        //    nodeContent.AppendChild(nodeRepeat);

                        //    nodeTaskList.AppendChild(nodeContent);
                        //}

                        xd.DocumentElement.AppendChild(nodeTaskList);

                        xd.Save(frmMain.strStartupPath + "/Data/History.xml");
                    }
                }
            }

            #endregion

            #region Sửa, xóa công việc đã nhắc nhở trong tập tin Recurring.xml

            XmlDocument doc = new XmlDocument();
            doc.Load(frmMain.strStartupPath + "/Data/Recurring.xml");
            //int iNever = 0;

            foreach (XmlNode node in doc.SelectNodes("Recurring/TaskList"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == strRecurringID)
                {
                    int i;
                    for (i = 3; i < node.ChildNodes.Count; i++)
                    {
                        if (frmMain.Decryption(node.ChildNodes[i].ChildNodes[2].InnerText) != "Never")
                        {
                            //iNever = 0;

                            string strDay = "";
                            string strMonth = "";
                            string strYear = "";
                            int iMax = 0;

                            #region Hằng ngày

                            if (frmMain.Decryption(node.ChildNodes[i].ChildNodes[2].InnerText) == "Daily") // Lặp lại hằng ngày
                            {
                                strMonth = DateTime.Now.Month.ToString();
                                strYear = DateTime.Now.Year.ToString();

                                strDay = (DateTime.Now.Day + 1).ToString();

                                if (int.Parse(strDay) > GetMaxDay(DateTime.Now.Month, DateTime.Now.Year)) // Qua tháng mới
                                {
                                    strDay = (int.Parse(strDay) - GetMaxDay(DateTime.Now.Month, DateTime.Now.Year)).ToString();
                                    strMonth = (DateTime.Now.Month + 1).ToString();

                                    if (DateTime.Now.Month == 12)
                                    {
                                        strMonth = "1";
                                        strYear = (DateTime.Now.Year + 1).ToString();
                                    }
                                }

                                if (int.Parse(strDay) < 10)
                                    strDay = "0" + strDay;
                                if (int.Parse(strMonth) < 10)
                                    strMonth = "0" + strMonth;

                                string strTemp = strDay + "/" + strMonth + "/" + strYear;
                                int iFlag = 0;

                                foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                {
                                    if (frmMain.Decryption(node2.ChildNodes[0].InnerText) != strRecurringID && strTemp == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(node.SelectSingleNode("Time").InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                    {
                                        iFlag = 1;

                                        nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                        nodeName = doc.CreateElement("Name");
                                        nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                        nodeDes = doc.CreateElement("Description");
                                        nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                        nodeRepeat = doc.CreateElement("Repeat");
                                        nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                        nodeContent.AppendChild(nodeName);
                                        nodeContent.AppendChild(nodeDes);
                                        nodeContent.AppendChild(nodeRepeat);

                                        node2.AppendChild(nodeContent);

                                        doc.Save(frmMain.strStartupPath + "/Data/Recurring.xml");
                                    }
                                }

                                if (iFlag != 1) // Tạo công việc mới
                                {
                                    node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDay + "/" + strMonth + "/" + strYear);

                                    nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                    nodeID = doc.CreateElement("ID");

                                    if (node.ParentNode.ChildNodes.Count < 1)
                                    {
                                        nodeID.InnerText = "0";
                                    }
                                    else
                                    {
                                        for (int j = 0; j < node.ParentNode.ChildNodes.Count; j++)
                                        {
                                            if (iMax < int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText)))
                                                iMax = int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText));
                                        }
                                        iMax += 1;
                                        nodeID.InnerText = (iMax).ToString(); // Lấy ID cao nhất cộng thêm 1
                                    }

                                    nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);

                                    nodeDate = doc.CreateElement("Date");
                                    nodeDate.InnerText = node.SelectSingleNode("Date").InnerText;

                                    nodeTime = doc.CreateElement("Time");
                                    nodeTime.InnerText = node.SelectSingleNode("Time").InnerText;

                                    nodeTaskList.AppendChild(nodeID);
                                    nodeTaskList.AppendChild(nodeDate);
                                    nodeTaskList.AppendChild(nodeTime);

                                    nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                    nodeName = doc.CreateElement("Name");
                                    nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                    nodeDes = doc.CreateElement("Description");
                                    nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                    nodeRepeat = doc.CreateElement("Repeat");
                                    nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                    nodeContent.AppendChild(nodeName);
                                    nodeContent.AppendChild(nodeDes);
                                    nodeContent.AppendChild(nodeRepeat);

                                    nodeTaskList.AppendChild(nodeContent);

                                    doc.DocumentElement.AppendChild(nodeTaskList);
                                }
                            } // Đóng lặp lại hằng ngày

                            #endregion

                                #region Hằng tuần
                            else
                                if (frmMain.Decryption(node.ChildNodes[i].ChildNodes[2].InnerText) == "Weekly") // Lặp lại hàng tuần
                                {
                                    strMonth = DateTime.Now.Month.ToString();
                                    strYear = DateTime.Now.Year.ToString();

                                    strDay = (DateTime.Now.Day + 7).ToString();

                                    if (int.Parse(strDay) > GetMaxDay(DateTime.Now.Month, DateTime.Now.Year)) //Qua tháng mới
                                    {
                                        strDay = (int.Parse(strDay) - GetMaxDay(DateTime.Now.Month, DateTime.Now.Year)).ToString();
                                        strMonth = (DateTime.Now.Month + 1).ToString();

                                        if (DateTime.Now.Month == 12)
                                        {
                                            strMonth = "1";
                                            strYear = (DateTime.Now.Year + 1).ToString();
                                        }
                                    }

                                    if (int.Parse(strDay) < 10)
                                        strDay = "0" + strDay;
                                    if (int.Parse(strMonth) < 10)
                                        strMonth = "0" + strMonth;

                                    string strTemp = strDay + "/" + strMonth + "/" + strYear;
                                    int iFlag = 0;

                                    foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                    {
                                        if (strTemp == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(node.SelectSingleNode("Time").InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                        {
                                            iFlag = 1;

                                            nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                            nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                            nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            node2.AppendChild(nodeContent);
                                        }
                                    }

                                    if (iFlag != 1) // Tạo công việc mới
                                    {
                                        node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDay + "/" + strMonth + "/" + strYear);

                                        nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                        nodeID = doc.CreateElement("ID");

                                        if (node.ParentNode.ChildNodes.Count < 1)
                                        {
                                            nodeID.InnerText = "0";
                                        }
                                        else
                                        {
                                            for (int j = 0; j < node.ParentNode.ChildNodes.Count; j++)
                                            {
                                                if (iMax < int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText)))
                                                    iMax = int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText));
                                            }
                                            iMax += 1;
                                            nodeID.InnerText = (iMax).ToString(); // Lấy ID cao nhất cộng thêm 1
                                        }

                                        nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);

                                        nodeDate = doc.CreateElement("Date");
                                        nodeDate.InnerText = node.SelectSingleNode("Date").InnerText;

                                        nodeTime = doc.CreateElement("Time");
                                        nodeTime.InnerText = node.SelectSingleNode("Time").InnerText;

                                        nodeTaskList.AppendChild(nodeID);
                                        nodeTaskList.AppendChild(nodeDate);
                                        nodeTaskList.AppendChild(nodeTime);

                                        nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                        nodeName = doc.CreateElement("Name");
                                        nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                        nodeDes = doc.CreateElement("Description");
                                        nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                        nodeRepeat = doc.CreateElement("Repeat");
                                        nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                        nodeContent.AppendChild(nodeName);
                                        nodeContent.AppendChild(nodeDes);
                                        nodeContent.AppendChild(nodeRepeat);

                                        nodeTaskList.AppendChild(nodeContent);

                                        doc.DocumentElement.AppendChild(nodeTaskList);
                                    }

                                } // Đóng lặp lại hằng tuần

                            #endregion

                                    #region Hằng tháng
                                else
                                    if (frmMain.Decryption(node.ChildNodes[i].ChildNodes[2].InnerText) == "Monthly") // Lặp lại hằng tháng
                                    {
                                        strYear = DateTime.Now.Year.ToString();
                                        strMonth = (DateTime.Now.Month + 1).ToString();
                                        strDay = DateTime.Now.Day.ToString();

                                        if (DateTime.Now.Month == 12)
                                        {
                                            strMonth = "1";
                                            strYear = (DateTime.Now.Year + 1).ToString();
                                        }
                                        else
                                            if (DateTime.Now.Month == 3 || DateTime.Now.Month == 5 || DateTime.Now.Month == 8 || DateTime.Now.Month == 10)
                                            {
                                                if (DateTime.Now.Day > 30) // Ngày hiện tại là 31
                                                    strDay = GetMaxDay(DateTime.Now.Month + 1, DateTime.Now.Year).ToString();
                                            }
                                            else
                                                if (DateTime.Now.Month == 1)
                                                {
                                                    if (DateTime.Now.Day > 28)
                                                        strDay = GetMaxDay(DateTime.Now.Month + 1, DateTime.Now.Year).ToString();
                                                }

                                        // Thêm số 0 vào những ngày/tháng nhỏ hơn 10. Ví dụ: 9 ~> 09
                                        if (int.Parse(strDay) < 10)
                                            strDay = "0" + strDay;
                                        if (int.Parse(strMonth) < 10)
                                            strMonth = "0" + strMonth;

                                        string strTemp = strDay + "/" + strMonth + "/" + strYear;
                                        int iFlag = 0;

                                        foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                        {
                                            if (strTemp == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(node.SelectSingleNode("Time").InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                            {
                                                iFlag = 1;

                                                nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                                nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                                nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                node2.AppendChild(nodeContent);
                                            }
                                        }

                                        if (iFlag != 1) // Tạo công việc mới
                                        {
                                            node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDay + "/" + strMonth + "/" + strYear);

                                            nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                            nodeID = doc.CreateElement("ID");

                                            if (node.ParentNode.ChildNodes.Count < 1)
                                            {
                                                nodeID.InnerText = "0";
                                            }
                                            else
                                            {
                                                for (int j = 0; j < node.ParentNode.ChildNodes.Count; j++)
                                                {
                                                    if (iMax < int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText)))
                                                        iMax = int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText));
                                                }
                                                iMax += 1;
                                                nodeID.InnerText = (iMax).ToString(); // Lấy ID cao nhất cộng thêm 1
                                            }

                                            nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);

                                            nodeDate = doc.CreateElement("Date");
                                            nodeDate.InnerText = node.SelectSingleNode("Date").InnerText;

                                            nodeTime = doc.CreateElement("Time");
                                            nodeTime.InnerText = node.SelectSingleNode("Time").InnerText;

                                            nodeTaskList.AppendChild(nodeID);
                                            nodeTaskList.AppendChild(nodeDate);
                                            nodeTaskList.AppendChild(nodeTime);

                                            nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                            nodeName = doc.CreateElement("Name");
                                            nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                            nodeDes = doc.CreateElement("Description");
                                            nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                            nodeRepeat = doc.CreateElement("Repeat");
                                            nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                            nodeContent.AppendChild(nodeName);
                                            nodeContent.AppendChild(nodeDes);
                                            nodeContent.AppendChild(nodeRepeat);

                                            nodeTaskList.AppendChild(nodeContent);

                                            doc.DocumentElement.AppendChild(nodeTaskList);
                                        }

                                    } // Đóng lặp lại hằng tháng

                                #endregion

                                        #region Hằng năm
                                    else
                                        if (frmMain.Decryption(node.ChildNodes[i].ChildNodes[2].InnerText) == "Yearly") // Lặp lại hằng năm
                                        {
                                            strYear = (DateTime.Now.Year + 1).ToString();
                                            strMonth = DateTime.Now.Month.ToString();
                                            strDay = DateTime.Now.Day.ToString();

                                            if (DateTime.Now.Day == 29 && DateTime.Now.Month == 2)
                                                strDay = GetMaxDay(DateTime.Now.Month, DateTime.Now.Year + 1).ToString();

                                            if (int.Parse(strDay) < 10)
                                                strDay = "0" + strDay;
                                            if (int.Parse(strMonth) < 10)
                                                strMonth = "0" + strMonth;

                                            string strTemp = strDay + "/" + strMonth + "/" + strYear;
                                            int iFlag = 0;

                                            foreach (XmlNode node2 in doc.SelectNodes("Recurring/TaskList"))
                                            {
                                                if (strTemp == frmMain.Decryption(node2.ChildNodes[1].InnerText) && frmMain.Decryption(node.SelectSingleNode("Time").InnerText) == frmMain.Decryption(node2.ChildNodes[2].InnerText)) // Ngày giờ đã tồn tại -> Thêm vào content
                                                {
                                                    iFlag = 1;

                                                    nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                    nodeName = doc.CreateElement("Name");
                                                    nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                                    nodeDes = doc.CreateElement("Description");
                                                    nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                                    nodeRepeat = doc.CreateElement("Repeat");
                                                    nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                                    nodeContent.AppendChild(nodeName);
                                                    nodeContent.AppendChild(nodeDes);
                                                    nodeContent.AppendChild(nodeRepeat);

                                                    node2.AppendChild(nodeContent);
                                                }
                                            }

                                            if (iFlag != 1) // Tạo công việc mới
                                            {
                                                node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDay + "/" + strMonth + "/" + strYear);

                                                nodeTaskList = doc.CreateNode(XmlNodeType.Element, "TaskList", null);

                                                nodeID = doc.CreateElement("ID");

                                                if (node.ParentNode.ChildNodes.Count < 1)
                                                {
                                                    nodeID.InnerText = "0";
                                                }
                                                else
                                                {
                                                    for (int j = 0; j < node.ParentNode.ChildNodes.Count; j++)
                                                    {
                                                        if (iMax < int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText)))
                                                            iMax = int.Parse(frmMain.Decryption(node.ParentNode.ChildNodes[j].ChildNodes[0].InnerText));
                                                    }
                                                    iMax += 1;
                                                    nodeID.InnerText = (iMax).ToString(); // Lấy ID cao nhất cộng thêm 1
                                                }

                                                nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);

                                                nodeDate = doc.CreateElement("Date");
                                                nodeDate.InnerText = node.SelectSingleNode("Date").InnerText;

                                                nodeTime = doc.CreateElement("Time");
                                                nodeTime.InnerText = node.SelectSingleNode("Time").InnerText;

                                                nodeTaskList.AppendChild(nodeID);
                                                nodeTaskList.AppendChild(nodeDate);
                                                nodeTaskList.AppendChild(nodeTime);

                                                nodeContent = doc.CreateNode(XmlNodeType.Element, "Content", null);

                                                nodeName = doc.CreateElement("Name");
                                                nodeName.InnerText = node.ChildNodes[i].ChildNodes[0].InnerText;

                                                nodeDes = doc.CreateElement("Description");
                                                nodeDes.InnerText = node.ChildNodes[i].ChildNodes[1].InnerText;

                                                nodeRepeat = doc.CreateElement("Repeat");
                                                nodeRepeat.InnerText = node.ChildNodes[i].ChildNodes[2].InnerText;

                                                nodeContent.AppendChild(nodeName);
                                                nodeContent.AppendChild(nodeDes);
                                                nodeContent.AppendChild(nodeRepeat);

                                                nodeTaskList.AppendChild(nodeContent);

                                                doc.DocumentElement.AppendChild(nodeTaskList);
                                            }

                                        } // Đóng lặp lại hằng năm

                                    #endregion

                        } // Đóng công việc lặp lại
                    }
                }

                if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == strRecurringID) // Xóa nhắc nhở cũ
                    node.ParentNode.RemoveChild(node);

                doc.Save(frmMain.strStartupPath + "/Data/Recurring.xml");
                strTimeMain = "Start";

                strRefresh = "Yes";

            }

            #endregion
        }
    }
}
