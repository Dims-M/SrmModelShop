using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DropDownMenu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Клиент"));
            menuRegister.Add(new SubItem("Услуги поставщиков"));
            menuRegister.Add(new SubItem("Работники"));
            menuRegister.Add(new SubItem("Товары"));

            var menuSchedule = new List<SubItem>();
            menuSchedule.Add(new SubItem("Сервисы"));
            menuSchedule.Add(new SubItem("Заметки"));
            var item1 = new ItemMenu("СРМ", menuSchedule, PackIconKind.Schedule);


            var menuReports = new List<SubItem>();
            menuReports.Add(new SubItem("Клиенты"));
            menuReports.Add(new SubItem("Поставщики"));
            menuReports.Add(new SubItem("Товары"));
            menuReports.Add(new SubItem("Запасы"));
            menuReports.Add(new SubItem("Продажи"));
            var item2 = new ItemMenu("Отчеты", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItem>();
            menuExpenses.Add(new SubItem("Постоянные"));
            menuExpenses.Add(new SubItem("Текущие"));
            var item3 = new ItemMenu("Расходы", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItem>();
            menuFinancial.Add(new SubItem("Движение средст"));
            var item4 = new ItemMenu("Финансы", menuFinancial, PackIconKind.ScaleBalance);


            var hrenPolnya = new List<SubItem>();
            hrenPolnya.Add(new SubItem("Хрень всякая"));
            var item7 = new ItemMenu("Хренотеень", hrenPolnya, PackIconKind.ScaleBalance);

            var ашптфPolnya = new List<SubItem>();
            hrenPolnya.Add(new SubItem("Фигня"));
            var item8 = new ItemMenu("Тест", ашптфPolnya, PackIconKind.ScaleBalance);

            var item0 = new ItemMenu("НСИ", new UserControl(), PackIconKind.ViewDashboard);

            Menu.Children.Add(new UserControlMenuItem(item0));
         //   Menu.Children.Add(new UserControlMenuItem(item6));
            Menu.Children.Add(new UserControlMenuItem(item1));
            Menu.Children.Add(new UserControlMenuItem(item2));
            Menu.Children.Add(new UserControlMenuItem(item3));
            Menu.Children.Add(new UserControlMenuItem(item4));
            Menu.Children.Add(new UserControlMenuItem(item7));
        }
    }
}
