using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Выполняется при запуске службы
        /// </summary>
        /// <param name="args"></param>
         
            EventLog myLog; //Можно читать и записывать элементы журнала событий
            string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\ServiceLog.txt";  //Хранится путь к файлу
            List<string> list; //Список всех найденных ошибок

        protected override void OnStart(string[] args)
        {
            myLog = new EventLog();
            myLog.Log = "System"; //По умолчанию выставлен тип ошибок - приложение(Application), а нам нужны системные(System).
            myLog.Source = "System Error"; //Какие именно ошибки перехватываем.

            for (int index = myLog.Entries.Count - 1; index > 0; index--) //Перебираем все системные ошибки от новых к более старым
            {
                var errEntry = myLog.Entries[index]; //Чтение записи из журнала событий

                if (errEntry.EntryType == EventLogEntryType.Error) //Проверка ошибка ли это
               {
                    //Получаем нужные данные из записи
                    var appName = errEntry.Source;
                    list = new List<string>();

                    list.Add("ТИП События: " + Convert.ToString(errEntry.EntryType));
                    list.Add("Событие: " + (string)myLog.Log);
                    list.Add("Имя машины: " + (string)errEntry.MachineName);
                    list.Add("Имя приложения: " + (string)errEntry.Source);
                    list.Add("Cjj,Сообщение: " + (string)errEntry.Message);
                    list.Add("Время проишествия: " + errEntry.TimeWritten.ToString());
                    list.Add("-*-");

                    WriteToFile(list); //Записываем данные в файл
                }
            }
        }
        /// <summary>
        /// Запсь в файл лога 
        /// </summary>
        /// <param name="list"></param>
        public void WriteToFile(List<string> list) //Запись в файл
        {
            using (StreamWriter sw = File.AppendText(filepath)) //запись в поток
            {
                for (int i = 0; i < list.Count; i++)
                    sw.WriteLine(list[i]); //Запись в файл.
            }
        }
    

        /// <summary>
        /// Метод выполняется при остановке службы
        /// </summary>
        protected override void OnStop()
        {

        }
    }
}
