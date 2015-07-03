using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Reminiscent
{
    public partial class Calendar : Form
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        DateTime dtThisTime = DateTime.Now;
        public Calendar()
        {
            InitializeComponent();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, 0);

            lblMonth.Text = dtThisTime.ToString("MMMM yyyy");

            DrawCalendar(dtThisTime);
        }

        private void Calendar_Load(object sender, EventArgs e)
        {

        }

        public void DrawCalendar(DateTime dtToday)
        {
            ClearButton();

            DateTime today = dtToday;
            DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
            int iFirstDay = (int)startOfMonth.DayOfWeek;
            int iLastDay = (int)endOfMonth.Day;

            DateTime premonth = today.AddMonths(-1);
            DateTime endOfPremonth = new DateTime(premonth.Year, premonth.Month, DateTime.DaysInMonth(premonth.Year, premonth.Month));
            int iLastDayPremonth = (int)endOfPremonth.Day;

            DateTime nextmonth = today.AddMonths(+1);
            DateTime startOfNextmonth = new DateTime(nextmonth.Year, nextmonth.Month, 1);
            int iFirstDayNextmonth = (int)startOfNextmonth.DayOfWeek;

            int iTop = 60;
            int iLeft = 3;
            int iSize = 40;
            //Thang truoc
            int MinPreMonth = iLastDayPremonth - iFirstDay;
            if (iFirstDay == 0)
                MinPreMonth = iLastDayPremonth - 7;
            for (int i = iLastDayPremonth; i > MinPreMonth; i--)
            {
                if (i == iLastDayPremonth)
                {
                    if (iFirstDay == 0)
                        iLeft += iSize * 6;
                    else
                        iLeft += iSize * (iFirstDay - 1);
                }
                Button btn = new Button();
                btn.Name = "btn" + i + "-" + premonth.Month;
                btn.Text = i.ToString();
                Point p = new Point(iLeft, iTop);
                btn.Location = p;
                btn.Size = new Size(iSize, iSize);
                btn.ForeColor = Color.WhiteSmoke;
                btn.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Calendar.ca-not.png"));
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.FlatStyle = FlatStyle.Popup;
                //btn.Click += new System.EventHandler(this.xuli);
                this.Controls.Add(btn);
                iLeft -= iSize;
            }

            //Thang nay
            if (iFirstDay == 0)
                iTop += iSize;
            for (int i = 1; i <= iLastDay; i++)
            {
                if (i == 1)
                {
                    iLeft = 3;
                    iLeft += iSize * iFirstDay;
                }
                Button btn = new Button();
                btn.Name = "btn" + i + "-" + today.Month;
                btn.Text = i.ToString();
                Point p = new Point(iLeft, iTop);
                btn.Location = p;
                btn.Size = new Size(iSize, iSize);
                btn.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Calendar.ca-bg3.png"));
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.FlatStyle = FlatStyle.Popup;

                int iDay = Convert.ToInt32(btn.Text);
                int iMonth = Convert.ToInt32(btn.Name.Substring(btn.Name.IndexOf("-") + 1));
                int iYear = dtThisTime.Year;
                String strDate = iDay + "/" + iMonth + "/" + iYear;
                if (strDate == "24/7/2014")
                {
                    btn.Image = null;
                    btn.BackColor = Color.Red;
                }

                btn.Click += new System.EventHandler(this.xuli);
                this.Controls.Add(btn);
                iLeft += iSize;
                if (iLeft == 3 + 7 * iSize)
                {
                    iTop += iSize;
                    iLeft = 3;
                }
            }

            //Thang sau
            for (int i = 1; i < 14; i++)
            {
                if (iTop == (60 + 6 * iSize))
                    break;
                Button btn = new Button();
                btn.Name = "btn" + i + "-" + nextmonth.Month;
                btn.Text = i.ToString();
                Point p = new Point(iLeft, iTop);
                btn.Location = p;
                btn.Size = new Size(iSize, iSize);
                btn.ForeColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Popup;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                btn.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Calendar.ca-not.png"));
                //btn.Click += new System.EventHandler(this.xuli);
                this.Controls.Add(btn);
                iLeft += iSize;
                if (iLeft == 3 + 7 * iSize)
                {
                    iTop += iSize;
                    iLeft = 3;
                }
            }
        }

        public void ClearButton()
        {
            List<Control> Listbtn = new List<Control>();
            foreach (Control ct in this.Controls)
            {
                if (ct.Name.Contains("btn"))
                {
                    Listbtn.Add(ct);
                }
            }
            for (int i = 0; i < Listbtn.Count; i++)
            {
                this.Controls.Remove(Listbtn[i]);
            }
        }

        private void xuli(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int iDay = Convert.ToInt32(btn.Text);
            int iMonth = Convert.ToInt32(btn.Name.Substring(btn.Name.IndexOf("-") + 1));
            int iYear = dtThisTime.Year;
            String strDate = iDay + "/" + iMonth + "/" + iYear;
            if(strDate == "24/7/2014")
                MessageBox.Show("Bảo vệ đồ án tốt nghiệp!");
            else
                MessageBox.Show(strDate);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            dtThisTime = dtThisTime.AddMonths(+1);
            lblMonth.Text = dtThisTime.ToString("MMMM yyyy");
            DrawCalendar(dtThisTime);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            dtThisTime = dtThisTime.AddMonths(-1);
            lblMonth.Text = dtThisTime.ToString("MMMM yyyy");
            DrawCalendar(dtThisTime);
        }
    }
}
