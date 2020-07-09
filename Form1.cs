using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Enigma_2.Properties;
namespace Enigma_2
{
    public partial class Enigma : Form
    {
        public Enigma()
        {
            InitializeComponent();
            textBox3.Text = Settings.Default["TextName"].ToString();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   

        private void Button1_Click(object sender, EventArgs e)
        {
            int l = 0;
            int k = 0;

            string code = Convert.ToString(textBox3.Text);
            textBox2.Text = null;
            string t = textBox1.Text;
            string w = null;
            switch (comboBox1.SelectedIndex)
            {
                case 0: w = "send"; break;
                case 1: w = "take"; break;
            }
            
            if (w == "send")
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if ((t[i] > 64 && t[i] < 91) || (t[i] > 96 && t[i] < 123))
                    {
                        if (char.IsLower(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] + k) - 97) % 26) + 97));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        else if (char.IsUpper(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] + k) - 65) % 26) + 65));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                    }
                    else if (t[i] > 1039 && t[i] < 1104)
                    {
                        if (char.IsLower(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] + k) - 1072) % 32) + 1072));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        else if (char.IsUpper(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] + k) - 1040) % 32) + 1040));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        
                    }
                    else
                        textBox2.Text += Convert.ToString(t[i]);
                } 
            }
            if (w == "take")
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if ((t[i] > 64 && t[i] < 91)|| (t[i] > 96 && t[i] < 123))
                    {
                        if (char.IsLower(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] - k) - 122) % 26) + 122));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        else if (char.IsUpper(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] - k) - 90) % 26) + 90));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        
                    }
                    else if (t[i] > 1039 && t[i] < 1104)
                    {
                        if (char.IsLower(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] - k) - 1103) % 32) + 1103));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                        else if (char.IsUpper(t[i]))
                        {
                            k = swift(code[l]);
                            textBox2.Text += Convert.ToString(Convert.ToChar((((t[i] - k) - 1071) % 32) + 1071));
                            l++;
                            if (l >= code.Length)
                            { l = 0; }
                        }
                    }
                    else
                        textBox2.Text += Convert.ToString(t[i]);
                                                        

                }
            }
            //*/
            Settings.Default["Textname"] = textBox3.Text;
            Settings.Default.Save();
        }

        public static int swift(char c)
        {
            int k = 0;
            if (char.IsLower(c))
            { k = c - 97; }
            else
            { k = c - 65; }
            return k;
        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a') && (e.KeyChar <= 'z') || (e.KeyChar >='A') && (e.KeyChar <='Z'))
                return;
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (sender.Equals(textBox1))
                        textBox2.Focus();
                    else
                        return;
                }
                return;   
            }
            e.Handled = true;
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
