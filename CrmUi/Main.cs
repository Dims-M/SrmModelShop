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
            InitializeComponent();
            db = new CrmContext(); // создаем конкретный обьект
        }

        //при загрузке формы
        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        //обьект меню
        private void СущностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog();
        }
    }
}
