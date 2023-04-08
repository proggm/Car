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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Action(new Model.Car()));
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem = (Car)DataView.SelectedItem;
            if(selecteditem != null)
            {
                NavigationService.Navigate(new Action(selecteditem));
            }
        }

        private void Delbtn_Click(object sender, RoutedEventArgs e)
        {
            var selecteditem= (Car)DataView.SelectedItem;
            if(selecteditem !=null)
            {
                AppData.db.Car.Remove(selecteditem);
                AppData.db.SaveChanges();
                Page_Loaded(null, null);
                MessageBox.Show("Удаление завершенно" ,"Успешно!",MessageBoxButton.OK,MessageBoxImage.Information);
            }
        }

        private void Exitbtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataView.ItemsSource = AppData.db.Car.ToList();
        }

        private void txb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView.ItemsSource = AppData.db.Car.Where(item => item.ID.ToString().Contains(txb1.Text) ||item.Stamp.ToString().Contains(txb1.Text)).ToList();
        }
    }
}
