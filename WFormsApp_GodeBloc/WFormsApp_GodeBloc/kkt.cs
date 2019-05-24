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
            Constants.LIBFPTR_SETTING_COM_FILE, "COM4",
            Constants.LIBFPTR_SETTING_BAUDRATE, Constants.LIBFPTR_PORT_BR_115200);

            fptr.setSettings(settings);
        }

        //открытие и проверка подключения
        public string OpenKKTDrav()
         {
            IFptr fptr = new Fptr(); // инициал др
            fptr.open(); // открытие файла.

            string temp = "";
            bool isOpened = fptr.isOpened(); // проверка подключения

            if (isOpened == true)
            {
                temp = "Проверка состояния логического соединения Завершена успешно";
            }



            return temp;

        }
        //Заспрос ккм имя и завотской номер
        public string ZaprosInfu()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_STATUS); // получение всех параметров
            fptr.queryData();

            string model = fptr.getParamInt(Constants.LIBFPTR_PARAM_MODEL).ToString(); //получение модели
            string smena  = fptr.getParamInt(Constants.LIBFPTR_PARAM_SHIFT_STATE).ToString();
            string numberKKT =  fptr.getParamString(Constants.LIBFPTR_PARAM_SERIAL_NUMBER);
            string nameKKM = fptr.getParamString(Constants.LIBFPTR_PARAM_MODEL_NAME); //имя ккм

            

            return $"***ИНФОРМАЦИЯ О ККТ*** \t\n Имя ККМ:{nameKKM} \t\n Серийный номер:{numberKKT} \t\n Состояние текущей смены: {smena} ";
        }
        /// <summary>
        /// Получение суммы
        /// </summary>
        /// <returns></returns>
        public string GetSummaKeshDA()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_CASH_SUM); // получение суммы ккт
            fptr.queryData();
                 
            string getSumma = fptr.getParamDouble(Constants.LIBFPTR_PARAM_SUM).ToString();

            return getSumma;
        }


       public string CountRegestracia()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_REGISTRATIONS_COUNT); // получение количества регистраций
            fptr.queryData();

            string Getcount = fptr.getParamInt(Constants.LIBFPTR_PARAM_COUNT).ToString(); // запрос к кассе

            return Getcount;
        }

        //Запрос суммы выплат
        public string GetCashCount()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_REVENUE); // получение количества регистраций
            fptr.queryData();

            string getCashCount = fptr.getParamDouble(Constants.LIBFPTR_PARAM_SUM).ToString();
            return getCashCount;
        }

       //количество чеков
       public string GetChekCaunt()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_PARAM_RECEIPT_TYPE); // получение количества регистраций
            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL); //rjkbxtcndj чеков прихода
            fptr.queryData();

            string countChek = fptr.getParamInt(Constants.LIBFPTR_PARAM_DOCUMENTS_COUNT).ToString();// получение количества чеков

            return countChek;

        }

        public string TimeDateKKM()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.
           
            fptr.setParam(Constants.LIBFPTR_PARAM_DATA_TYPE, Constants.LIBFPTR_DT_DEVICE_UPTIME); // получение количества регистраций

            string timeKKM = fptr.getParamInt(Constants.LIBFPTR_PARAM_DEVICE_UPTIME).ToString();

            return timeKKM;
        }

        ////*****************
        /// <summary>
        /// Открытие смены
        /// </summary>
        public string RegestraciAOpenSmena()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            //fptr.setParam(1021, "Кассир Иванов И.");
            //fptr.setParam(1203, "123456789047");
            //fptr.operatorLogin(); // регистрация, применение настроек

         //  Открытие смены

            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();

           int open = fptr.openShift(); // открытие смены

            string nomerErrot = fptr.errorCode().ToString();
            string opisaniError = fptr.errorDescription();

            fptr.checkDocumentClosed(); // проверка что операция открытия смены успешно проведена


            fptr.close();
            return $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}";
        }

        /// <summary>
        /// Закрыть смену
        /// </summary>
        /// <returns></returns>
        public string CloseSmena()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();

            fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT); // параметры закрытия смены
            fptr.report();// сам факт закрыия смены

            string nomerErrot = fptr.errorCode().ToString();
            string opisaniError = fptr.errorDescription();

            fptr.checkDocumentClosed();
            fptr.close(); // закрытие драйвера

            return $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}";
        }


        public string CloseCheks()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.cancelReceipt();
            string nomerErrot = fptr.errorCode().ToString();
            string opisaniError = fptr.errorDescription();

            fptr.close(); // закрытие драйвера

            return $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}";
            fptr.close(); // закрытие драйвера
        }

        public string OpenChekTreid()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.setParam(1021, "Кассир Иванов И.");
            fptr.setParam(1203, "123456789047");
            fptr.operatorLogin();

            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL); // параметр вида чека. Тут стоит чек продажи
            fptr.openReceipt(); // метод открыть чек!!

            string nomerErrot = fptr.errorCode().ToString();
            string opisaniError = fptr.errorDescription();

         //   label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //// Открытие чека возврата продажи с автоматическим расчетом НДС18

            //fptr.setParam(1021, "Кассир Иванов И.");
            //fptr.setParam(1203, "123456789047");
            //fptr.operatorLogin();

            //nomerErrot += fptr.errorCode().ToString();
            //opisaniError += fptr.errorDescription();

            //label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL_RETURN);
            //fptr.setParam(Constants.LIBFPTR_PARAM_USE_VAT18, true);
            //fptr.openReceipt();

            //nomerErrot += fptr.errorCode().ToString();
            //opisaniError += fptr.errorDescription();
            //label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //// Регистрация позиции с указанием суммы налога

            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "Тестовой Товар");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 100); // цена
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 100); //количество товара
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT0); // сумма ндс
            // fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18); // сумма ндс
            // fptr.setParam(Constants.LIBFPTR_PARAM_TAX_SUM, 51.5);
            fptr.setParam(Constants.LIBFPTR_PARAM_USE_ONLY_TAX_TYPE, true); //Регистрация позиции без расчета суммы налога

            fptr.registration(); // принять.

            //  Оплата чека

            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH); //вид оплаты Тут наликом
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_SUM, 1000.00);  // сумма
            fptr.payment();  // плптеж

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
           // label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //// Регистрация налога на чек

            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18);
            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_SUM, 100.00);
            //fptr.receiptTax();

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
          //  label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


            //  Регистрация итога чека
            fptr.setParam(Constants.LIBFPTR_PARAM_SUM, 1000.00); // итог сумма
            fptr.receiptTotal(); // предварительный итог


            // Закрытие полностью оплаченного чека

            fptr.closeReceipt();
            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
           // label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


            //  Проверка закрытия документа(на примере закрытия фискального чека)

            fptr.closeReceipt();

            //while (fptr.checkDocumentClosed() < 0)
            //{
            //    // Не удалось проверить состояние документа. Вывести пользователю текст ошибки, попросить устранить неполадку и повторить запрос
            //    Console.WriteLine(fptr.errorDescription());
            //    continue;
            //}

            //if (!fptr.getParamBool(Constants.LIBFPTR_PARAM_DOCUMENT_CLOSED))
            //{
            //    // Документ не закрылся. Требуется его отменить (если это чек) и сформировать заново
            //    fptr.cancelReceipt();
            //    return;
            //}

            //if (!fptr.getParamBool(Constants.LIBFPTR_PARAM_DOCUMENT_PRINTED))
            //{
            //    // Можно сразу вызвать метод допечатывания документа, он завершится с ошибкой, если это невозможно
            //    while (fptr.continuePrint() < 0)
            //    {
            //        // Если не удалось допечатать документ - показать пользователю ошибку и попробовать еще раз.
            //        Console.WriteLine(String.Format("Не удалось напечатать документ (Ошибка \"{0}\"). Устраните неполадку и повторите.", fptr.errorDescription()));
            //        continue;
            //    }


            // Допечатывание документа

            fptr.continuePrint();


            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();

            fptr.close(); // закрытие драйвера

            return $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}";
        }

        

    }
}
