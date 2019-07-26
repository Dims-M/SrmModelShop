using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;

namespace ConsoleApp2
{
    class Program
    {
        //Источник
        //https://developers.google.com/sheets/api/quickstart/dotnet
        //Install-Package Google.Apis.Sheets.v4

        // При изменении этих областей удалите ранее сохраненные учетные данные
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        static void Main(string[] args)
        {
            test2();
        }

        public static void test2()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                                Scopes,
                                "user",
                                CancellationToken.None,
                                new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Файл учетных данных, сохраненный: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
           //String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            String spreadsheetId = "1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo";
          //  String range = "Class Data!A2:E";
            String range = "A2:E";

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo/edit#gid=0
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;



            //    if (values == null && values.Count < 0)

            //  {
            //if (values != null && values.Count > 0)
            //{
            //   // values.Add();
            //}
            var tempList = new List<string>();
            Console.WriteLine("Содержимое таблицы");

                foreach (var row in values)
                {

                //if (values != null && values.Count > 0)

                //if (row[1] == null)
                //{
                //    row[1] = "Незаданно!", ;
                //    Console.WriteLine("Ошибка массива!!!!!");
                //    row[1] = "Незаданно!";
                //}
                //     row.Insert(values.Count+1,tempList);
                //   // row[2] = "незаданно";

                // Print columns A and E, which correspond to indices 0 and 4.
                // Console.WriteLine("Организация: {0}, № телефона: {1}, пароль:{2}", row[0], row[1], row[2]);

                if (row[1] == null || string.IsNullOrEmpty(Convert.ToString(row[1])))
                {
                    row[1] = 0;
                }

                //  user?.Phone?.Company?.Name ?? "не установлено";
               string temppp = row[1].ToString()??"незаданно";
                // onsole.WriteLine($"Организация: {row[0]},№ телефона: {row[1].ToString() ?? "незаданно"}");

              // Console.WriteLine($"Организация: {row[0]});//,№ телефона: {row[1].ToString() ?? "незаданно"}");
                Console.WriteLine(temppp);
               // FirstOrDefault

                }
            //}

            //else
            //{
                Console.WriteLine("No data found.");
            //}
            Console.Read();

        }


        //НЕ работает
        public void test1()
        {
            //Аутентифицировать:
            SpreadsheetsService myService = new SpreadsheetsService("https://docs.google.com/spreadsheets/d/1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo/edit#gid=0");
            myService.setUserCredentials("jo@gmail.com", "mypassword");

            //Получить список электронных таблиц:
            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = myService.Query(query);

            Console.WriteLine("Ваша таблица: ");
            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                Console.WriteLine(entry.Title.Text);
            }


        }


    }

}
