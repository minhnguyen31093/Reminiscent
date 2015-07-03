using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace Reminiscent
{
    public static class classShowSticky
    {
        public static int iID = 0;
        public static string strNoteDate = "";
        public static string strTextNote= "";
        public static int iSizeX = 0;
        public static int iSizeY = 0;
        public static int iLocationX = 0;
        public static int iLocationY = 0;
        public static string strColor = "";
        public static string strOnTop = "";

        public static void Load()
        {
            if (File.Exists(frmMain.strStartupPath + "/Data/StickyNote.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(frmMain.strStartupPath + "/Data/StickyNote.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Notes = root.GetElementsByTagName("Notes");

                for (int i = 0; i < Notes.Count; i++)
                {
                    try
                    {
                        if (Notes[i].ChildNodes[9].InnerText == "Yes")
                        {
                            frmStickyNote sn = new frmStickyNote();
                            iID = Convert.ToInt32(Notes[i].ChildNodes[0].InnerText);
                            strNoteDate = Notes[i].ChildNodes[1].InnerText;
                            strTextNote = Notes[i].ChildNodes[2].InnerText;
                            iSizeX = Convert.ToInt32(Notes[i].ChildNodes[3].InnerText);
                            iSizeY = Convert.ToInt32(Notes[i].ChildNodes[4].InnerText);
                            iLocationX = Convert.ToInt32(Notes[i].ChildNodes[5].InnerText);
                            iLocationY = Convert.ToInt32(Notes[i].ChildNodes[6].InnerText);
                            strColor = Notes[i].ChildNodes[7].InnerText;
                            strOnTop = Notes[i].ChildNodes[8].InnerText;
                            sn.Show();
                        }
                    }
                    catch
                    {
                        File.Delete(frmMain.strStartupPath + "/Data/StickyNote.xml.bk");
                        File.Copy(frmMain.strStartupPath + "/Data/StickyNote.xml", frmMain.strStartupPath + "/Data/StickyNote.xml.bk");
                        File.Delete(frmMain.strStartupPath + "/Data/StickyNote.xml");
                        XmlTextWriter writer = new XmlTextWriter(frmMain.strStartupPath + "/Data/StickyNote.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Sticky");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        break;
                    }
                }
            }
        }
    }
}
