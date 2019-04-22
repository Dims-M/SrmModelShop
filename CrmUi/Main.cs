using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmBl;
using CrmBl.Model;

namespace CrmUi
{
    public partial class Main : Form
    {
        //связь с бд
        CrmContext db ;
       // CrmBl.Model.CrmContext

        public Main()
        {
            InitializeComponent(); // иницализация формы
            db = new CrmContext(); // создаем конкретный обьект
        }

        //при загрузке формы
        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        //обьект меню
        private void СущностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products); //загружаем данные из БД
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                var catalogSeller = new Catalog<Seller>(db.Sellers); //загружаем данные из БД
                catalogSeller.Show();
           
            
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers); //загружаем данные из БД
            catalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks); //загружаем данные из БД
            catalogCheck.Show();
        }
    }
}
