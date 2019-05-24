using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atol.Drivers10.Fptr;

namespace WFormsApp_GodeBloc
{
    class kkt
    {

        public string GetVercionKKT()
        {
            IFptr fptr = new Fptr(); // инициал др
            String version = fptr.version(); // запрос версии

            return version;
        }

        public void Settih()
        {
            IFptr fptr = new Fptr(); // инициал др

            string settings = String.Format("{\"{0}\": {1}, \"{2}\": {3}, \"{4}\": \"{5}\", \"{6}\": {7}}",
            Constants.LIBFPTR_SETTING_MODEL, Constants.LIBFPTR_MODEL_ATOL_AUTO,
            Constants.LIBFPTR_SETTING_PORT, Constants.LIBFPTR_PORT_COM,
            Constants.LIBFPTR_SETTING_COM_FILE, "COM39",
            Constants.LIBFPTR_SETTING_BAUDRATE, Constants.LIBFPTR_PORT_BR_115200);

            fptr.setSettings(settings);
        }

        public string ghty()
         {
            IFptr fptr = new Fptr(); // инициал др
            fptr.open(); // открытие файла.

            string temp = "";

            bool isOpened = fptr.isOpened();

            

            if (isOpened == true)
            {
                temp = "Проверка состояния логического соединения Завершена успешно";
            }

            return temp;

        }

    }
}
