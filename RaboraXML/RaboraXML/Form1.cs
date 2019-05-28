using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaboraXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        RabXml rabXml = new RabXml();

        //Кнопка пуск
        private void Button1_Click(object sender, EventArgs e)
        {
           label1.Text = rabXml.ReadingXml();

        }
    }
}
