﻿using System;
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

        }

        //Кнопка открыть лог
        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = ReaderLogFile();
        }


        public string ReaderLogFile()
        {
            string pathLog = @"Log.text";
            string text;

            using (StreamReader streamReader = new StreamReader(pathLog, System.Text.Encoding.Default))
            {
                text = streamReader.ReadToEnd(); // прочитать весь файл
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
    }
}