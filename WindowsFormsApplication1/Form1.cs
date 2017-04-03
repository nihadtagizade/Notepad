using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SaveFileDialog sfd = new SaveFileDialog();
        OpenFileDialog ofd = new OpenFileDialog();
         public string contents = string.Empty;
        string currentFileLoc;
        static int firsttime = 0;
        int current = 0;
        static string destination = "";
        string openName = "";

        public Form1()
        {
            InitializeComponent();

        }


        public void changeName(string path)
        {
            char[] fileName;
            fileName = path.ToCharArray();
            path = "";
            for (int i = fileName.Length - 1; i >= 0; i--)
            {
                if (fileName[i] == '\\')
                {
                    for (int j = i + 1; j < fileName.Length; j++)
                    {
                        path += fileName[j];
                    }
                    break;
                }
            }
            this.Text = path;
        }

        public void wantToSave()
        {
            DialogResult saveVar;
            saveVar = MessageBox.Show("Do you want to save your changes to " + destination, " Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == saveVar)
            {
                save();
                richTxt.Text = "";
                this.Text = "My Note";
                current = 0;
            }
            if (DialogResult.No == saveVar)
            {
                richTxt.Text = "";
                this.Text = "My Note";
                current = 0;
            }


        }
        public void save()
        {

          /*  SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".doc";
            sf.Filter = "Doc Files |*.doc";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                richTxt.SaveFile(sf.FileName,RichTextBoxStreamType.RichText);
            }
            */
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.ShowHelp = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save As";
            saveFileDialog1.Filter = "Rich Text Format (RTF) (*.rtf)|*.rtf|Office Open XML Document (*.docx)|*.docx|Text Document (*.txt)|*.txt|Adobe PDF Document (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
              
                destination = saveFileDialog1.FileName;
                richTxt.SaveFile(destination, RichTextBoxStreamType.RichText);
                changeName(destination);
            }

        }
        

      /*  private int newSave()
        {
            sfd.Filter = "Rich Text Format (RTF) (*.rtf)|*.rtf|Office Open XML Document (*.docx)|*.docx|Text Document (*.txt)|*.txt|Adobe PDF Document (*.pdf)|*.pdf";
          //  sfd.DefaultExt = "txt";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                richTxt.Focus();
                return 0;
            }
            else
            {
                contents = richTxt.Text;
                if (this.Text == "Untitled")
                    richTxt.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                else
                {
                    sfd.FileName = this.Text;
                    richTxt.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                this.Text = sfd.FileName;

                currentFileLoc = sfd.FileName;
                return 1;
            }
        }*/

       public void newSave()
        {
            saveFileDialog1.InitialDirectory = "D:";
            saveFileDialog1.ShowHelp = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save As";
            saveFileDialog1.Filter = "Rich Text Format (RTF) (*.rtf)|*.rtf|Office Open XML Document (*.docx)|*.docx|Text Document (*.txt)|*.txt|Adobe PDF Document (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destination = saveFileDialog1.FileName;
                richTxt.SaveFile(destination, RichTextBoxStreamType.RichText);
            }
       
      }
       /* public void newSave()
        {

            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = ".doc";
            sf.Filter = "Doc Files |*.doc";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                richTxt.SaveFile(sf.FileName,RichTextBoxStreamType.RichText);
            }

        }
        */
        void write(string dest)
        {
            using (StreamWriter write = new StreamWriter(dest, false))
            {
                write.Write(richTxt.Text);
            }
        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            richTxt.Cut();
            richTxt.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_DropDown(object sender, EventArgs e)
        {

        }

        private void lineSpacing_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            richTxt.Copy();
            richTxt.Focus();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            richTxt.Paste();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            richTxt.SelectAll();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://go.microsoft.com/fwlink/?LinkId=517009");
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            StoreData.setAllText(richTxt.Text);
            Find find = new Find();
            find.Show();
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            StoreData.setAllText(richTxt.Text);
            Replace replace = new Replace();
            replace.Show();
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            if (firsttime == 0)
            {
                save();
            }

            else
            {
                write(destination);
            }
            firsttime++;
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            save();
        }

        private void richTxt_TextChanged(object sender, EventArgs e)
        {
            current = 1;
            float zoom = richTxt.ZoomFactor;

            if (richTxt.Text == "")
            {

                btnFind.Enabled = false;
                btnReplace.Enabled = false;
                btnSelectAll.Enabled = false;
            }

            else
            {
                btnFind.Enabled = true;
                btnReplace.Enabled = true;
                btnSelectAll.Enabled = true;
            }

            this.statusBarUpdate();
      

        }


        public void exit()
        {
            if (current == 1)
            {
                if (current == 1 && firsttime != 0)
                {
                    if (openName != "")
                    {
                        destination = openName;
                        wantToSave();
                        Application.Exit();
                    }
                }

                else if (current == 1 && firsttime == 0)
                {
                    DialogResult query = MessageBox.Show("Do you want to save your changes?", " Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (query == DialogResult.Yes)
                    {
                        newSave();
                        Application.ExitThread();
                    }

                    else
                    {
                        Application.ExitThread();
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }
        private void menuExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void menuNew_Click(object sender, EventArgs e)
        {
            if (current == 1)
            {
                if (firsttime == 0)
                {
                    if (MessageBox.Show("Do you want to save your changes?", " Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        newSave();
                        richTxt.Text = "";
                    }

                    else
                    {
                        richTxt.Text = "";
                    }
                }

                else if (firsttime != 0)
                {
                    wantToSave();
                }
            }
        }

        public void open()
        {
            openFileDialog1.Filter = "Rich Text Format (RTF) (*.rtf)|*.rtf|Office Open XML Document (*.docx)|*.docx|Text Document (*.txt)|*.txt|Adobe PDF Document (*.pdf)|*.pdf";
    
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.InitialDirectory = @"C:\";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTxt.Text = "";
                richTxt.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                this.Text = ofd.FileName;
                contents = richTxt.Text;
               /* System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                richTxt.Text = sr.ReadToEnd();
                openName = openFileDialog1.FileName;
                //richTxt.LoadFile(openName);
                changeName(openName);
                sr.Close();*/
            }
        }
        private void menuOpen_Click(object sender, EventArgs e)
        {
            if (firsttime == 0)
            {
                if (current != 0)
                {
                    if (MessageBox.Show("Do you want to save your changes?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        newSave();
                    }

                    else
                    {
                        open();
                    }
                    destination = saveFileDialog1.FileName;
                    firsttime++;
                }
                if (current == 0)
                {
                    open();
                }
            }

            else
            {
                open();
            }

        }

        private void menuPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();

            }
        }

        private void menuPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTxt.Text, richTxt.Font, Brushes.Black, 100, 20);
            e.Graphics.PageUnit = GraphicsUnit.Inch;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            this.richTxt.Focus();

            statusStrip1.Visible = false;

            foreach (FontFamily each in FontFamily.Families)
            {
                if (each.IsStyleAvailable(FontStyle.Regular))
                {
                    comboFontFamily.Items.Add(each.Name);
                }
            }
            comboFontFamily.Text = this.richTxt.Font.Name.ToString();
            comboFontSize.Text = this.richTxt.Font.Size.ToString("8");

            comboFontSize.Items.Add(8);
            comboFontSize.Items.Add(9);
            comboFontSize.Items.Add(10);
            comboFontSize.Items.Add(11);
            comboFontSize.Items.Add(12);

            for (int i = 14; i <= 28; i += 2)
            {
                comboFontSize.Items.Add(i);
            }

            comboFontSize.Items.Add(36);
            comboFontSize.Items.Add(48);
            comboFontSize.Items.Add(72);
            // richTxt.Focus();

        }

        private void richTxt_SelectionChanged(object sender, EventArgs e)
        {

            if (richTxt.SelectionFont != null)
            {
                chkBold.Checked = richTxt.SelectionFont.Bold;
                chkItalic.Checked = richTxt.SelectionFont.Italic;
                chkUnderline.Checked = richTxt.SelectionFont.Underline;
                chkStrikeout.Checked = richTxt.SelectionFont.Strikeout;
            }

            if (richTxt.SelectionLength > 0)
            {

                btnCut.Enabled = true;
                btnCopy.Enabled = true;
            }
            else
            {
                btnCut.Enabled = false;
                btnCopy.Enabled = false;
            }


        }

        

        private void comboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(((ComboBox)sender).Text);
            richTxt.SelectionFont = new Font(comboFontFamily.Text, size);
            richTxt.Focus();

        }

        private void comboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTxt.SelectionFont == null)
            {
                richTxt.SelectionFont = new Font(comboFontFamily.Text, richTxt.Font.Size);
            }
            richTxt.SelectionFont = new Font(comboFontFamily.Text, richTxt.SelectionFont.Size);
            richTxt.Focus();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStrikeout.Checked == true)
            {
                if (richTxt.SelectionFont == null)
                {
                    return;
                }


                FontStyle style = richTxt.SelectionFont.Style;

                if (richTxt.SelectionFont.Strikeout)
                {
                    style &= ~FontStyle.Strikeout;
                    richTxt.Focus();
                }

                else
                {
                    style |= FontStyle.Strikeout;
                    richTxt.Focus();
                }


                richTxt.SelectionFont = new Font(richTxt.SelectionFont, style);
            }

            else
            {
                richTxt.Focus();
            }
        }


        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBold.Checked == true)
            {
                if (richTxt.SelectionFont == null)
                {
                    return;
                }


                FontStyle style = richTxt.SelectionFont.Style;


                if (richTxt.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                    richTxt.Focus();
                }

                else
                {
                    style |= FontStyle.Bold;
                    richTxt.Focus();

                }

                richTxt.SelectionFont = new Font(richTxt.SelectionFont, style);

            }

            else
            {
                richTxt.Focus();
            }
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItalic.Checked == true)
            {
                if (richTxt.SelectionFont == null)
                {
                    return;
                }

                FontStyle style = richTxt.SelectionFont.Style;

                if (richTxt.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                    richTxt.Focus();
                }
                else
                {
                    style |= FontStyle.Italic;
                    richTxt.Focus();
                }

                richTxt.SelectionFont = new Font(richTxt.SelectionFont, style);
            }

            else
            {
                richTxt.Focus();
            }
        }

        private void chkUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnderline.Checked == true)
            {
                if (richTxt.SelectionFont == null)
                {
                    return;
                }


                FontStyle style = richTxt.SelectionFont.Style;

                if (richTxt.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                    richTxt.Focus();
                }
                else
                {
                    style |= FontStyle.Underline;
                    richTxt.Focus();
                }


                richTxt.SelectionFont = new Font(richTxt.SelectionFont, style);
            }

            else
            {

                richTxt.Focus();
            }
        }

        private void chkBold_MouseHover(object sender, EventArgs e)
        {

        }

        private void chkSub_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSub.Checked == true)
            {


                richTxt.SelectionCharOffset = -3;
                richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text) - 3, richTxt.Font.Style);
                chkSuper.Checked = false;
            }

            else
            {
                if (chkSuper.Checked == true)
                {
                    richTxt.SelectionCharOffset = 3;
                    richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text) - 3, richTxt.Font.Style);

                    richTxt.Focus();
                }

                else
                {
                    richTxt.SelectionCharOffset = 0;
                    richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text), richTxt.Font.Style);

                }
            }
        }

        private void chkSuper_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSuper.Checked == true)
            {

                richTxt.SelectionCharOffset = 3;
                richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text) - 3, richTxt.Font.Style);
                chkSub.Checked = false;
            }

            else
            {
                if (chkSub.Checked == true)
                {
                    richTxt.SelectionCharOffset = -3;
                    richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text) - 3, richTxt.Font.Style);
                }

                else
                {
                    richTxt.SelectionCharOffset = 0;

                    richTxt.SelectionFont = new Font(richTxt.Font.FontFamily, Convert.ToInt32(comboFontSize.Text), richTxt.Font.Style);

                }

                richTxt.Focus();
            }
        }

        private void comboFontFamily_DropDownClosed(object sender, EventArgs e)
        {


        }

        private void lineSpacing_LocationChanged(object sender, EventArgs e)
        {

        }

        private void comboLineSpacing_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        private void statusBarUpdate()
        {
            string s = " ";
            string ch, str, temp;
            int len, wordCount = 1;
            str = richTxt.Text;
            len = str.Length;
            wordCount = 0;
            temp = string.Empty;
           /*
            for (int i = 0; i < len; i++)
            {
                ch = str.Substring(i, 1);
                

                if (ch == "      ")
                {

                    //if (temp.Length > 1)
                    //{
                    wordCount = wordCount + 1;
                    temp = "";
                    //}
                }
               

            }
        
*/

            var text = richTxt.Text.Trim();
            int index = 0;
            while (index < text.Length)
            {
            while (index < text.Length && !char.IsWhiteSpace(text[index]))
                index++;
            wordCount++;
            while (index < text.Length && char.IsWhiteSpace(text[index]))
                index++;
            }
            toolStripStatusLabel1.Text = "Words: " + (wordCount).ToString() + " , Characters: " + richTxt.TextLength;

            Point po = new Point();
            if (checkStatusBar.Checked)
            {
                po.X = 0;
                po.Y = 240;
                statusStrip1.Visible = true;

            }
            else
            {
                po.X = 0;
                po.Y = 262;
                statusStrip1.Visible = false;

            }
        }

        private void toolStripDropDownButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void noWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (noWrapToolStripMenuItem.Checked == false)
            {
                noWrapToolStripMenuItem.Checked = true;
                wrapToWindowToolStripMenuItem.Checked = false;
                richTxt.Dock = DockStyle.Bottom;
                richTxt.WordWrap = false;
            }

            else
            {
                noWrapToolStripMenuItem.Checked = false;
                richTxt.Dock = DockStyle.None;
                richTxt.WordWrap = true;
            }
        }

        private void wrapToWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wrapToWindowToolStripMenuItem.Checked == false)
            {
                wrapToWindowToolStripMenuItem.Checked = true;
                noWrapToolStripMenuItem.Checked = false;
                richTxt.Dock = DockStyle.Bottom;
                richTxt.WordWrap = true;
            }

            else
            {
                wrapToWindowToolStripMenuItem.Checked = false;
                richTxt.Dock = DockStyle.None;
                richTxt.WordWrap = true;
            }
        }

        private void richTxt_KeyDown(object sender, KeyEventArgs e)
        {
            statusBarUpdate();
        }

        private void checkStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            statusBarUpdate();
        }

        private void chkLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLeft.Checked == true)
            {
                chkRight.Checked = false;
                chkCenter.Checked = false;
                chkJustify.Checked = false;

                richTxt.SelectionAlignment = HorizontalAlignment.Left;

            }
        }

        private void chkLeft_MouseClick(object sender, MouseEventArgs e)
        {
            chkLeft.Checked = true;
            richTxt.Focus();
        }

        private void chkCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCenter.Checked == true)
            {
                chkLeft.Checked = false;
                chkRight.Checked = false;
                chkJustify.Checked = false;

                richTxt.SelectionAlignment = HorizontalAlignment.Center;

            }
        }

        private void chkCenter_MouseClick(object sender, MouseEventArgs e)
        {
            chkCenter.Checked = true;
            richTxt.Focus();
        }

        private void chkRight_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRight.Checked == true)
            {
                chkLeft.Checked = false;
                chkCenter.Checked = false;
                chkJustify.Checked = false;

                richTxt.SelectionAlignment = HorizontalAlignment.Right;

            }
        }

        private void chkRight_MouseClick(object sender, MouseEventArgs e)
        {
            chkRight.Checked = true;
            richTxt.Focus();
        }

        private void chkJustify_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJustify.Checked == true)
            {
                chkLeft.Checked = false;
                chkRight.Checked = false;
                chkCenter.Checked = false; 

                string[] lines = richTxt.Lines;

                richTxt.Clear();

                foreach (string l in lines)
                {
                    richTxt.Text += (l.Trim());
                }

            }
        }

        private void chkJustify_MouseClick(object sender, MouseEventArgs e)
        {
            chkJustify.Checked = true;
            richTxt.Focus();

        }

        private void btnIncreaseIndent_Click(object sender, EventArgs e)
        {

            richTxt.SelectionIndent = richTxt.SelectionIndent + 30;
            richTxt.Focus();

        }

        private void btnDecreaseIndent_Click(object sender, EventArgs e)
        {

            richTxt.SelectionIndent = richTxt.SelectionIndent - 30;
            richTxt.Focus();
        }

        private void btnIncreaseIndent_MouseClick(object sender, MouseEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip6_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            forecolorCntxt.Visible = true;
            forecolorCntxt.Location = new Point(356, 77);

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnPicture_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {

        }

        private void btnExpandFont_Click(object sender, EventArgs e)
        { 
            comboFontSize.SelectedIndex = comboFontSize.SelectedIndex + 1;  
            richTxt.SelectionFont = new Font(richTxt.Font.Name, Convert.ToInt32(comboFontSize.Text), richTxt.Font.Style);

        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            float zoom = richTxt.ZoomFactor;
            int rici = richTxt.Width;

            richTxt.ZoomFactor = zoom + 1;
            richTxt.Width = rici + 10;

        }

        private void comboStartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lineSpacing_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReduceFont_Click(object sender, EventArgs e)
        { 
                comboFontSize.SelectedIndex = comboFontSize.SelectedIndex - 1; 
            richTxt.SelectionFont = new Font(richTxt.Font.Name, Convert.ToInt32(comboFontSize.Text), richTxt.Font.Style);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTxt.Paste();
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            float zoom = richTxt.ZoomFactor;
            int rici = richTxt.Width;
            richTxt.ZoomFactor = zoom - 1;
            richTxt.Width = rici - 10;
        }

        private void btnStretch_Click(object sender, EventArgs e)
        {


            richTxt.ZoomFactor = 1;
        }


        private void btnDatetime_Click(object sender, EventArgs e)
        {
            richTxt.Text += DateTime.Now.ToString();

        }

        private void forecolorCntxt_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void btnParagraph_Click(object sender, EventArgs e)
        {

        }

        private void comboFontBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.Cancel)
                richTxt.Focus();

            else
            {
                using (var img = Image.FromFile(op.FileName))

                {
                    Clipboard.SetImage(img);
                    richTxt.Paste();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult rs = colorDialog1.ShowDialog();
            if (rs == DialogResult.OK)
            {
                richTxt.SelectionColor = colorDialog1.Color;
                richTxt.Focus();
            }
          
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
