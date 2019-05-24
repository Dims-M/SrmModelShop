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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<int> CollectionChangeAction = new List<int>();


        //Кнопка выход
        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Кнопка ОК
        private void Button1_Click(object sender, EventArgs e)
        {
            JobMethtodLink(); //Намудрл
           // Zapuskator();
        }

        //Кнопка прочитать лог 
        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();

            
        }



        //Методы

        /// <summary>
        /// Рандомное заполнение
        /// </summary>
        /// <param name="_count"></param>
        /// <returns></returns>
        public int RandomIntCount(int ferstCount,int _count)
        {
            Random random = new Random();
            int tempCount = random.Next(ferstCount ,_count);

            return tempCount;
        }
        /// <summary>
        /// заполнение листа
        /// </summary>
        /// <param name="tsList"></param>
        /// <returns></returns>
        public List<int> ZapolnenieLista( int contList =10)
        {
            Random random = new Random();
            int tempCount;

            for (int i=0; i< contList; i++)
            {
                tempCount = random.Next(100);
                CollectionChangeAction.Add(tempCount);
            }
            

            return CollectionChangeAction;
        }

        /// <summary>
        /// Вывод листа
        /// </summary>
        /// <param name="listt"></param>
        /// <returns></returns>
        public string ShouList(List<int> listt)
        {
            DateTime dateTime = new DateTime();
            string stringBu = "Содержимое листа\n";
            string tempLog = $"Время события: {DateTime.Now}\t\n";

            foreach (var item in listt)
                {
                    stringBu += item.ToString();
                    label1.Text += item;
                    stringBu += "\t\n";
                }

            SaveLogFail(tempLog + stringBu);
            return stringBu;
        }

        //запись в файл 
        public void SaveLogFail(string logText)
        {
            string pathLog = @"Log.text";

            using (StreamWriter streamWriter = new StreamWriter(pathLog, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(logText);

            }

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

        /// <summary>
        /// Тестовой метод запуска
        /// </summary>
        public void JobMethtodLink()
        {

            ZapolnenieLista(); // заполнение листа

            label1.Text= ShouList(CollectionChangeAction);

        }

        //Тест метод
        public void Zapuskator()
        {

            for (int i=0; i<10; i++)
            {
                CollectionChangeAction.Add(i);
            }

            string tempItemList = "Содержимое ммассива\t\n";

            Random random = new Random();

            foreach (var item in CollectionChangeAction)
            {

                //tempItemList += item.ToString();
                tempItemList += random.Next(1000);
                tempItemList += "\t\n";
            }

            label1.Text = tempItemList;

        }
         
    }
}
