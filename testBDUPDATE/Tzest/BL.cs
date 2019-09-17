using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Tzest
{
    public class BL
    {
        /// <summary>
        /// Путь к базе
        /// </summary>
        private string dbFileName = @"C:\\BETRADE2\\btrade.db3";
        /// <summary>
        /// Строка подключения
        /// </summary>
        private SQLiteConnection m_dbConn;
        /// <summary>
        /// Строка для команды обращения к БД
        /// </summary>
        private SQLiteCommand m_sqlCmd;

        string returnVolue = "Соединение не установленно!!\t\n";
        /// <summary>
        /// Подсоединение к БД
        /// </summary>
        public string ConnectBD()
        {
            m_dbConn = new SQLiteConnection(); // обьекты для работы с БД
            m_sqlCmd = new SQLiteCommand();

            //  dbFileName = @"C:\\BETRADE2\\btrade.db3";

            //проверяем существует ли бд
            if (!File.Exists(dbFileName))
            {
                returnVolue += "База данных не найдена \t\n";
            }

            else
            {
                try
                {
                    m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                    m_dbConn.Open(); // открываем соединение к бд
                    m_sqlCmd.Connection = m_dbConn; // обьект для передачи комнд в БД


                    //SELECT COUNT(*) FROM Catalog 
                    returnVolue = "Соединение Установленно.";

                }
                catch (Exception ex)
                {
                    returnVolue += $"ОШИБКА!!! \t\n{ex}";
                }
            }
            ReadBd(); // Запуск соединения к БД
            return returnVolue;
        }

        /// <summary>
        /// Метод для чтения данных из Бд
        /// </summary>
        public string ReadBd()
        {
            //ConnectBD(); // запускаем подклбчение к БД

            //  string returnVolue = "Соединение не установленно!!\t\n";
            string sqlQuery; //строка для запросов в бд
            var dTable = new DataTable(); // обьект для хранения таблиц в памяти.
            string tempCountBd = "";
            int countVolue = 0;
            int countAllTovarov = 0;
            string temp = "";

            if (!File.Exists(dbFileName))
            {
                // tempCountBd =
                //    // MessageBox.Show("Please, create DB and blank table (Push \"Create\" button)");
                returnVolue += "Ошибка отрытия БД в методе";

            }

            else
            {
                // проверить наличие связи с БД:
                if (m_dbConn.State != ConnectionState.Open)
                {
                    returnVolue += "Открытие соединение с базой данных";
                    // MessageBox.Show("Открыть соединение с базой данных");
                    //return;
                }

                ///SELECT COUNT(*) FROM Catalog;
                // UPDATE Catalog SET AlcCode = (AlcCode = "1") WHERE FullName LIKE '%Пиво%';
                // SELECT* FROM Catalog WHERE  FullName LIKE '%Пиво%';

                try
                {
                    //UPDATE Catalog SET AlcCode = (AlcCode = "0") WHERE  FullName LIKE '%Пиво%';
                    // string getAllTovar =$"SELECT * FROM Catalog WHERE \"FullName\" LIKE '%Пиво%' OR \"FullName\" LIKE '%ПИПО%'  OR \"FullName\" LIKE '%Пивной%';";
                    string getAllTovar = $"SELECT COUNT(*)FROM Catalog WHERE \"FullName\" LIKE '%Пиво%' OR \"FullName\" LIKE '%ПИПО%'  OR \"FullName\" LIKE '%Пивной%';";
                    string getAllKod = $"SELECT COUNT(*) FROM Catalog WHERE FullName LIKE '%Пиво%' AND AlcCode >0;";

                    sqlQuery = "SELECT COUNT(*) FROM Catalog"; // сам sql запрос к БДы
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(getAllTovar, m_dbConn); // adapter обьект для выполнения запросов и отправка команды на сервер
                                                                                              // var command = new SQLiteCommand("Data Source=" + dbFileName + ";Version=3;");

                    // получение  списка всех товаров
                    var command = new SQLiteCommand(m_dbConn);
                    command.CommandText = "SELECT COUNT(*) FROM Catalog"; // получение  списка всех товаров
                    command.CommandType = CommandType.Text;

                    countVolue = Convert.ToInt32(command.ExecuteScalar());

                    //Попытка получить все алкогольные товары
                    command = new SQLiteCommand(m_dbConn);
                    // command.Parameters.AddWithValue("@value", "Новое имя файла");
                    //command.Parameters.AddWithValue("@id", 1); // присваиваем переменной номер (id) записи, которую будем обновлять
                    command.CommandText = getAllKod; // отправляем текстовой запрос
                    command.CommandType = CommandType.Text;

                    countAllTovarov = Convert.ToInt32(command.ExecuteScalar());

                    //https://metanit.com/sharp/adonet/3.1.php
                    // Заполняем Dataset
                    adapter.Fill(dTable); //  обновление 
                    // 

                    if (dTable.Rows.Count > 0)
                    {

                        // tempCountBd= dTable.s  Rows.Count.ToString(); // получаем количествой строк
                        // dTable.Rows.Clear();


                        for (int i = 0; i < dTable.Rows.Count; i++)
                        {
                            countVolue += dTable.Rows.Count; // попытка подсчета количества строк в Бд
                        }
                        // dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
                    }
                    else
                    {
                        // MessageBox.Show("Database is empty");
                    }


                }
                catch (SQLiteException ex)
                {
                    returnVolue += "Ошибка при запросе к БД: " + ex;
                }
            }

            returnVolue += $"\t\n Общие Количество товаров в БД: = {countVolue} \t\n Алкогольных товаров:{countAllTovarov}";

            return countVolue.ToString();
        }

        /// <summary>
        /// Смена алкогольного атрибута
        /// </summary>
        public string SetAllAlkoAtribut()
        {
            string baseName = dbFileName;
            string tempZnachTest = "";

            using (var connection = new SQLiteConnection())
            {

                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                SQLiteCommand cmd = new SQLiteCommand();
                cmd.CommandText = "UPDATE Catalog SET AlcCode = (AlcCode = 1) WHERE  FullName LIKE '%Пиво%';";
                cmd.Connection = connection;
                // cmd.Parameters.Add(new SQLiteParameter("@ID_Cart", listBox1.SelectedValue));
                // cmd.Parameters.Add(new SQLiteParameter("@Kollvo_Cart", numericUpDown1.Text));

                tempZnachTest = cmd.ExecuteNonQuery().ToString();
                connection.Close();

                #region Не рабочий код
                //if (!File.Exists(dbFileName))
                //{
                //    returnVolue += "Ошибка отрытия БД в методе SetAllAlkoAtribut";
                //    return;
                //}
                // m_dbConn = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                // m_dbConn.Open(); // открываем соединение к бд
                // проверить наличие связи с БД:
                //if (m_dbConn.State != ConnectionState.Open)
                //{
                //    returnVolue += "Открытие соединение с базой данных";

                //}

                //   try

                //https://metanit.com/sharp/adonet/2.5.php
                //  {   //UPDATE Catalog SET AlcCode = (AlcCode = "0") WHERE  FullName LIKE '%Пиво%';
                //  sqlQuery = "UPDATE Catalog SET AlcCode = (AlcCode = \"0\") WHERE  FullName LIKE '%Пиво%';";

                //  string baseName = "Printers.db3";

                //using (var connection = new SQLiteConnection())
                //{
                //    connection.ConnectionString = dbFileName;
                //    connection.Open();
                //    SQLiteCommand sqlite_cmd = new SQLiteCommand(sqlQuery, connection);
                //   // sqlite_cmd.Parameters.AddWithValue("@id_Cart", (sender as ListBox).SelectedValue);
                //    sqlite_cmd.ExecuteNonQuery();
                //    connection.Close();
                //}

                // получение  списка всех товаров
                //var command = new SQLiteCommand(m_dbConn);
                //command.CommandText = sqlQuery; // 
                //command.CommandType = CommandType.Text;

                //   AddDataToDb addData = new AddDataToDb();

                //  if (addData.ShowDialog() == DialogResult.OK)


                // m_sqlCmd.CommandText = sqlQuery; // нужный нам запрос к sqllite
                // m_sqlCmd.CommandText = "INSERT INTO Catalog ('author', 'book') values ('" +
                //    addData.Author + "' , '" +
                //  addData.Book + "')";

                //  m_sqlCmd.ExecuteNonQuery();


                //using (SqlConnection connection = new SqlConnection("Data Source=" + @"C:\\BETRADE2\\btrade.db3" + ";Version=3;")
                //{
                //    connection.Open();
                //    SqlCommand command = new SqlCommand(sqlQuery, connection);
                //    int number = command.ExecuteNonQuery();
                //    Console.WriteLine("Добавлено объектов: {0}", number);
                //}

                //@"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True"
                //  SqlConnection connection = new SqlConnection("Data Source=" + @"C:\\BETRADE2\\btrade.db3"); // подключение к базе.
                //  connection.Open(); // открытие соединения
                // SqlCommand command = new SqlCommand(sqlQuery, connection);

                // number = command.ExecuteNonQuery();
                //  int number = command.ExecuteNonQuery();

                //SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection); // обьект для работы с БД
                // DataSet ds = new DataSet(); // обьект хранит в себе "слепок бд"
                // adapter.Fill(ds); // применяем  

                // создаем объект SqlCommandBuilder
                // SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                // adapter.Update(ds);

                // commandBuilder.GetUpdateCommand();
                //  returnVolue += $"После обновления база товаров Битрейда {number}";
                //  }
                //catch (Exception ex)
                //{
                //    returnVolue += $"Произошла ошибка при работе с запросами к БД!!! \t\n{ex}";
                //}

                //  return returnVolue;
                #endregion

                return tempZnachTest;
            }
        }

        /// <summary>
        /// Получение всех товаров
        /// </summary>
        public void GetAllProductString()
        {
            string baseName = dbFileName; // путь к базе данных 
            string tempZnachTest = "";

            using (var connection = new SQLiteConnection())
            {

                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

                SQLiteCommand cmd = new SQLiteCommand(); // 
                                                         //  cmd.CommandText = "UPDATE Catalog SET AlcCode = (AlcCode = 1) WHERE  FullName LIKE '%Пиво%';"; //пример реализации
                cmd.CommandText = "SELECT * FROM Catalog;";
                cmd.Connection = connection;

                tempZnachTest = cmd.ExecuteNonQuery().ToString();
                connection.Close();
            }

        }
        public void GetAllProductAdapter()
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=C:\BETRADE2; Version=3;"))
            {
                Connect.Open();
                SQLiteCommand Command = new SQLiteCommand
                {
                    Connection = Connect,
                    CommandText = @"SELECT * FROM [dbTableName] WHERE [image_format] NOT NULL" // выборка записей с заполненной ячейкой формата изображения, можно другой запрос составить
                };
                SQLiteDataReader sqlReader = Command.ExecuteReader();


                //    DataTable dTable = new DataTable();
                //    DataTable dTable1 = new DataTable();
                //    string baseName = dbFileName; // путь к базе данных
                //    string connectionString = "Data Source = " + dbFileName;
                //    string sql = "SELECT * FROM Catalog;"; //  нужный запрос

                //  //  private SQLiteConnection m_dbConn = new SQLiteConnection();
                // SQLiteConnection m_dbConn2;
                //SQLiteCommand m_sqlCmd1 = new SQLiteCommand();

                //    m_dbConn2 = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
                //    m_dbConn2.Open(); // открываем соединение к бд
                //    m_sqlCmd.Connection = m_dbConn2; // обьект для передачи комнд в БД

                //    string qlQuery = "SELECT * FROM Catalog";
                //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, m_dbConn);
                //    adapter.Fill(dTable);

                //    return dTable;
                //if (dTable.Rows.Count > 0)
                //{
                //    // dgvViewer.Rows.Clear();

                //    for (int i = 0; i < dTable.Rows.Count; i++)
                //        // dgvViewer.Rows.Add(dTable.Rows[i].ItemArray);
                //        // dTable1.a = dTable.Rows[i].ItemArray;
                //}

                //using (var connection = new SQLiteConnection())
                //{

                //    connection.ConnectionString = "Data Source = " + baseName;
                //    connection.Open();

                //    SQLiteCommand cmd = new SQLiteCommand();
                //    cmd.CommandText = "UPDATE Catalog SET AlcCode = (AlcCode = 1) WHERE  FullName LIKE '%Пиво%';";
                //    cmd.Connection = connection;
                //    cmd.Parameters.Add(new SQLiteParameter("@ID_Cart", listBox1.SelectedValue));
                //    cmd.Parameters.Add(new SQLiteParameter("@Kollvo_Cart", numericUpDown1.Text));

                //    tempZnachTest = cmd.ExecuteNonQuery().ToString();
                //    connection.Close();
                //}

                //    using (SqlConnection connection = new SqlConnection(connectionString))
                //{
                //    connection.Open();
                //    // Создаем объект DataAdapter
                //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                //    // Создаем объект Dataset
                //    DataSet ds = new DataSet();
                //    // Заполняем Dataset
                //    adapter.Fill(ds);
                //    // Отображаем данные
                //    // dataGridView1.DataSource = ds.Tables[0];
                //    return ds.Tables[0]; // отправляем таблицу
                //}

            }

        }
     }
    
}
