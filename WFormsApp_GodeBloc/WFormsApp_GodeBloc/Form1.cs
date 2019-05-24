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
    public partial class Form1  : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<int> CollectionChangeAction = new List<int>();

        string tempListJornal = "";


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
        public List<int> ZapolnenieLista( int contList =30)
        {
            Random random = new Random();
            int tempCount;
            tempListJornal="";

            for (int i=0; i< contList; i++)
            {
                tempCount = random.Next(100);
                tempListJornal += tempCount;
                tempListJornal += "\t\n";

                CollectionChangeAction.Add(tempCount);
            }

            SaveLogFail("List", tempListJornal );
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

        //Чтение и заполнение массива из файла
        public List<string> FeadingTextFileAndList()
        {
            string tempFile = ReaderLogFile("List.text");
            string[] failList = new string[tempListJornal.Length+1];

            string ttt = "";

            List<string> list2 = new List<string>();

            foreach (var s in failList)
            {
                //  failList = tempFile.Split(' ');
                list2.AddRange(tempFile.Split(' '));
            }

            foreach(var i in list2)
            {
                ttt += i;
                ttt += "\t\n";
            }
            label1.Text = ttt;
            return list2;
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

        /// <summary>
        /// Сохранение в файл с передачей имени файла, и пути
        /// </summary>
        /// <param name="nameList">ИМя файла</param>
        /// <param name="logText">Путь к файлу</param>
        public void SaveLogFail(string nameList ,string logText)
        {
            string pathLog = $"{nameList}.text";

            using (StreamWriter streamWriter = new StreamWriter(pathLog, true, System.Text.Encoding.Default))
            {
                streamWriter.Write(logText);
            }
        }

        /// <summary>
        /// Прочитать лог из текстового файла
        /// </summary>
        /// <returns></returns>
        public string ReaderLogFile(string pathLogF = @"Log.text")
        {
            string pathLog = pathLogF;
            string text;

            using (StreamReader streamReader = new StreamReader(pathLog, System.Text.Encoding.Default))
            {
                text = streamReader.ReadToEnd(); // прочитать весь файл
            }

            return text;
        }

        //Получения их колекции нужных данных 
            public string GettingDataInt(int dateCount)
        {
            var strTempData = from item in CollectionChangeAction
                              where item  < dateCount
                              select item;

            string temp="пппп";

            foreach (var hren in strTempData)
            {
                temp += hren.ToString();
                temp += "\t\n";
                label2.Text += hren.ToString();
            }
            return temp;
        }

        //получение интовых данных из текст блока
        public int GetTextBlocToInt()
        {
            try
             {
                var tempZnach = int.Parse(textBox1.Text);
                return tempZnach;
            }

            catch (Exception ex)
            {
                
            }

            return 0;
        }

        //Тестовой метод запускатор
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

        //кнопка получения
        private void Button4_Click(object sender, EventArgs e)
        {
            // label2.Text = GettingDataInt(GetTextBlocToInt()); // нужное значение, нужный лист 

            //  FeadingTextFileAndList(); // прочитать и заполнить в лист данные из файла

            kkt kkt1 = new kkt();
            label1.Text = kkt1.GetVercionKKT();
            label1.Text += kkt1.ghty();


        }





        //поле ввода Текст блок
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Кнопка очистить
        private void Button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            label1.Text = " ";
            label2.Text = " ";
        }
    }
}
