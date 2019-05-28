using Atol.Drivers10.Fptr;
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

        string tempListJornal = "";

        static kkt kkt2 = new kkt();
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
        public int RandomIntCount(int ferstCount, int _count)
        {
            Random random = new Random();
            int tempCount = random.Next(ferstCount, _count);

            return tempCount;
        }
        /// <summary>
        /// заполнение листа
        /// </summary>
        /// <param name="tsList"></param>
        /// <returns></returns>
        public List<int> ZapolnenieLista(int contList = 30)
        {
            Random random = new Random();
            int tempCount;
            tempListJornal = "";

            for (int i = 0; i < contList; i++)
            {
                tempCount = random.Next(100);
                tempListJornal += tempCount;
                tempListJornal += "\t\n";

                CollectionChangeAction.Add(tempCount);
            }

            SaveLogFail("List", tempListJornal);
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
            string[] failList = new string[tempListJornal.Length + 1];

            string ttt = "";

            List<string> list2 = new List<string>();

            foreach (var s in failList)
            {
                //  failList = tempFile.Split(' ');
                list2.AddRange(tempFile.Split(' '));
            }

            foreach (var i in list2)
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
        public void SaveLogFail(string nameList, string logText)
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
                              where item < dateCount
                              select item;

            string temp = "пппп";

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
            label1.Text = ShouList(CollectionChangeAction);

        }

        //Тест метод
        public void Zapuskator()
        {

            for (int i = 0; i < 10; i++)
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
            label1.Text += kkt1.GetVercionKKT();
            label1.Text += "\t\n";
            label1.Text += kkt1.ZaprosInfu();
            label1.Text += $"Текущая сумма в денежном ящике:{kkt1.GetSummaKeshDA()}";
            label1.Text += $"Счеткик регистраций:{kkt1.CountRegestracia()}";
            label1.Text += "\t\n";
            label1.Text += $"Сумма выручки :{kkt1.GetCashCount()}";
            label1.Text += "\t\n";
            label1.Text += $"Количество чеков :{kkt1.GetChekCaunt()}";
            label1.Text += "\t\n";
            label1.Text += $"Время :{kkt1.TimeDateKKM()}";
            label1.Text += "\t\n";
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

        //Кнопка открыть смену. 
        private void Button6_Click(object sender, EventArgs e)
        {
            kkt kkt1 = new kkt();
            // kkt1.RegestraciAOpenSmena();

            label1.Text = kkt1.RegestraciAOpenSmena().ToString();


        }

        //Кнопка закрыть смену.
        private void Button7_Click(object sender, EventArgs e)
        {
            kkt kkt1 = new kkt();
            kkt1.CloseSmena();
        }

        // кнопка продажи
        private void Button8_Click(object sender, EventArgs e)
        {

            //kkt kkt1 = new kkt();
            //kkt1.OpenChekTreid(); // Кнопка продажи чека

           // OpenChekTreid(); //Продажа работает!!!!!!!!!!!!!!!

            ProdajaEmai(); // НЕ РАБ

           // testPrimer();

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

            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

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
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //// Регистрация налога на чек

            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18);
            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_SUM, 100.00);
            //fptr.receiptTax();

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


            //  Регистрация итога чека
            fptr.setParam(Constants.LIBFPTR_PARAM_SUM, 1000.00); // итог сумма
            fptr.receiptTotal(); // предварительный итог


            // Закрытие полностью оплаченного чека

            fptr.closeReceipt();
            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


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


        public string ProdajaEmai()
        {

            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            //Открытие печатного чека ДЛЯ печати чека
            //fptr.setParam(1021, "Кассир Иванов И.");
            //fptr.setParam(1203, "123456789047");
            //fptr.operatorLogin();

            //fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL); // параметр вида чека. Тут стоит чек продажи
            //fptr.openReceipt(); // метод открыть чек!!

            string nomerErrot = fptr.errorCode().ToString();
            string opisaniError = fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

          //  Открытие электронного чека

            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL);
            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_ELECTRONICALLY, true); //LIBFPTR_PT_ELECTRONICALLY
            fptr.setParam(1117, "1@mai.ru");
            fptr.setParam(1008, "client@mail.ru");
            
            fptr.openReceipt();

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "Тестовой Товар");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 100); // цена
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 100); //количество товара
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT0); // сумма ндс
            // fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18); // сумма ндс
            // fptr.setParam(Constants.LIBFPTR_PARAM_TAX_SUM, 51.5);
            fptr.setParam(Constants.LIBFPTR_PARAM_USE_ONLY_TAX_TYPE, true); //Регистрация позиции без расчета суммы налога

            fptr.registration(); // принять.

            //  Оплата чека

           // fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH); //вид оплаты Тут наликом
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_ELECTRONICALLY); //вид оплаты Тут наликом
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_SUM, 1000.00);  // сумма
            fptr.payment();  // плптеж

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";

            //// Регистрация налога на чек

            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18);
            //fptr.setParam(Constants.LIBFPTR_PARAM_TAX_SUM, 100.00);
            //fptr.receiptTax();

            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


            //  Регистрация итога чека
            fptr.setParam(Constants.LIBFPTR_PARAM_SUM, 1000.00); // итог сумма
            fptr.receiptTotal(); // предварительный итог


            // Закрытие полностью оплаченного чека

            fptr.closeReceipt();
            nomerErrot += fptr.errorCode().ToString();
            opisaniError += fptr.errorDescription();
            label1.Text += $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}\t\n";


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
    
        public void testPrimer()
        {
            IFptr fptr = new Fptr();
            fptr.setSingleSetting(Constants.LIBFPTR_SETTING_PORT, (Constants.LIBFPTR_PORT_USB).ToString());
            fptr.applySingleSettings();

            // Соединение с ККТ
            fptr.open();

            // Регистрация кассира
            fptr.setParam(1021, "Иванов И.И.");
            fptr.setParam(1203, "500100732259");
            fptr.operatorLogin();

            // Открытие чека (с передачей телефона получателя)
            fptr.setParam(Constants.LIBFPTR_PARAM_RECEIPT_TYPE, Constants.LIBFPTR_RT_SELL);
            fptr.setParam(1008, "+79161234567");
            fptr.openReceipt();

            // Регистрация позиции
            fptr.setParam(Constants.LIBFPTR_PARAM_COMMODITY_NAME, "Чипсы LAYS");
            fptr.setParam(Constants.LIBFPTR_PARAM_PRICE, 73.99);
            fptr.setParam(Constants.LIBFPTR_PARAM_QUANTITY, 5);
            fptr.setParam(Constants.LIBFPTR_PARAM_TAX_TYPE, Constants.LIBFPTR_TAX_VAT18);
            fptr.setParam(1212, 1);
            fptr.setParam(1214, 7);
            fptr.registration();

            // Регистрация итога (отрасываем копейки)
            fptr.setParam(Constants.LIBFPTR_PARAM_SUM, 369.0);
            fptr.receiptTotal();

            // Оплата наличными
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_TYPE, Constants.LIBFPTR_PT_CASH);
            fptr.setParam(Constants.LIBFPTR_PARAM_PAYMENT_SUM, 1000);
            fptr.payment();

            // Закрытие чека
            fptr.closeReceipt();

            while (fptr.checkDocumentClosed() < 0)
            {
                // Не удалось проверить состояние документа. Вывести пользователю текст ошибки, попросить устранить неполадку и повторить запрос
              //  Console.WriteLine(fptr.errorDescription());
                continue;
            }

            if (!fptr.getParamBool(Constants.LIBFPTR_PARAM_DOCUMENT_CLOSED))
            {
                // Документ не закрылся. Требуется его отменить (если это чек) и сформировать заново
                fptr.cancelReceipt();
                return;
            }

            if (!fptr.getParamBool(Constants.LIBFPTR_PARAM_DOCUMENT_PRINTED))
            {
                // Можно сразу вызвать метод допечатывания документа, он завершится с ошибкой, если это невозможно
                while (fptr.continuePrint() < 0)
                {
                    // Если не удалось допечатать документ - показать пользователю ошибку и попробовать еще раз.
                  //  Console.WriteLine(String.Format("Не удалось напечатать документ (Ошибка \"{0}\"). Устраните неполадку и повторите.", fptr.errorDescription()));
                    continue;
                }
            }

            // Запрос информации о закрытом чеке
            fptr.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_LAST_DOCUMENT);
            fptr.fnQueryData();
            Console.WriteLine(String.Format("Fiscal Sign = {0}", fptr.getParamString(Constants.LIBFPTR_PARAM_FISCAL_SIGN)));
            Console.WriteLine(String.Format("Fiscal Document Number = {0}", fptr.getParamInt(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER)));

            //// Формирование слипа ЕГАИС
            //fptr.beginNonfiscalDocument();

            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT, "ИНН: 111111111111 КПП: 222222222");
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.printText();

            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT, "КАССА: 1               СМЕНА: 11");
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.printText();

            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT, "ЧЕК: 314  ДАТА: 20.11.2017 15:39");
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.printText();

            //fptr.setParam(Constants.LIBFPTR_PARAM_BARCODE, "https://check.egais.ru?id=cf1b1096-3cbc-11e7-b3c1-9b018b2ba3f7");
            //fptr.setParam(Constants.LIBFPTR_PARAM_BARCODE_TYPE, Constants.LIBFPTR_BT_QR);
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.setParam(Constants.LIBFPTR_PARAM_SCALE, 5);
            //fptr.printBarcode();

            //fptr.printText();

            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT, "https://check.egais.ru?id=cf1b1096-3cbc-11e7-b3c1-9b018b2ba3f7");
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT_WRAP, Constants.LIBFPTR_TW_CHARS);
            //fptr.printText();

            //fptr.printText();

            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT,
            //        "10 58 1c 85 bb 80 99 84 40 b1 4f 35 8a 35 3f 7c " +
            //        "78 b0 0a ff cd 37 c1 8e ca 04 1c 7e e7 5d b4 85 " +
            //        "ff d2 d6 b2 8d 7f df 48 d2 5d 81 10 de 6a 05 c9 " +
            //        "81 74");
            //fptr.setParam(Constants.LIBFPTR_PARAM_ALIGNMENT, Constants.LIBFPTR_ALIGNMENT_CENTER);
            //fptr.setParam(Constants.LIBFPTR_PARAM_TEXT_WRAP, Constants.LIBFPTR_TW_WORDS);
            //fptr.printText();

            //fptr.endNonfiscalDocument();

            //// Отчет о закрытии смены
            //fptr.setParam(Constants.LIBFPTR_PARAM_REPORT_TYPE, Constants.LIBFPTR_RT_CLOSE_SHIFT);
            //fptr.report();

            // Получение информации о неотправленных документах
            fptr.setParam(Constants.LIBFPTR_PARAM_FN_DATA_TYPE, Constants.LIBFPTR_FNDT_OFD_EXCHANGE_STATUS);
            fptr.fnQueryData();
           // Console.WriteLine(String.Format("Unsent documents count = {0}", fptr.getParamInt(Constants.LIBFPTR_PARAM_DOCUMENTS_COUNT)));
           // Console.WriteLine(String.Format("First unsent document number = {0}", fptr.getParamInt(Constants.LIBFPTR_PARAM_DOCUMENT_NUMBER)));
          //  Console.WriteLine(String.Format("First unsent document date = {0}", (fptr.getParamDateTime(Constants.LIBFPTR_PARAM_DATE_TIME)).ToString("yyyy.MM.dd HH:mm:ss")));

            // Завершение работы
            fptr.close();
            
        
      }

       public string CloseCheks()
        {
            IFptr fptr = new Fptr();
            fptr.open(); // открытие файла.

            fptr.cancelReceipt();
          string  nomerErrot = fptr.errorCode().ToString();
          string  opisaniError = fptr.errorDescription();

            fptr.close(); // закрытие драйвера

            return $"Состояние операции. Номер ошибки {nomerErrot}| Описание ошибки{opisaniError}";
            fptr.close(); // закрытие драйвера
        }


        //Кнопка отмены чека
        private void Button9_Click(object sender, EventArgs e)
        {
            CloseCheks();
        }
    }

}

