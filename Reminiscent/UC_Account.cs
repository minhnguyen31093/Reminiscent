using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;

namespace Reminiscent
{
    public partial class UC_Account : UserControl
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        int iID = -1;
        int iFlag = 0;
        public static string strRadMode = "";
        
        public static DateTime dtCalcValue;

        public UC_Account()
        {
            InitializeComponent();
        }

        #region Page Load
        private void UC_Account_Load(object sender, EventArgs e)
        {
            txtID.ReadOnly = true;
            cboType.Enabled = false;
            txtAmount.ReadOnly = true;
            dtRE.Enabled = false;
            txtReason.ReadOnly = true;
            txtSummaryR.ReadOnly = true;
            txtSummaryE.ReadOnly = true;
            txtSummaryT.ReadOnly = true;

            LoadList();

            cboType.Items.Add("Receipts");
            cboType.Items.Add("Expense");

            dtRE.Format = DateTimePickerFormat.Custom;
            dtRE.CustomFormat = "dd/MM/yyyy";
            dtRE.Value = DateTime.Now;
            dtCalc.Format = DateTimePickerFormat.Custom;
            dtCalc.CustomFormat = "dd/MM/yyyy";

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            dgvRE.Columns[3].DefaultCellStyle.Format  = "dd/MM/yyyy";

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
                    label1.Text = frmMain.Decryption(node.SelectSingleNode("Text").InnerText);

                    radDay.Text = frmMain.Decryption(node.SelectSingleNode("rad3").InnerText);
                    radWeek.Text = frmMain.Decryption(node.SelectSingleNode("rad4").InnerText);
                    radMonth.Text = frmMain.Decryption(node.SelectSingleNode("rad5").InnerText);
                    radYear.Text = frmMain.Decryption(node.SelectSingleNode("rad6").InnerText);

                    lblID.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblType.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblAmount.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    lblDate.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    lblReason.Text = frmMain.Decryption(node.SelectSingleNode("lbl5").InnerText);
                    lblReceipts.Text = frmMain.Decryption(node.SelectSingleNode("lbl6").InnerText);
                    lblExpense.Text = frmMain.Decryption(node.SelectSingleNode("lbl7").InnerText);
                    lblTotal.Text = frmMain.Decryption(node.SelectSingleNode("lbl8").InnerText);

                    dgvRE.Columns[0].HeaderText = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    dgvRE.Columns[1].HeaderText = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    dgvRE.Columns[2].HeaderText = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    dgvRE.Columns[3].HeaderText = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    dgvRE.Columns[4].HeaderText = frmMain.Decryption(node.SelectSingleNode("lbl5").InnerText);

                    btnNewRE.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnEditRE.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnDelRE.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnSaveRE.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    btnCalcRE.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);
                    btnDrawChart.Text = frmMain.Decryption(node.SelectSingleNode("btn6").InnerText);

                    lblSummary.Text = frmMain.Decryption(node.SelectSingleNode("gb1").InnerText);
                    break;
                }
            }
            #endregion
        }
        #endregion

        #region Load Data Grid View
        void LoadList()
        {
            dgvRE.Rows.Clear();

            if (File.Exists(Application.StartupPath + "/Data/Account.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Account.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Account = root.GetElementsByTagName("Payment");

                for (int i = 0; i < Account.Count; i++)
                {
                    try
                    {
                        DataGridViewRow row = (DataGridViewRow)dgvRE.Rows[0].Clone();
                        row.Cells[0].Value = Convert.ToInt32(frmMain.Decryption(Account[i].ChildNodes[0].InnerText));
                        row.Cells[1].Value = frmMain.Decryption(Account[i].ChildNodes[1].InnerText);
                        row.Cells[2].Value = Convert.ToInt32(frmMain.Decryption(Account[i].ChildNodes[2].InnerText));
                        //row.Cells[3].Value = Account[i].ChildNodes[3].InnerText;
                        row.Cells[4].Value = frmMain.Decryption(Account[i].ChildNodes[4].InnerText);
                        row.Cells[3].Value = DateTime.ParseExact(frmMain.Decryption(Account[i].ChildNodes[3].InnerText), "d/M/yyyy", CultureInfo.InvariantCulture);
                        dgvRE.Rows.Add(row);
                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "/Data/Account.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/Account.xml", Application.StartupPath + "/Data/Account.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/Account.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Account.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Account");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Account database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }
        #endregion

        internal void PgUp()
        {
            if (dgvRE.Rows.Count > 0)
            {
                if (frmMain.iPage < 34)
                {
                    dgvRE.Focus();
                    dgvRE.Rows[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    dgvRE.Focus();
                    dgvRE.Rows[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void PgDn()
        {
            if (dgvRE.Rows.Count > 0)
            {
                if (frmMain.iPage > dgvRE.Rows.Count - 2)
                {
                    dgvRE.Focus();
                    dgvRE.Rows[dgvRE.Rows.Count - 2].Selected = true;
                    frmMain.iPage = dgvRE.Rows.Count - 2;
                }
                else
                {
                    dgvRE.Focus();
                    dgvRE.Rows[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void Search(string strSearch, string strBy)
        {
            if (dgvRE.Rows.Count > 0)
            {
                if (frmMain.iSearch == dgvRE.Rows.Count - 1)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < dgvRE.Rows.Count - 1; i++)
                {
                    if (strBy == "Type")
                    {
                        if (dgvRE.Rows[i].Cells[1].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvRE.Focus();
                            dgvRE.Rows[i].Selected = true;
                            if (i == dgvRE.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvRE.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Amount")
                    {
                        if (dgvRE.Rows[i].Cells[2].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvRE.Focus();
                            dgvRE.Rows[i].Selected = true;
                            if (i == dgvRE.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvRE.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Date")
                    {
                        if (dgvRE.Rows[i].Cells[3].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvRE.Focus();
                            dgvRE.Rows[i].Selected = true;
                            if (i == dgvRE.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvRE.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Reason")
                    {
                        if (dgvRE.Rows[i].Cells[4].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvRE.Focus();
                            dgvRE.Rows[i].Selected = true;
                            if (i == dgvRE.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvRE.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }

        #region rad checked changed

        #region rad click
        int iclick1 = 0;
        int iclick2 = 0;
        int iclick3 = 0;
        int iclick4 = 0;
        private void radDay_Click(object sender, EventArgs e)
        {
            if (iclick1 == 1)
            {
                if (radDay.Checked == true)
                {
                    radDay.Checked = false;
                    iclick1 = 2;
                }
                else
                {
                    radDay.Checked = true;
                }
            }
            else
            {
                radDay.Checked = true;
                iclick1 = 1;
            }
        }

        private void radWeek_Click(object sender, EventArgs e)
        {
            if (iclick2 == 1)
            {
                if (radWeek.Checked == true)
                {
                    radWeek.Checked = false;
                    iclick2 = 2;
                }
                else
                {
                    radWeek.Checked = true;
                }
            }
            else
            {
                radWeek.Checked = true;
                iclick2 = 1;
            }
        }

        private void radMonth_Click(object sender, EventArgs e)
        {
            if (iclick3 == 1)
            {
                if (radMonth.Checked == true)
                {
                    radMonth.Checked = false;
                    iclick3 = 2;
                }
                else
                {
                    radMonth.Checked = true;
                }
            }
            else
            {
                radMonth.Checked = true;
                iclick3 = 1;
            }
        }

        private void radYear_Click(object sender, EventArgs e)
        {
            if (iclick4 == 1)
            {
                if (radYear.Checked == true)
                {
                    radYear.Checked = false;
                    iclick4 = 2;
                }
                else
                {
                    radYear.Checked = true;
                }
            }
            else
            {
                radYear.Checked = true;
                iclick4 = 1;
            }
        }
        #endregion

        private void radDay_CheckedChanged(object sender, EventArgs e)
        {
            if (radDay.Checked)
            {
                iclick2 = 0;
                iclick3 = 0;
                iclick4 = 0;
                strRadMode = "Day";
                dtCalc.CustomFormat = "dd/MM/yyyy";
                RadModeChange();
            }
            else
            {
                LoadList();
                strRadMode = "";
            }
        }

        private void radWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radWeek.Checked)
            {
                iclick1 = 0;
                iclick3 = 0;
                iclick4 = 0;
                strRadMode = "Week";
                dtCalc.CustomFormat = "dd/MM/yyyy";
                RadModeChange();
            }
            else
            {
                LoadList();
                strRadMode = "";
            }
        }

        private void radMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radMonth.Checked)
            {
                iclick1 = 0;
                iclick2 = 0;
                iclick4 = 0;
                strRadMode = "Month";
                dtCalc.CustomFormat = "MM/yyyy";
                RadModeChange();
            }
            else
            {
                LoadList();
                strRadMode = "";
            }
        }

        private void radYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radYear.Checked)
            {
                iclick1 = 0;
                iclick2 = 0;
                iclick3 = 0;
                strRadMode = "Year";
                dtCalc.CustomFormat = "yyyy";
                RadModeChange();
            }
            else
            {
                LoadList();
                strRadMode = "";
            }
        }

        void RadModeChange()
        {
            LoadList();
            if (strRadMode == "Day")
            {
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    DateTime dtDayC = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                    string strDayC = dtDayC.Day.ToString() + "/" + dtDayC.Month.ToString() + "/" + dtDayC.Year.ToString();

                    string strDTCalcDay = dtCalc.Value.Day.ToString() + "/" + dtCalc.Value.Month.ToString() + "/" + dtCalc.Value.Year.ToString();

                    if (strDayC != strDTCalcDay)
                    {
                        dgvRE.Rows.Remove(dgvRE.Rows[i]);
                        i--;
                    }
                }
            }
            else if (strRadMode == "Week")
            {
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    DateTime dtWeekC = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());

                    DayOfWeek firstdayofweek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                    List<DateTime> lstDays = new List<DateTime>();
                    int days = dtWeekC.DayOfWeek - firstdayofweek - 1;
                    DateTime dtSDay = dtWeekC.AddDays(-days);
                    lstDays.Add(dtSDay);
                    lstDays.AddRange(new DateTime[] { dtSDay.AddDays(1), dtSDay.AddDays(2), dtSDay.AddDays(3), dtSDay.AddDays(4), dtSDay.AddDays(5), dtSDay.AddDays(6) });

                    string strDTCalcDay = dtCalc.Value.Day.ToString() + "/" + dtCalc.Value.Month.ToString() + "/" + dtCalc.Value.Year.ToString();

                    if (lstDays[0].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[1].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[2].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[3].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[4].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[5].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay &&
                        lstDays[6].Day + "/" + dtWeekC.Month + "/" + dtWeekC.Year != strDTCalcDay)
                    {
                        dgvRE.Rows.Remove(dgvRE.Rows[i]);
                        i--;
                    }
                }
            }
            else if (strRadMode == "Month")
            {
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    DateTime dtMonthC = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                    string strMonthC = dtMonthC.Month.ToString() + "/" + dtMonthC.Year.ToString();

                    string strDTCalcMonth = dtCalc.Value.Month.ToString() + "/" + dtCalc.Value.Year.ToString();

                    if (strMonthC != strDTCalcMonth)
                    {
                        dgvRE.Rows.Remove(dgvRE.Rows[i]);
                        i--;
                    }
                }
            }
            else if (strRadMode == "Year")
            {
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    DateTime dtYearC = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                    string strYearC = dtYearC.Year.ToString();

                    string strDTCalcYear = dtCalc.Value.Year.ToString();

                    if (strYearC != strDTCalcYear)
                    {
                        dgvRE.Rows.Remove(dgvRE.Rows[i]);
                        i--;
                    }
                }
            }
        }
        #endregion

        #region Button
        private void btnNewRE_Click(object sender, EventArgs e)
        {
            cboType.Enabled = true;
            txtAmount.ReadOnly = false;
            dtRE.Enabled = true;
            txtReason.ReadOnly = false;

            int iMax = 0;
            if (dgvRE.Rows.Count - 1 > 0)
            {
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    if (iMax < Convert.ToInt32(dgvRE.Rows[i].Cells[0].Value))
                        iMax = Convert.ToInt32(dgvRE.Rows[i].Cells[0].Value);
                }
            }
            iMax++;
            iID = iMax;
            txtID.Text = iMax.ToString();
            cboType.SelectedIndex = 0;
            txtAmount.Text = "";
            dtRE.Value = DateTime.Now;
            txtReason.Text = "";

            iFlag = 1;
        }

        private void btnEditRE_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() != "" && txtReason.Text.Trim() != "")
            {
                #region File exists
                if (!File.Exists(Application.StartupPath + "/Data/Account.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Account.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Account");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                #endregion

                #region New
                if (iFlag == 2)
                {
                    int iMax = 0;
                    if (dgvRE.Rows.Count - 1 > 0)
                    {
                        for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                        {
                            if (iMax < Convert.ToInt32(dgvRE.Rows[i].Cells[0].Value))
                                iMax = Convert.ToInt32(dgvRE.Rows[i].Cells[0].Value);
                        }
                    }
                    iMax++;
                    iID = iMax;

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Account.xml");

                    XmlNode nodePayment = xmlDoc.CreateNode(XmlNodeType.Element, "Payment", null);

                    XmlNode nodeID = xmlDoc.CreateElement("ID");
                    nodeID.InnerText = frmMain.Encryption(iID.ToString());

                    XmlNode nodeType = xmlDoc.CreateElement("Type");
                    if (cboType.SelectedIndex == 0)
                        nodeType.InnerText = frmMain.Encryption("Receipts");
                    else if (cboType.SelectedIndex == 1)
                        nodeType.InnerText = frmMain.Encryption("Expense");

                    XmlNode nodeAmount = xmlDoc.CreateElement("Amount");
                    nodeAmount.InnerText = frmMain.Encryption(txtAmount.Text);

                    XmlNode nodeDate = xmlDoc.CreateElement("Date");
                    nodeDate.InnerText = frmMain.Encryption(dtRE.Text);

                    XmlNode nodeReason = xmlDoc.CreateElement("Reason");
                    nodeReason.InnerText = frmMain.Encryption(txtReason.Text);

                    nodePayment.AppendChild(nodeID);
                    nodePayment.AppendChild(nodeType);
                    nodePayment.AppendChild(nodeAmount);
                    nodePayment.AppendChild(nodeDate);
                    nodePayment.AppendChild(nodeReason);

                    xmlDoc.DocumentElement.AppendChild(nodePayment);
                    xmlDoc.Save(Application.StartupPath + "/Data/Account.xml");
                }
                #endregion

                Sort();

                LoadList();

                iFlag = 0;
                cboType.Enabled = false;
                txtAmount.ReadOnly = true;
                dtRE.Enabled = false;
                txtReason.ReadOnly = true;
            }
            else
                MessageBox.Show("Amount or reason empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDelRE_Click(object sender, EventArgs e)
        {
            if (iFlag == 2)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/Account.xml"))
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(Application.StartupPath + "/Data/Account.xml");

                        foreach (XmlNode node in xmlDoc.SelectNodes("Account/Payment"))
                        {
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }
                        }
                        xmlDoc.Save(Application.StartupPath + "/Data/Account.xml");

                        txtID.Text = "";
                        cboType.SelectedIndex = -1;
                        txtAmount.Text = "";
                        dtRE.Value = DateTime.Now;
                        txtReason.Text = "";
                        iFlag = 0;

                        LoadList();
                        cboType.Enabled = false;
                        txtAmount.ReadOnly = true;
                        dtRE.Enabled = false;
                        txtReason.ReadOnly = true;
                    }
                }
            }
        }

        private void btnSaveRE_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text.Trim() != "" && txtReason.Text.Trim() != "")
            {
                #region File exists
                if (!File.Exists(Application.StartupPath + "/Data/Account.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Account.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Account");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                #endregion

                #region New
                if (iFlag == 1)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Account.xml");

                    XmlNode nodePayment = xmlDoc.CreateNode(XmlNodeType.Element, "Payment", null);

                    XmlNode nodeID = xmlDoc.CreateElement("ID");
                    nodeID.InnerText = frmMain.Encryption(iID.ToString());

                    XmlNode nodeType = xmlDoc.CreateElement("Type");
                    if (cboType.SelectedIndex == 0)
                        nodeType.InnerText = frmMain.Encryption("Receipts");
                    else if (cboType.SelectedIndex == 1)
                        nodeType.InnerText = frmMain.Encryption("Expense");

                    XmlNode nodeAmount = xmlDoc.CreateElement("Amount");
                    nodeAmount.InnerText = frmMain.Encryption(txtAmount.Text);

                    XmlNode nodeDate = xmlDoc.CreateElement("Date");
                    nodeDate.InnerText = frmMain.Encryption(dtRE.Text);

                    XmlNode nodeReason = xmlDoc.CreateElement("Reason");
                    nodeReason.InnerText = frmMain.Encryption(txtReason.Text);

                    nodePayment.AppendChild(nodeID);
                    nodePayment.AppendChild(nodeType);
                    nodePayment.AppendChild(nodeAmount);
                    nodePayment.AppendChild(nodeDate);
                    nodePayment.AppendChild(nodeReason);

                    xmlDoc.DocumentElement.AppendChild(nodePayment);
                    xmlDoc.Save(Application.StartupPath + "/Data/Account.xml");
                }
                #endregion

                #region Edit
                if (iFlag == 2)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Account.xml");

                    foreach (XmlNode node in xmlDoc.SelectNodes("Account/Payment"))
                    {
                        if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                        {
                            if (cboType.SelectedIndex == 0)
                                node.SelectSingleNode("Type").InnerText = frmMain.Encryption("Receipts");
                            else if (cboType.SelectedIndex == 1)
                                node.SelectSingleNode("Type").InnerText = frmMain.Encryption("Expense");
                            node.SelectSingleNode("Amount").InnerText = frmMain.Encryption(txtAmount.Text);
                            node.SelectSingleNode("Date").InnerText = frmMain.Encryption(dtRE.Text);
                            node.SelectSingleNode("Reason").InnerText = frmMain.Encryption(txtReason.Text);
                        }
                    }
                    xmlDoc.Save(Application.StartupPath + "/Data/Account.xml");
                }
                #endregion

                Sort();

                LoadList();

                iFlag = 0;
                cboType.Enabled = false;
                txtAmount.ReadOnly = true;
                dtRE.Enabled = false;
                txtReason.ReadOnly = true;
            }
            else
                MessageBox.Show("Amount or reason empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #region Sort
        void Sort()
        {
            XElement root = XElement.Load(Application.StartupPath + "/Data/Account.xml");
            var orderedtabs = root.Elements("Payment")
                                  .OrderBy(xtab => DateTime.ParseExact(frmMain.Decryption(xtab.Element("Date").Value.ToString()), "d/M/yyyy", CultureInfo.InvariantCulture))
                                  .ThenBy(xtab => Convert.ToInt32(frmMain.Decryption(xtab.Element("ID").Value.ToString())))
                //.ThenBy(xtab => DateTime.ParseExact(xtab.Element("Time").Value, "h:mm", CultureInfo.InvariantCulture))
                                  .ToArray();
            root.RemoveAll();
            foreach (XElement tab in orderedtabs)
                root.Add(tab);
            root.Save(Application.StartupPath + "/Data/Account.xml");
        }
        #endregion

        public static string strfdate = "";
        public static string strldate = "";

        public static double[] darrWeekR;
        public static double[] darrMonthR;
        public static double[] darrYearR;
        public static double[] darrWeekE;
        public static double[] darrMonthE;
        public static double[] darrYearE;
        public static int iMaxY = 0;

        private void btnCalcRE_Click(object sender, EventArgs e)
        {
            #region old
            //if (dgvRE.Rows.Count - 1 > 0)
            //{
            //    darrWeek = new double[7];
            //    darrMonth = new double[4];
            //    darrYear = new double[12];
            //    double dTong = 0;
            //    int iMonthsChart = 0;
            //    iMaxY = 0;
            //    for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
            //    {
            //        #region Day
            //        if (radDay.Checked)
            //        {
            //            if (dtCalc.Text == dgvRE.Rows[i].Cells[3].Value.ToString())
            //                dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //        }
            //        #endregion

            //        #region Week
            //        if (radWeek.Checked)
            //        {
            //            DayOfWeek firstdayofweek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            //            List<DateTime> lstDays = new List<DateTime>();
            //            int days = dtCalc.Value.DayOfWeek - firstdayofweek - 1;
            //            DateTime dtSDay = dtCalc.Value.AddDays(-days);
            //            lstDays.Add(dtSDay);
            //            lstDays.AddRange(new DateTime[] { dtSDay.AddDays(1), dtSDay.AddDays(2), dtSDay.AddDays(3), dtSDay.AddDays(4), dtSDay.AddDays(5), dtSDay.AddDays(6) });

            //            strfdate = lstDays[0].Day.ToString() + "/" + lstDays[0].Month.ToString();
            //            strldate = lstDays[6].Day.ToString() + "/" + lstDays[6].Month.ToString();

            //            string strMonth = dtCalc.Text.Substring(dtCalc.Text.IndexOf('/'));

            //            if (lstDays[0].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[1].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[2].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[3].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[4].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[5].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString() ||
            //                lstDays[6].Day + strMonth == dgvRE.Rows[i].Cells[3].Value.ToString())
            //            {
            //                dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                DateTime dateValue = DateTime.ParseExact(dgvRE.Rows[i].Cells[3].Value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
            //                int iDoW = -1;
            //                if (dateValue.DayOfWeek.ToString() == "Monday")
            //                    iDoW = 0;
            //                else if (dateValue.DayOfWeek.ToString() == "Tuesday")
            //                    iDoW = 1;
            //                else if (dateValue.DayOfWeek.ToString() == "Wednesday")
            //                    iDoW = 2;
            //                else if (dateValue.DayOfWeek.ToString() == "Thursday")
            //                    iDoW = 3;
            //                else if (dateValue.DayOfWeek.ToString() == "Friday")
            //                    iDoW = 4;
            //                else if (dateValue.DayOfWeek.ToString() == "Saturday")
            //                    iDoW = 5;
            //                else if (dateValue.DayOfWeek.ToString() == "Sunday")
            //                    iDoW = 6;
            //                darrWeek[iDoW] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);

            //                if (iMaxY < darrWeek[iDoW])
            //                    iMaxY = Convert.ToInt32(darrWeek[iDoW]);
            //            }
            //        }
            //        #endregion

            //        #region Month
            //        if (radMonth.Checked)
            //        {
            //            if (dtCalc.Text == dgvRE.Rows[i].Cells[3].Value.ToString().Substring(dgvRE.Rows[i].Cells[3].Value.ToString().IndexOf('/') + 1))
            //            {
            //                dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                DateTime dateValue = DateTime.ParseExact(dgvRE.Rows[i].Cells[3].Value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
            //                int iDoM = dateValue.Day;
            //                if (iDoM < 8)
            //                {
            //                    darrMonth[0] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }
            //                else if (iDoM > 7 && iDoM < 15)
            //                {
            //                    darrMonth[1] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }
            //                else if (iDoM > 14 && iDoM < 22)
            //                {
            //                    darrMonth[2] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }
            //                else if (iDoM > 21)
            //                {
            //                    darrMonth[3] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }

            //                if (iMaxY < darrMonth[0])
            //                    iMaxY = Convert.ToInt32(darrMonth[0]);
            //                else if (iMaxY < darrMonth[1])
            //                    iMaxY = Convert.ToInt32(darrMonth[1]);
            //                else if (iMaxY < darrMonth[2])
            //                    iMaxY = Convert.ToInt32(darrMonth[2]);
            //                else if (iMaxY < darrMonth[3])
            //                    iMaxY = Convert.ToInt32(darrMonth[3]);
            //            }
            //        }
            //        #endregion

            //        #region Year
            //        if (radYear.Checked)
            //        {
            //            if (dtCalc.Text == dgvRE.Rows[i].Cells[3].Value.ToString().Substring(dgvRE.Rows[i].Cells[3].Value.ToString().LastIndexOf('/') + 1))
            //            {
            //                dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                DateTime dateValue = DateTime.ParseExact(dgvRE.Rows[i].Cells[3].Value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
            //                int iMoY = dateValue.Month - 1;
            //                if (iMonthsChart != iMoY)
            //                {
            //                    iMonthsChart = iMoY;
            //                    darrYear[iMonthsChart] = Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }
            //                else
            //                {
            //                    darrYear[iMonthsChart] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            //                }

            //                if (iMaxY < darrYear[iMonthsChart])
            //                    iMaxY = Convert.ToInt32(darrYear[iMonthsChart]);
            //            }
            //        }
            //        #endregion
            //    }
            //}
            #endregion

            #region new
            if (dgvRE.Rows.Count - 1 > 0)
            {
                darrWeekR = new double[7];
                darrMonthR = new double[4];
                darrYearR = new double[12];
                darrWeekE = new double[7];
                darrMonthE = new double[4];
                darrYearE = new double[12];
                double dTong = 0;
                int iMonthsChart = 0;
                iMaxY = 0;
                for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
                {
                    #region Week
                    if (radWeek.Checked)
                    {
                        DayOfWeek firstdayofweek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                        List<DateTime> lstDays = new List<DateTime>();
                        int days = dtCalc.Value.DayOfWeek - firstdayofweek - 1;
                        DateTime dtSDay = dtCalc.Value.AddDays(-days);
                        lstDays.Add(dtSDay);
                        lstDays.AddRange(new DateTime[] { dtSDay.AddDays(1), dtSDay.AddDays(2), dtSDay.AddDays(3), dtSDay.AddDays(4), dtSDay.AddDays(5), dtSDay.AddDays(6) });

                        strfdate = lstDays[0].Day.ToString() + "/" + lstDays[0].Month.ToString();
                        strldate = lstDays[6].Day.ToString() + "/" + lstDays[6].Month.ToString();

                        if (dtCalc.Value.Year == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Year)
                        if (dtCalc.Value.Month == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Month)
                        if (lstDays[0].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[1].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[2].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[3].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[4].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[5].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day ||
                        lstDays[6].Day == DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString()).Day)
                        {
                            dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                            DateTime dateValue = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                            int iDoW = -1;
                            if (dateValue.DayOfWeek.ToString() == "Monday")
                                iDoW = 0;
                            else if (dateValue.DayOfWeek.ToString() == "Tuesday")
                                iDoW = 1;
                            else if (dateValue.DayOfWeek.ToString() == "Wednesday")
                                iDoW = 2;
                            else if (dateValue.DayOfWeek.ToString() == "Thursday")
                                iDoW = 3;
                            else if (dateValue.DayOfWeek.ToString() == "Friday")
                                iDoW = 4;
                            else if (dateValue.DayOfWeek.ToString() == "Saturday")
                                iDoW = 5;
                            else if (dateValue.DayOfWeek.ToString() == "Sunday")
                                iDoW = 6;

                            if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Receipts")
                            {
                                darrWeekR[iDoW] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);

                                if (iMaxY < darrWeekR[iDoW])
                                    iMaxY = Convert.ToInt32(darrWeekR[iDoW]);
                            }

                            else if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Expense")
                            {
                                darrWeekE[iDoW] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);

                                if (iMaxY < darrWeekE[iDoW])
                                    iMaxY = Convert.ToInt32(darrWeekE[iDoW]);
                            }
                        }
                    }
                    #endregion

                    #region Month
                    if (radMonth.Checked)
                    {
                        DateTime dateValue = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                        if (dtCalc.Value.Month == dateValue.Month && dtCalc.Value.Year == dateValue.Year)
                        {
                            dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                            
                            int iDoM = dateValue.Day;
                            if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Receipts")
                            {
                                if (iDoM < 8)
                                {
                                    darrMonthR[0] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 7 && iDoM < 15)
                                {
                                    darrMonthR[1] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 14 && iDoM < 22)
                                {
                                    darrMonthR[2] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 21)
                                {
                                    darrMonthR[3] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }

                                if (iMaxY < darrMonthR[0])
                                    iMaxY = Convert.ToInt32(darrMonthR[0]);
                                else if (iMaxY < darrMonthR[1])
                                    iMaxY = Convert.ToInt32(darrMonthR[1]);
                                else if (iMaxY < darrMonthR[2])
                                    iMaxY = Convert.ToInt32(darrMonthR[2]);
                                else if (iMaxY < darrMonthR[3])
                                    iMaxY = Convert.ToInt32(darrMonthR[3]);
                            }

                            else if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Expense")
                            {
                                if (iDoM < 8)
                                {
                                    darrMonthE[0] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 7 && iDoM < 15)
                                {
                                    darrMonthE[1] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 14 && iDoM < 22)
                                {
                                    darrMonthE[2] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else if (iDoM > 21)
                                {
                                    darrMonthE[3] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }

                                if (iMaxY < darrMonthE[0])
                                    iMaxY = Convert.ToInt32(darrMonthE[0]);
                                else if (iMaxY < darrMonthE[1])
                                    iMaxY = Convert.ToInt32(darrMonthE[1]);
                                else if (iMaxY < darrMonthE[2])
                                    iMaxY = Convert.ToInt32(darrMonthE[2]);
                                else if (iMaxY < darrMonthE[3])
                                    iMaxY = Convert.ToInt32(darrMonthE[3]);
                            }
                        }
                    }
                    #endregion

                    #region Year
                    if (radYear.Checked)
                    {
                        DateTime dateValue = DateTime.Parse(dgvRE.Rows[i].Cells[3].Value.ToString());
                        if (dtCalc.Value.Year == dateValue.Year)
                        {
                            dTong += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);

                            int iMoY = dateValue.Month - 1;
                            if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Receipts")
                            {
                                if (iMonthsChart != iMoY)
                                {
                                    iMonthsChart = iMoY;
                                    darrYearR[iMonthsChart] = Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else
                                    darrYearR[iMonthsChart] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                if (iMaxY < darrYearR[iMonthsChart])
                                    iMaxY = Convert.ToInt32(darrYearR[iMonthsChart]);
                            }

                            else if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Expense")
                            {
                                if (iMonthsChart != iMoY)
                                {
                                    iMonthsChart = iMoY;
                                    darrYearE[iMonthsChart] = Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                }
                                else
                                    darrYearE[iMonthsChart] += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                                if (iMaxY < darrYearE[iMonthsChart])
                                    iMaxY = Convert.ToInt32(darrYearE[iMonthsChart]);
                            }
                        }
                    }
                    #endregion
                }
            }
            #endregion

            int iR = 0;
            int iE = 0;
            int iT = 0;

            for (int i = 0; i < dgvRE.Rows.Count - 1; i++)
            {
                if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Receipts")
                    iR += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
                else if (dgvRE.Rows[i].Cells[1].Value.ToString() == "Expense")
                    iE += Convert.ToInt32(dgvRE.Rows[i].Cells[2].Value);
            }
            iT = iR - iE;

            txtSummaryR.Text = iR.ToString();
            txtSummaryE.Text = iE.ToString();
            txtSummaryT.Text = iT.ToString();
        }
        #endregion

        #region Hover
        private void btnNewRE_MouseMove(object sender, MouseEventArgs e)
        {
            btnNewRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnEditRE_MouseMove(object sender, MouseEventArgs e)
        {
            btnEditRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDelRE_MouseMove(object sender, MouseEventArgs e)
        {
            btnDelRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnSaveRE_MouseMove(object sender, MouseEventArgs e)
        {
            btnSaveRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCalcRE_MouseMove(object sender, MouseEventArgs e)
        {
            btnCalcRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDrawChart_MouseMove(object sender, MouseEventArgs e)
        {
            btnDrawChart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnNewRE_MouseLeave(object sender, EventArgs e)
        {
            btnNewRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnEditRE_MouseLeave(object sender, EventArgs e)
        {
            btnEditRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnDelRE_MouseLeave(object sender, EventArgs e)
        {
            btnDelRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnSaveRE_MouseLeave(object sender, EventArgs e)
        {
            btnSaveRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCalcRE_MouseLeave(object sender, EventArgs e)
        {
            btnCalcRE.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnDrawChart_MouseLeave(object sender, EventArgs e)
        {
            btnDrawChart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion

        private void btnDrawChart_Click(object sender, EventArgs e)
        {
            dtCalcValue = dtCalc.Value;
            AccountChart ac = new AccountChart();
            ac.ShowDialog();
        }

        private void txtSummary_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void dgvRE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cboType.Enabled = true;
            txtAmount.ReadOnly = false;
            dtRE.Enabled = true;
            txtReason.ReadOnly = false;

            int iRIndex = dgvRE.CurrentCell.RowIndex;
            if (dgvRE.Rows[iRIndex].Cells[0].Value != null)
            {
                iFlag = 2;
                frmMain.iPage = iRIndex;
                iID = Convert.ToInt32(dgvRE.Rows[iRIndex].Cells[0].Value);
                txtID.Text = dgvRE.Rows[iRIndex].Cells[0].Value.ToString();
                cboType.Text = dgvRE.Rows[iRIndex].Cells[1].Value.ToString();
                txtAmount.Text = dgvRE.Rows[iRIndex].Cells[2].Value.ToString();
                //dtRE.Text = DateTime.ParseExact(dgvRE.Rows[iRIndex].Cells[3].Value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture).ToString();
                dtRE.Text = dgvRE.Rows[iRIndex].Cells[3].Value.ToString();
                txtReason.Text = dgvRE.Rows[iRIndex].Cells[4].Value.ToString();

                //if (dgvRE.Rows[iRIndex].Cells[8].Value.ToString() == "Receipts")
                //    cboType.SelectedIndex = 0;
                //else
                //    cboType.SelectedIndex = 1;
            }
            else
            {
                dgvRE.ClearSelection();
            }
        }

        private void dgvRE_Paint(object sender, PaintEventArgs e)
        {
            int rowHeight = this.dgvRE.RowTemplate.Height;

            int h = this.dgvRE.ColumnHeadersHeight + rowHeight * (this.dgvRE.NewRowIndex + 1);
            Bitmap rowImg = new Bitmap(this.dgvRE.Width, rowHeight);
            Graphics g = Graphics.FromImage(rowImg);
            Rectangle rFrame = new Rectangle(1, 0, this.dgvRE.Width, rowHeight);
            g.DrawRectangle(new Pen(Color.FromArgb(240, 240, 240)), rFrame);
            Rectangle rFill = new Rectangle(1, 1, this.dgvRE.Width - 2, rowHeight - 2);
            g.FillRectangle(Brushes.White, rFill);

            int w = 1;
            for (int j = 0; j < this.dgvRE.ColumnCount; j++)
            {
                w += this.dgvRE.Columns[j].Width;
                g.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), new Point(w, 0), new Point(w, rowHeight));
            }

            int loop = (this.dgvRE.Height - h) / rowHeight;
            for (int j = 0; j < loop + 1; j++)
            {
                e.Graphics.DrawImage(rowImg, 0, h + j * rowHeight);
            }
        }

        private void dtCalc_ValueChanged(object sender, EventArgs e)
        {
            RadModeChange();
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }
    }
}
