using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsApp_GodeBloc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            kkt kkt1 = new kkt();
            label1.Text = kkt1.GetVercionKKT();
        }

        //Кнопка открыть лог
        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = ReaderLogFile();
        }

        //Прочитает из файла лога
        public string ReaderLogFile()
        {
            string pathLog = @"Log.text";
            string text="";

            if (File.Exists(pathLog))
            {
                using (StreamReader streamReader = new StreamReader(pathLog, System.Text.Encoding.Default))
                {
                    text = streamReader.ReadToEnd(); // прочитать весь файл
                }
            }

            else
            {
                text = "Ошибка";
            }
            return text;
        }

        //Кнопка очистить
        private void Button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            
        }

        //Кнопка очистить
        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string pathLog = @"Log.text";
            File.Delete(pathLog);
        }
    }
}
