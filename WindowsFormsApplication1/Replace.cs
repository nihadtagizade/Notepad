using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Replace : Form
    {

        static int curr = 0;
        string text;
        public Replace()
        {
            InitializeComponent();
        }

        Form1 frm1 = (Form1)Application.OpenForms[0];
        private void Replace_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (frm1.richTxt.Text == "")
            {
                MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
            }
            else
            {
                text = StoreData.getAllText();
                char[] text_arr = new char[text.Length];
                for (int i = curr; i < text.Length; i++)
                {
                    if (text.Substring(curr, textBox1.Text.Length) == textBox1.Text)
                    {
                        frm1.richTxt.Select(curr, textBox1.Text.Length);
                        curr++;
                        break;
                    }
                    else
                    {
                        if (curr == text.Length - 1)
                        {
                            MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
                        }
                    }
                    curr++;
                }
                text = frm1.richTxt.Text;
                StoreData.setAllText(frm1.richTxt.Text);
                frm1.richTxt.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (frm1.richTxt.Text == "")
            {
                MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
            }
            else
            {
                int current;
                text = StoreData.getAllText();
                char[] text_arr = new char[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    current = i;
                    if (text.Substring(i, textBox1.Text.Length) == textBox1.Text)
                    {
                        for (int j = 0; j < text.Length; j++)
                        {
                            text_arr[j] = text.ToCharArray()[j];
                        }
                        for (int k = 0; k < textBox2.Text.Length; k++)
                        {
                            text_arr[current] = textBox2.Text.ToCharArray()[k];
                            current++;
                        }
                        frm1.richTxt.Text = "";
                        for (int j = 0; j < text.Length; j++)
                        {
                            frm1.richTxt.Text += text_arr[j];
                        }
                        break;
                    }
                }
                text = frm1.richTxt.Text;
                StoreData.setAllText(frm1.richTxt.Text);
                frm1.richTxt.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (frm1.richTxt.Text == "")
            {
                MessageBox.Show("Can not find " + textBox1.Text, "Notepad");
            }
            else
            {
                int current;
                text = StoreData.getAllText();
                char[] text_arr = new char[text.Length];
                for (int i = 0; i < text.Length; i++)
                {
                    current = i;
                    if (text.Substring(i, textBox2.Text.Length) == textBox1.Text)
                    {
                        for (int j = 0; j < text.Length; j++)
                        {
                            text_arr[j] = text.ToCharArray()[j];
                        }
                        for (int k = 0; k < textBox2.Text.Length; k++)
                        {
                            text_arr[current] = textBox2.Text.ToCharArray()[k];
                            current++;
                        }
                        frm1.richTxt.Text = "";
                        for (int j = 1; j < text.Length; j++)
                        {
                            frm1.richTxt.Text += text_arr[j];
                        }
                        StoreData.setAllText(frm1.richTxt.Text);
                        text = frm1.richTxt.Text;
                    }
                }
                frm1.richTxt.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                curr = 0;
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
        }
    }
}