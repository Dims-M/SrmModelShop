using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Кнопка лог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            string url = @"https://yandex.ru/";
            webBrowser1.Navigate(url);

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & textBox1.Text != "")
            {
                webBrowser1.Navigate(textBox1.Text.Trim());
            }
        }

        /// <summary>
        /// Кнопка выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Кнопка текстокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Кнопка очистить 
        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "Очистка";
        }
    }
}
