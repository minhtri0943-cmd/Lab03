using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily ff in FontFamily.Families)
            cmbFont.Items.Add(ff.Name);
            cmbFont.SelectedItem = "Tahoma";

            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbSize.Items.AddRange(sizes.Cast<object>().ToArray());
            cmbSize.SelectedItem = 14;

            richText.Font = new Font("Tahoma", 14);
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;

            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.SelectionFont = fontDlg.Font;
                richText.SelectionColor = fontDlg.Color;
            }
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            richText.Font = new Font("Tahoma", 14);
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = 14;
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text Format (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.EndsWith(".rtf"))
                    richText.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                else
                    richText.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        private string currentFilePath = null;
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Rich Text Format (*.rtf)|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = sfd.FileName;
                    richText.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu thành công!");
                }
            }
            else
            {
                richText.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            if (currentFont != null)
            {
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            if (currentFont != null)
            {
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            Font currentFont = richText.SelectionFont;
            if (currentFont != null)
            {
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
                richText.SelectionFont = new Font(currentFont, newStyle);
            }
        }

        private void richText_TextChanged(object sender, EventArgs e)
        {
            if (richText.SelectionFont != null)
            {
                cmbFont.SelectedItem = richText.SelectionFont.FontFamily.Name;
                cmbSize.SelectedItem = (int)richText.SelectionFont.Size;
            }
        }

        private void cmbFont_Click(object sender, EventArgs e)
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbFont.Items.Add(font.Name);
            }
        }

        private void cmbSize_Click(object sender, EventArgs e)
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbSize.Items.AddRange(sizes.Cast<object>().ToArray());
            cmbSize.SelectedItem = 14;
        }
    }
}
