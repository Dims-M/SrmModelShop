﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcherService
{
    public partial class Service1 : ServiceBase
    {
        Logger logger;// экземпляр класса логер

        public Service1()
        {
            logger = new Logger(); // инициализируем класс логер
            Thread loggerThread = new Thread(new ThreadStart(logger.Start)); //создаем поток для логера
            loggerThread.Start(); //запуск потока
            InitializeComponent();
        }

        /// <summary>
        /// запускает действия, выпоняемые службой
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            logger = new Logger(); // инициализируем класс логер
            Thread loggerThread = new Thread(new ThreadStart(logger.Start)); // создаем поток для  экземпляра логер
            loggerThread.Start(); //запуск потока
        }

        /// <summary>
        ///метод останавливающий службу
        /// </summary>
        protected override void OnStop()
        {
            logger.Stop(); // останавливаем поток
            Thread.Sleep(1000); // на 1 секунду
        }
    }


    class Logger
    {
        FileSystemWatcher watcher; //Слушитель Ожидает уведомления файловой системы об изменениях и инициирует события при изменениях каталога или файла в каталоге.
        object obj = new object(); // новый обьект
        bool enabled = true; 
        public Logger()
        {
            watcher = new FileSystemWatcher("D:\\диск С"); // место которое прошлушивается
            watcher.Deleted += Watcher_Deleted;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;
        }

        /// <summary>
        /// Запуск слушителя
        /// </summary>
        public void Start()
        {
            watcher.EnableRaisingEvents = true; // Определяем доступность слушителя
            while (enabled)
            {
                Thread.Sleep(1000); // Слушает каждую секунду.
            }
        }


        /// <summary>
        /// Останавливает слушителя
        /// </summary>
        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
            enabled = false;  // останавливаем слушителя.
        }

        // переименование файлов
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            string fileEvent = "переименован в " + e.FullPath;
            string filePath = e.OldFullPath; // полный путь файла
            RecordEntry(fileEvent, filePath);
        }

        // изменение файлов
        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "изменен";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        // создание файлов
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "создан";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }
        // удаление файлов
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string fileEvent = "удален";
            string filePath = e.FullPath;
            RecordEntry(fileEvent, filePath);
        }

        //Запись события или изменения файла.
        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("D:\\templog.txt", true))
                {
                    writer.WriteLine(String.Format("{0} файл {1} был {2}",
                        DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"), filePath, fileEvent));
                    writer.Flush(); // очистка буфера 
                }
            }
        }

    }
}