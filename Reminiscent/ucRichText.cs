using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Gift
{
    public partial class ucRichText : UserControl
    {
        public ucRichText()
        {
            InitializeComponent();
        }

        private Color GetColor(Color initColor)
        {
            using (ColorDialog dlgColor = new ColorDialog())
            {
                dlgColor.Color = initColor;
                dlgColor.AllowFullOpen = true;
                dlgColor.AnyColor = true;
                dlgColor.FullOpen = true;
                dlgColor.ShowHelp = false;
                dlgColor.SolidColorOnly = false;
                if (dlgColor.ShowDialog() == DialogResult.OK)
                {
                    return dlgColor.Color;
                }
                else
                {
                    return initColor;
                }
            }
        }
        private Font GetFont(Font initFont)
        {
            using (FontDialog dlgFont = new FontDialog())
            {
                dlgFont.Font = initFont;
                dlgFont.AllowSimulations = true;
                dlgFont.AllowVectorFonts = true;
                dlgFont.AllowVerticalFonts = true;
                dlgFont.FontMustExist = true;
                dlgFont.ShowHelp = false;
                dlgFont.ShowEffects = true;
                dlgFont.ShowColor = false;
                dlgFont.ShowApply = false;
                dlgFont.FixedPitchOnly = false;

                if (dlgFont.ShowDialog() == DialogResult.OK)
                {
                    return dlgFont.Font;
                }
                else
                {
                    return initFont;
                }
            }
        }
        private string GetImagePath()
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Multiselect = false;
            dlgOpen.ShowReadOnly = false;
            dlgOpen.RestoreDirectory = true;
            dlgOpen.ReadOnlyChecked = false;
            dlgOpen.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                return dlgOpen.FileName;
            }
            else
            {
                return "";
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            rtxShow.Paste();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            rtxShow.Copy();
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            rtxShow.Cut();
        }

        #region CharStyle
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtxShow.SelectionCharStyle.Bold == true)
            {
                btnBold.Checked = false;
                ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                cs.Bold = false;
                rtxShow.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                btnBold.Checked = true;
                ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                cs.Bold = true;
                rtxShow.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtxShow.SelectionCharStyle.Italic == true)
                {
                    btnItalic.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Italic = false;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnItalic.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Italic = true;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (rtxShow.SelectionCharStyle.Underline == true)
                {
                    btnUnderline.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Underline = false;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnUnderline.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = rtxShow.SelectionCharStyle;
                    cs.Underline = true;
                    rtxShow.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Align
        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            btnAlignLeft.Checked = true;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = false;
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = true;
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            rtxShow.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = true;
            btnAlignCenter.Checked = false;
        }
        #endregion

        private void rtxShow_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Aglin
                if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                else if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = true;
                    btnAlignRight.Checked = false;
                }
                else if (rtxShow.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = true;
                }
                else
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                #endregion

                #region Font
                FontFamily ff = new FontFamily("Times New Roman");
                if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                {
                    btnBold.Enabled = true;
                    btnBold.Checked = rtxShow.SelectionCharStyle.Bold;
                }
                else
                {
                    btnBold.Enabled = false;
                    btnBold.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    btnItalic.Enabled = true;
                    btnItalic.Checked = rtxShow.SelectionCharStyle.Italic;
                }
                else
                {
                    btnItalic.Enabled = false;
                    btnItalic.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                {
                    btnUnderline.Enabled = true;
                    btnUnderline.Checked = rtxShow.SelectionCharStyle.Underline;
                }
                else
                {
                    btnUnderline.Enabled = false;
                    btnUnderline.Checked = false;
                }

                ff.Dispose();
                #endregion

                rtxShow.UpdateObjects();
            }
            catch (Exception)
            { }
        }

        private void rtxShow_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void rtxShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (rtxShow.SelectionType == RichTextBoxSelectionTypes.Object ||
                    rtxShow.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(rtxShow.SelectedObject().sizel.Width));
                }
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            try
            {
                string imgPath = GetImagePath(); //Lấy đường dẫn file ảnh

                Bitmap BitmapPic = new Bitmap(imgPath); //Tạo một Bitmap ><

                Clipboard.SetDataObject(BitmapPic); //Đặt đối tượng dử liệu vào Clipboard

                DataFormats.Format FormatPic = DataFormats.GetFormat(DataFormats.Bitmap);//Lấy định dạng của hình

                if (rtxShow.CanPaste(FormatPic)) //Nếu có thể chèn vào RTBox
                {
                    rtxShow.Paste(FormatPic); //Chèn hình vào
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                rtxShow.SelectionColor = GetColor(rtxShow.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnHighLightColor_Click(object sender, EventArgs e)
        {
            try
            {
                rtxShow.SelectionBackColor = GetColor(rtxShow.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void mnuConvert_Click(object sender, EventArgs e)
        {
            //string strChuoi = "";
            //strChuoi = rtxShow.Rtf;
            //rtxShow.Text = strChuoi;
            rtxShow.Text = rtxShow.Rtf;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            rtxShow.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            rtxShow.Redo();
        }
    }
}
