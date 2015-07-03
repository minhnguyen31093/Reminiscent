using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace Reminiscent
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        private void UC_Home_Load(object sender, EventArgs e)
        {
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
                    lbl1.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lbl2.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    break;
                }
            }
            #endregion

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
                    this.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg2").InnerText)));
                    break;
                }
            }
            #endregion
        }
    }
}
