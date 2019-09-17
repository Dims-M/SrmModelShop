using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tzest
{
    /// <summary>
    /// Класс описывает строки в БД
    /// </summary>
   public class Catalog : INotifyPropertyChanged
    {
        private string fullName;
        private string alcCode;
        private double price;
        private string created;

        public int Id { get; set; }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string AlcCode
        {
            get { return alcCode; }
            set
            {
                alcCode = value;
                OnPropertyChanged("AlcCode");
            }
        }

        public string Created
        {
            get { return created; }
            set
            {
                created = value;
                OnPropertyChanged("created");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
