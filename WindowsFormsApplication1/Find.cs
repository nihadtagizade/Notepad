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
    public partial class Find : Form
    {

        int k = 0;
        string text;
        static int curr = 0;
        public Find()
        {
            InitializeComponent();
        }

        private void Find_Load(object sender, EventArgs e)
        {

        }

        Form1 frm1 = (Form1)Application.OpenForms[0];
        
        private void button1_Click(object sender, EventArgs e)
        {
            // string[] k;
            // k[0] = Form1.txt.Lines.GetValue(0);

            if (frm1.richTxt.Text =="")
            {
                MessageBox.Show("Can not find " + textBox1.Text, "My Pad");
            }
            else
            {
                text = StoreData.getAllText();
                if (radioButton2.Checked == true)
                {
                    for (int i = curr; i <= text.Length; i++)
                    {
                        if (curr + textBox1.Text.Length <= text.Length)
                        {
                            if (text.Substring(curr, textBox1.Text.Length) == textBox1.Text)
                            {
                                frm1.richTxt.Select(curr, textBox1.Text.Length);
                                curr++;
                                break;
                            }
                            else
                            {
                                curr++;
                                if (curr == text.Length)
                                {
                                    MessageBox.Show("Can not find " + textBox1.Text, "My Pad");
                                }
                            }
                        }
                    }
                }
                else
                {
                    // k to able the current continuted not in the start
                    if (k == 0)
                    {
                        k = 1;
                        curr = text.Length - textBox1.Text.Length;
                        StoreData.setCurrent(curr);
                    }
                    for (int i = StoreData.getCurrent(); i >= 0; i--)
                    {
                        // if (curr <= 0)
                        //{
                        if (text.Substring(curr, textBox1.Text.Length) == textBox1.Text)
                        {
                            frm1.richTxt.Select(curr, textBox1.Text.Length);

                            curr--;
                            StoreData.setCurrent(curr);
                            break;

                        }
                        else
                        {
                            curr--;
                            if (curr == 0)
                            {
                                MessageBox.Show("Can not find " + textBox1.Text, "My Pad");
                            }
                        }
                        //}
                        StoreData.setCurrent(curr);
                    }
                }
                text = frm1.richTxt.Text;
                StoreData.setAllText(frm1.richTxt.Text);
                frm1.richTxt.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                curr = 0;
                k = 0;
                button1.Enabled = true;
            }
        }
    }
}
