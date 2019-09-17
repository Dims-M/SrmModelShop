using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Tzest
{
    public partial class Form1 : Form
    {

        BL bLutiliti;

        public Form1()
        {
            InitializeComponent();
           // label2.Text = "НЕ установленно!!";
        }

        /// <summary>
        /// Кнопка применить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
           // bLutiliti.SetAllAlkoAtribut();
            label3.Text += $"Были изменены алгоголные реквезиты!! {bLutiliti.SetAllAlkoAtribut()}\t\nКоличество пивных напитков:{bLutiliti.ConnectBD()} ";

        }

        /// <summary>
        /// Форма при загрузке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            bLutiliti = new BL();
            string net =  bLutiliti.ConnectBD();
            label2.Text = net;
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Кнопка посмотреть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            FormAllProdukt formAllProdukt = new FormAllProdukt();
            formAllProdukt.Show();
        }
    }
}
