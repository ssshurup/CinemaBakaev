using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CinemaBakaev.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBalanceP.xaml
    /// </summary>
    public partial class AddBalanceP : Page
    {
        users context;
        public AddBalanceP()
        {
            InitializeComponent();
            context = App.LoggedUser;
            DataContext = context;
        }
        public static int TBbalance = new int(); 
        private void AddBalanceBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TBbalance = Convert.ToInt32(SumTB.Text);
                context.balance += TBbalance;
            }
            catch
            {
                MessageBox.Show("Неверно введена сумма");
            }
            if(context == null)
            {
                App.DB.users.Add(context);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new ClientP());
        }
        private void VKBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/estoylocooo") { UseShellExecute = true });
        }

        private void TgBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shizzzzoooo") { UseShellExecute = true });
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }
    }
}
