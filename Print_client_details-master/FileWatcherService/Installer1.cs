using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace FileWatcherService 
{
    // https://metanit.com/sharp/tutorial/21.2.php

    [RunInstaller(true)] //Атрибут [RunInstaller(true)] указывает на то, что класс Installer1 должен вызываться при установке сборки, то есть службы.
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public Installer1()
        {
            InitializeComponent();

            serviceInstaller = new ServiceInstaller(); //ласс ServiceInstaller предназначен для настройки значений для каждой из запускаемых служб
            processInstaller = new ServiceProcessInstaller(); //управляет настройкой значений для всех запускаемых служб внутри одного процесса (как было рассмотрено в прошлой теме, метод Main класса Program может одновременно запускать несколько служб)

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "Service1"; // имя службы
            serviceInstaller.StartType = ServiceStartMode.Automatic; //пределяет, как должна запускаться служба - автоматически или вручную
            serviceInstaller.DelayedAutoStart = true; // определяет, должна ли служба запускаться не сразу после загрузки операционной системы, а немного позже
            serviceInstaller.ServiceName = "Странная хрень"; //устанавливает имя службы, которое будет отображаться в различных утилитах управления службами


            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
