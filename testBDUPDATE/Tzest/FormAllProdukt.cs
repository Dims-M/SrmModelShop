using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Tzest
{
    public partial class FormAllProdukt : Form
    {
        private string dbFileName = @"C:\\BETRADE2\\btrade.db3";
        private SQLiteConnection DB;
        ApplicationContext db; //обьект для связи с БД. Через него получаем данные из бд

        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
      //  string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        string connectionString = @"Data Source=C:\\BETRADE2\\btrade.db3";
        string sql = "SELECT * FROM Catalog";

       // "Data Source=" + dbFileName + ";Version=3"

        public FormAllProdukt()
        {
            InitializeComponent();
            test1();
        }



        //При загрузке формы
        private void FormAllProdukt_Load(object sender, EventArgs e)
        {

        }

        //При закрытиии формы

        private void FormAllProdukt_FormClosing(object sender, FormClosingEventArgs e)
        {
            DB.Close();
        }

        //Кнопка закрыти
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void Test1()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                // делаем недоступным столбец id для изменения
                dataGridView1.Columns["Id"].ReadOnly = true;
            }
        }

        //НЕ РАБОТАЕТ
        public void test1()
        {
            //db = new ApplicationContext(); // новый обьект для связи
            //db.Catalogs.Load();
            //this.dataGridView1.DataSource = db.Catalogs.Local.ToBindingList(); // передаем данные из бд в 

            DB = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;");
            DB.Open();
            SQLiteCommand CMD = DB.CreateCommand(); // Создаем новую команды для обращения к БД
            CMD.CommandText = "SELECT * FROM  Catalog;";
            // CMD.ExecuteNonQuery();
            SQLiteDataReader SQL = CMD.ExecuteReader();

            if (SQL.HasRows) // набор записей из БД 
            {
                while (SQL.Read()) // чтение до конца набора
                {
                    //dataGridView1.DataSource = SQL[0];
                    var tenp = SQL.ToString();
                    dataGridView1.Rows.Add(tenp);

                }
            }
            else
            {
                // "записей нет";
            }
        }

    }
}