using CarWPF.Contex;
using CarWPF.Model;
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

namespace CarWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для Action.xaml
    /// </summary>
    public partial class Action : Page
    {
        public Car Car { get; set; }
        public Action( Car Car)
        {
            InitializeComponent();
            this.Car = Car;
            this.DataContext = this;
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
           if(Car.ID==0)
            {
                AppData.db.Car.Add(Car);
            }
            AppData.db.SaveChanges();
            MessageBox.Show("Добавление завершенно" ," Успешно!", MessageBoxButton.OK,MessageBoxImage.Information);
            NavigationService.GoBack();
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
