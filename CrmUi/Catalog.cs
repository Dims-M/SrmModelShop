using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class Catalog : Form
    {
        public Catalog()
        {
            InitializeComponent();
        }

        //Конструктор. При загрузке формы выводим необходиммые данные
        public Catalog(DbSet db)
        {
           // dataGridView.DataBindings = db.Local.ToBindingList()
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }
    }
}
