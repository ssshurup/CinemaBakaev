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
    /// Логика взаимодействия для TicketUserP.xaml
    /// </summary>
    public partial class TicketUserP : Page
    {
        public TicketUserP()
        {
            InitializeComponent();
            ScheduleDG.ItemsSource = App.DB.tickets.Where(a => a.idUser == App.LoggedUser.id).ToList();
        }
        private void VKBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/estoylocooo") { UseShellExecute = true });
        }

        private void TgBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shizzzzoooo") { UseShellExecute = true });
        }
        private void LogOutBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }
        private void ClientBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }

        private void SellBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedTicket = ScheduleDG.ItemsSource as tickets;
            if(selectedTicket != null)
            {
                App.DB.tickets.Remove(selectedTicket);
                App.LoggedUser.balance += selectedTicket.schedule.priceTicket;
                App.DB.SaveChanges();
                MessageBox.Show("Билет возвращён");
            }
        }
    }
}
