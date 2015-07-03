using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Timers;

namespace Reminiscent
{
    public static class classShowAlarm
    {
        public static string strID = "";
        public static string strName = "";
        public static string strDate = "";
        public static string strTime = "";
        public static string strSong = "";
        public static string strRepeat = "";
        public static string strSnooze = "";
        public static string strTimer = "";
        public static string strHideAll = "No";
        public static double dDelayTime = -1;
        public static int iMin = 0;

        public static void Load()
        {
            strTimer = "start";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(frmMain.strStartupPath + "/Data/Alarm.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList Alarm = root.GetElementsByTagName("Alarm");

            //Never
            string strArray = "";
            bool bStop = false;
            for (int i = 0; i < Alarm.Count; i++)
            {
                if (bStop == true)
                {
                    bStop = false;
                    break;
                }
                string strArrayRepeat = frmMain.Decryption(Alarm[i].ChildNodes[5].InnerText);
                string[] strHM = frmMain.Decryption(Alarm[i].ChildNodes[3].InnerText).Split(':');
                if (strArrayRepeat == "Never")
                {
                    strDate = frmMain.Decryption(Alarm[i].ChildNodes[2].InnerText);
                    int iDay = int.Parse(strDate.Substring(0, strDate.IndexOf("/")));
                    int iMonth = int.Parse(strDate.Substring(strDate.IndexOf("/") + 1, strDate.LastIndexOf("/") - 3));
                    int iYear = int.Parse(strDate.Substring(strDate.LastIndexOf("/") + 1));
                    strDate = iDay.ToString() + "/" + iMonth.ToString() + "/" + iYear.ToString();
                    string strDateNow = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                    if (strDate == strDateNow)
                    {
                        strArray += i + "-";
                        bStop = true;
                    }
                }
                else
                {
                    //strArray = "";
                    if (strArrayRepeat == "Weekdays")
                    {
                        strArrayRepeat = "Mon Tue Wed Thu Fri";
                    }

                    else if (strArrayRepeat == "Weekends")
                    {
                        strArrayRepeat = "Sat Sun";
                    }

                    else if (strArrayRepeat == "Every day")
                    {
                        strArrayRepeat = "Mon Tue Wed Thu Fri Sat Sun";
                    }

                    string[] strListRepeat = strArrayRepeat.Split(' ');
                    string strThu = DateTime.Now.DayOfWeek.ToString().Substring(0, 3);
                    for (int j = 0; j < strListRepeat.Length; j++)
                    {
                        if (strThu == strListRepeat[j] 
                            && (Convert.ToInt32(strHM[0]) == Convert.ToInt32(DateTime.Now.Hour)
                                && Convert.ToInt32(strHM[1]) > Convert.ToInt32(DateTime.Now.Minute))
                            || Convert.ToInt32(strHM[0]) > Convert.ToInt32(DateTime.Now.Hour))
                        {
                            strArray += i + "-";
                            bStop = true;
                            break;
                        }
                    }
                }
            }
            string[] strList = strArray.Split('-');

            if (strList.Length > 1)
            {
                // Duyệt từng công việc trong ngày
                double dDelay;
                double dMin = 24 * 3600; // Thời gian chờ ngắn nhất

                for (int i = 0; i < strList.Length - 1; i++)
                {
                    int iTemp = int.Parse(strList[i]); // Lấy ra "dòng" công việc trong ngày

                    strTime = frmMain.Decryption(Alarm[iTemp].ChildNodes[3].InnerText);

                    double dHour = double.Parse(strTime.Substring(0, 2));
                    double dMinute = double.Parse(strTime.Substring(3));

                    // Thời gian chờ = Thời gian đến công việc gần nhất - Thời gian hiện tại
                    dDelay = (dHour * 3600 + dMinute * 60) -
                        (double.Parse(DateTime.Now.Hour.ToString()) * 3600
                        + double.Parse(DateTime.Now.Minute.ToString()) * 60
                        + double.Parse(DateTime.Now.Second.ToString()));

                    if (dMin > dDelay)
                    {
                        dMin = dDelay;
                        iMin = iTemp;
                    }
                }

                dDelayTime = dMin;
                if (dDelayTime < 0)
                    dDelayTime = -1;
            }
        }

        public static void Save()
        {
            strTimer = "stop";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(frmMain.strStartupPath + "/Data/Alarm.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList Alarm = root.GetElementsByTagName("Alarm");

            strID = frmMain.Decryption(Alarm[iMin].ChildNodes[0].InnerText);
            strName = frmMain.Decryption(Alarm[iMin].ChildNodes[1].InnerText);
            strDate = frmMain.Decryption(Alarm[iMin].ChildNodes[2].InnerText);
            strTime = frmMain.Decryption(Alarm[iMin].ChildNodes[3].InnerText);
            strSong = frmMain.Decryption(Alarm[iMin].ChildNodes[4].InnerText);
            strRepeat = frmMain.Decryption(Alarm[iMin].ChildNodes[5].InnerText);
            strSnooze = frmMain.Decryption(Alarm[iMin].ChildNodes[6].InnerText);

            strHideAll = "Yes";
            ShowAlarm sa = new ShowAlarm();
            sa.Show();

            #region Save Alarm
            // Sửa, xóa công việc đã nhắc nhở trong tập tin Alarm.xml

            XmlDocument doc = new XmlDocument();
            doc.Load(frmMain.strStartupPath + "/Data/Alarm.xml");

            foreach (XmlNode node in doc.SelectNodes("AlarmList/Alarm"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == strID)
                {
                    if (frmMain.Decryption(node.SelectSingleNode("Repeat").InnerText) == "Never")
                    {
                        node.ParentNode.RemoveChild(node);

                        #region History
                        // Lưu những công việc đã nhắc nhở vào tập tin History.xml

                        if (!File.Exists(frmMain.strStartupPath + "/Data/AlarmHistory.xml")) // Chưa tồn tại tập tin History.xml
                        {
                            XmlTextWriter writer = new XmlTextWriter(frmMain.strStartupPath + "/Data/AlarmHistory.xml", Encoding.UTF8);
                            writer.Formatting = Formatting.Indented; //Xuống dòng
                            writer.WriteStartDocument();
                            writer.WriteStartElement("AlarmList");
                            writer.WriteEndElement();
                            writer.WriteEndDocument();
                            writer.Flush();
                            writer.Close();
                        }

                        // Xử lý tập tin History.xml
                        XmlDocument xd = new XmlDocument();
                        xd.Load(frmMain.strStartupPath + "/Data/Alarm.xml");

                        XmlElement ele = xd.DocumentElement;

                        XmlNode nodeAlarm = xd.CreateNode(XmlNodeType.Element, "Alarm", null);

                        XmlNode nodeID = xd.CreateElement("ID");
                        nodeID.InnerText = strID;

                        XmlNode nodeName = xd.CreateElement("Name");
                        nodeName.InnerText = strName;

                        XmlNode nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = strDate;

                        XmlNode nodeTime = xd.CreateElement("Time");
                        nodeTime.InnerText = strTime;

                        XmlNode nodeSong = xd.CreateElement("Song");
                        nodeSong.InnerText = strSong;

                        XmlNode nodeRepeat = xd.CreateElement("Repeat");
                        nodeRepeat.InnerText = strRepeat;

                        XmlNode nodeSnooze = xd.CreateElement("Snooze");
                        nodeSnooze.InnerText = strSnooze;

                        nodeAlarm.AppendChild(nodeID);
                        nodeAlarm.AppendChild(nodeName);
                        nodeAlarm.AppendChild(nodeDate);
                        nodeAlarm.AppendChild(nodeTime);
                        nodeAlarm.AppendChild(nodeSong);
                        nodeAlarm.AppendChild(nodeRepeat);
                        nodeAlarm.AppendChild(nodeSnooze);

                        xd.DocumentElement.AppendChild(nodeAlarm);
                        xd.Save(frmMain.strStartupPath + "/Data/AlarmHistory.xml");

                        #endregion
                    }
                }
                strTimer = "start";
                doc.Save(frmMain.strStartupPath + "/Data/Alarm.xml");
            }
            #endregion

            dDelayTime = -1;
        }
    }
}
