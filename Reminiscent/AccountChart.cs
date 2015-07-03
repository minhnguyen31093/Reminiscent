using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;//DllImportAttribute
using System.Xml;

namespace Reminiscent
{
    public partial class AccountChart : Form
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        public AccountChart()
        {
            InitializeComponent();
        }

        #region Moveable with Panel\\
        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //[DllImportAttribute("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        //[DllImportAttribute("user32.dll")]
        //public static extern bool ReleaseCapture();

        private void AccountChart_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    ReleaseCapture();
            //    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            //}
        }
        #endregion

        private void AccountChart_Load(object sender, EventArgs e)
        {
            ChartPanel.Invalidate();
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
                    btnSave.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnClose.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    break;
                }
            }
            #endregion
        }

        #region Chart
        private void ChartPanel_Paint(object sender, PaintEventArgs e)
        {
            
            //Tạo Graphic
            Graphics gfx = e.Graphics;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //Tạo Pen (màu của graphic)
            Pen p = new Pen(Color.Black, 1);
            //Pen pline = new Pen(Color.Red, 2);
            Pen plineR = new Pen(Color.Blue, 2);
            Pen plineE = new Pen(Color.Red, 2);
            //(pen, x1, y1, x2, y2)

            #region Trục y
            int iChieuCao = (e.ClipRectangle.Height - 40) - 20;
            gfx.DrawLine(p, 40, 20, 37, 30);                            //MT-Trái-1
            gfx.DrawLine(p, 40, 20, 43, 30);                            //MT-Trái-2
            gfx.DrawLine(p, 40, 20, 40, e.ClipRectangle.Height - 40);   //Trái
            #endregion

            #region Trục x
            int iChieuDai = (e.ClipRectangle.Width - 20) - 40;
            gfx.DrawLine(p, e.ClipRectangle.Width - 30, e.ClipRectangle.Height - 37, e.ClipRectangle.Width - 20, e.ClipRectangle.Height - 40);   //MT-Dưới-1
            gfx.DrawLine(p, e.ClipRectangle.Width - 30, e.ClipRectangle.Height - 43, e.ClipRectangle.Width - 20, e.ClipRectangle.Height - 40);   //MT-Dưới-2
            gfx.DrawLine(p, 40, e.ClipRectangle.Height - 40, e.ClipRectangle.Width - 20, e.ClipRectangle.Height - 40);   //Dưới
            #endregion

            #region Create font and brush.
            Font drawFont = new Font("Arial", 9);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            #endregion

            #region Create point for upper-left corner of drawing.
            PointF drawPointN = new PointF(e.ClipRectangle.Width - 45, e.ClipRectangle.Height - 30);
            PointF drawPointC = new PointF(5, 5);
            PointF drawPointX = new PointF(0, 0);
            PointF drawPointY = new PointF(0, 0);
            PointF drawPointName1 = new PointF(e.ClipRectangle.Width / 2 - 95, e.ClipRectangle.Height - 16);
            PointF drawPointName2 = new PointF(e.ClipRectangle.Width / 2 - 60, e.ClipRectangle.Height - 16);
            PointF drawPointName3 = new PointF(e.ClipRectangle.Width / 2 - 40, e.ClipRectangle.Height - 16);
            #endregion

            gfx.DrawString("Thousand", drawFont, drawBrush, drawPointC);
            //gfx.DrawString("0", drawFont, drawBrush, new PointF(5, e.ClipRectangle.Height - 30));

            #region Week
            if (UC_Account.strRadMode == "Week")
            {
                gfx.DrawString("Days", drawFont, drawBrush, drawPointN);

                gfx.DrawString("Chart of Week " + UC_Account.strfdate + " - " + UC_Account.strldate + " of " + UC_Account.dtCalcValue.Year, drawFont, drawBrush, drawPointName1);

                #region Trục x
                iChieuDai /= 9;
                int iTemp = iChieuDai;
                int iDay = 2;
                for (int i = 40 + iChieuDai; i < iChieuDai * 8; i += iChieuDai)
                {
                    gfx.DrawLine(p, i, e.ClipRectangle.Height - 37, i, e.ClipRectangle.Height - 43);

                    drawPointX = new PointF(i - 5, e.ClipRectangle.Height - 30);
                    gfx.DrawString(iDay.ToString(), drawFont, drawBrush, drawPointX);
                    iDay++;
                }
                #endregion

                #region Trục y
                int iMaxYs = UC_Account.iMaxY / 6000;
                int iMaxYd = iMaxYs;
                for (int j = e.ClipRectangle.Height - 40 - iTemp; j > 40; j -= iTemp)
                {
                    gfx.DrawLine(p, 37, j, 43, j);

                    drawPointY = new PointF(5, j - 7);
                    gfx.DrawString(iMaxYd.ToString(), drawFont, drawBrush, drawPointY);
                    iMaxYd += iMaxYs;
                }
                #endregion

                #region Chart
                int[] ixLDay = new int[7];
                int[] iyLDay = new int[7];
                for (int z = 0; z < 7; z++)
                {
                    int iCao = e.ClipRectangle.Height + 24 - iTemp - (Convert.ToInt32(UC_Account.darrWeekR[z] / 1000) * (iChieuDai * 6) / (iMaxYs * 6));
                    if (z == 0)
                    {
                        ixLDay[z] = 40 + iTemp;
                        iyLDay[z] = iCao;
                    }
                    else
                    {
                        ixLDay[z] = ixLDay[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLDay[z] = iyLDay[z - 1];
                        }
                        else
                        {
                            iyLDay[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 6; c++)
                {
                    gfx.DrawLine(plineR, ixLDay[c], iyLDay[c], ixLDay[c + 1], iyLDay[c + 1]);

                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLDay[c] - 10, iyLDay[c] - 20);
                    gfx.DrawString((UC_Account.darrWeekR[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 6)
                    {
                        drawPointChart = new PointF(ixLDay[c + 1] - 10, iyLDay[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrWeekR[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion

                #region Chart
                ixLDay = new int[7];
                iyLDay = new int[7];
                for (int z = 0; z < 7; z++)
                {
                    int iCao = e.ClipRectangle.Height + 24 - iTemp - (Convert.ToInt32(UC_Account.darrWeekE[z] / 1000) * (iChieuDai * 6) / (iMaxYs * 6));
                    if (z == 0)
                    {
                        ixLDay[z] = 40 + iTemp;
                        iyLDay[z] = iCao;
                    }
                    else
                    {
                        ixLDay[z] = ixLDay[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLDay[z] = iyLDay[z - 1];
                        }
                        else
                        {
                            iyLDay[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 6; c++)
                {
                    gfx.DrawLine(plineE, ixLDay[c], iyLDay[c], ixLDay[c + 1], iyLDay[c + 1]);

                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLDay[c] - 10, iyLDay[c] - 20);
                    gfx.DrawString((UC_Account.darrWeekE[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 6)
                    {
                        drawPointChart = new PointF(ixLDay[c + 1] - 10, iyLDay[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrWeekE[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion
            }
            #endregion

            #region Month
            else if (UC_Account.strRadMode == "Month")
            {
                gfx.DrawString("Weeks", drawFont, drawBrush, drawPointN);
                gfx.DrawString("Chart of " + UC_Account.dtCalcValue.ToString("MMMM") + " - " + UC_Account.dtCalcValue.Year, drawFont, drawBrush, drawPointName2);

                #region Trục x
                iChieuDai /= 5;
                int iTemp = iChieuDai;
                int iWeek = 1;
                for (int i = 40 + iChieuDai; i < iChieuDai * 5; i += iChieuDai)
                {
                    gfx.DrawLine(p, i, e.ClipRectangle.Height - 37, i, e.ClipRectangle.Height - 43);

                    drawPointX = new PointF(i - 5, e.ClipRectangle.Height - 30);
                    gfx.DrawString(iWeek.ToString(), drawFont, drawBrush, drawPointX);
                    iWeek++;
                }
                #endregion

                #region Trục y
                int iMaxYs = UC_Account.iMaxY / 3000;
                int iMaxYd = iMaxYs;
                for (int j = e.ClipRectangle.Height - 40 - iTemp; j > 40; j -= iTemp)
                {
                    gfx.DrawLine(p, 37, j, 43, j);

                    drawPointY = new PointF(5, j - 7);
                    gfx.DrawString(iMaxYd.ToString(), drawFont, drawBrush, drawPointY);
                    iMaxYd += iMaxYs;
                }
                #endregion

                #region Chart
                int[] ixLMonth = new int[4];
                int[] iyLMonth = new int[4];
                for (int z = 0; z < 4; z++)
                {
                    int iCao = e.ClipRectangle.Height + 75 - iTemp - (Convert.ToInt32(UC_Account.darrMonthR[z] / 1000) * (iChieuDai * 3) / (iMaxYs * 3));
                    if (z == 0)
                    {
                        ixLMonth[z] = 40 + iTemp;
                        iyLMonth[z] = iCao;
                    }
                    else
                    {
                        ixLMonth[z] = ixLMonth[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLMonth[z] = iyLMonth[z - 1];
                        }
                        else
                        {
                            iyLMonth[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 3; c++)
                {
                    gfx.DrawLine(plineR, ixLMonth[c], iyLMonth[c], ixLMonth[c + 1], iyLMonth[c + 1]);

                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLMonth[c] - 10, iyLMonth[c] - 20);
                    gfx.DrawString((UC_Account.darrMonthR[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 2)
                    {
                        drawPointChart = new PointF(ixLMonth[c + 1] - 10, iyLMonth[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrMonthR[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion

                #region Chart
                ixLMonth = new int[4];
                iyLMonth = new int[4];
                for (int z = 0; z < 4; z++)
                {
                    int iCao = e.ClipRectangle.Height + 75 - iTemp - (Convert.ToInt32(UC_Account.darrMonthE[z] / 1000) * (iChieuDai * 3) / (iMaxYs * 3));
                    if (z == 0)
                    {
                        ixLMonth[z] = 40 + iTemp;
                        iyLMonth[z] = iCao;
                    }
                    else
                    {
                        ixLMonth[z] = ixLMonth[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLMonth[z] = iyLMonth[z - 1];
                        }
                        else
                        {
                            iyLMonth[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 3; c++)
                {
                    gfx.DrawLine(plineE, ixLMonth[c], iyLMonth[c], ixLMonth[c + 1], iyLMonth[c + 1]);

                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLMonth[c] - 10, iyLMonth[c] - 20);
                    gfx.DrawString((UC_Account.darrMonthE[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 2)
                    {
                        drawPointChart = new PointF(ixLMonth[c + 1] - 10, iyLMonth[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrMonthE[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion
            }
            #endregion

            #region Year
            else if (UC_Account.strRadMode == "Year")
            {
                gfx.DrawString("Months", drawFont, drawBrush, drawPointN);

                gfx.DrawString("Chart of " + UC_Account.dtCalcValue.Year, drawFont, drawBrush, drawPointName3);

                #region Trục x
                iChieuDai /= 15;
                int iTemp = iChieuDai;
                int iMonth = 1;
                for (int i = 40 + iTemp; i < iTemp * 14; i += iTemp)
                {
                    gfx.DrawLine(p, i, e.ClipRectangle.Height - 37, i, e.ClipRectangle.Height - 43);

                    drawPointX = new PointF(i - 5, e.ClipRectangle.Height - 30);
                    gfx.DrawString(iMonth.ToString(), drawFont, drawBrush, drawPointX);
                    iMonth++;
                }
                #endregion

                #region Trục y
                double dMaxYs = UC_Account.iMaxY / 9000;
                double dMaxYd = dMaxYs;
                for (int j = e.ClipRectangle.Height - 40 - iTemp; j > 40; j -= iTemp)
                {
                    gfx.DrawLine(p, 37, j, 43, j);

                    drawPointY = new PointF(5, j - 7);
                    gfx.DrawString(Math.Round(dMaxYd, 2).ToString(), drawFont, drawBrush, drawPointY);
                    dMaxYd += dMaxYs;
                }
                #endregion

                #region Chart
                int[] ixLYear = new int[12];
                int[] iyLYear = new int[12];
                for (int z = 0; z < 12; z++)
                {
                    int iCao = e.ClipRectangle.Height - 2 - iTemp - (Convert.ToInt32(UC_Account.darrYearR[z] / 1000) * (iChieuDai * 10) / ((int)dMaxYs * 10));
                    if (z == 0)
                    {
                        ixLYear[z] = 40 + iTemp;
                        iyLYear[z] = iCao;
                    }
                    else
                    {
                        ixLYear[z] = ixLYear[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLYear[z] = iyLYear[z - 1];
                        }
                        else
                        {
                            iyLYear[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 11; c++)
                {
                    gfx.DrawLine(plineR, ixLYear[c], iyLYear[c], ixLYear[c + 1], iyLYear[c + 1]);
                    
                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLYear[c] - 10, iyLYear[c] - 20);
                    gfx.DrawString((UC_Account.darrYearR[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 10)
                    {
                        drawPointChart = new PointF(ixLYear[c + 1] - 10, iyLYear[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrYearR[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion

                #region Chart
                ixLYear = new int[12];
                iyLYear = new int[12];
                for (int z = 0; z < 12; z++)
                {
                    int iCao = e.ClipRectangle.Height - 2 - iTemp - (Convert.ToInt32(UC_Account.darrYearE[z] / 1000) * (iChieuDai * 10) / ((int)dMaxYs * 10));
                    if (z == 0)
                    {
                        ixLYear[z] = 40 + iTemp;
                        iyLYear[z] = iCao;
                    }
                    else
                    {
                        ixLYear[z] = ixLYear[z - 1] + iTemp;
                        if (iCao == e.ClipRectangle.Height - 40 - iTemp)
                        {
                            iyLYear[z] = iyLYear[z - 1];
                        }
                        else
                        {
                            iyLYear[z] = iCao;
                        }
                    }
                }

                for (int c = 0; c < 11; c++)
                {
                    gfx.DrawLine(plineE, ixLYear[c], iyLYear[c], ixLYear[c + 1], iyLYear[c + 1]);
                    
                    SolidBrush drawBrushChart = new SolidBrush(Color.Brown);
                    PointF drawPointChart = new PointF(ixLYear[c] - 10, iyLYear[c] - 20);
                    gfx.DrawString((UC_Account.darrYearE[c] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);

                    if (c == 10)
                    {
                        drawPointChart = new PointF(ixLYear[c + 1] - 10, iyLYear[c + 1] - 20);
                        gfx.DrawString((UC_Account.darrYearE[c + 1] / 1000).ToString(), drawFont, drawBrushChart, drawPointChart);
                    }
                }
                #endregion
            }
            #endregion
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveImage.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(ChartPanel.Width, ChartPanel.Height);
                ChartPanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(SaveImage.FileName);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Hover
        private void btnSave_MouseMove(object sender, MouseEventArgs e)
        {
            btnSave.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnClose_MouseMove(object sender, MouseEventArgs e)
        {
            btnClose.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion
    }
}
