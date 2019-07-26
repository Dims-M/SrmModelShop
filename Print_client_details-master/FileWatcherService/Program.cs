using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherService
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun; //массиив служб (если их несколько)
            ServicesToRun = new ServiceBase[]
            {
                new Service1() //  текущая служба 
            };
            ServiceBase.Run(ServicesToRun); //Запуск службы производится с помощью метода Run
        }
    }
}
