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
    /// Логика взаимодействия для ClientP.xaml
    /// </summary>
    public partial class ClientP : Page
    {
        film context;
        public ClientP()
        {
            InitializeComponent();
            ScheduleDG.ItemsSource = App.DB.schedule.ToList();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            context = new film();
            DataContext = context;
        }

      
        private void VKBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/estoylocooo") { UseShellExecute = true });
        }

        private void TgBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shizzzzoooo") { UseShellExecute = true });
        }
        private void TitleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            ScheduleDG.ItemsSource = App.DB.schedule.Where(a => a.film.title.Contains(TitleTB.Text)).ToList();
        }
        private void LogOutBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }

        private void ProfileBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfileP(App.LoggedUser));
        }

        private void BalanceBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBalanceP());
        }


        private void BuyTicketBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = ScheduleDG.SelectedItem as schedule;
            if (selectedSchedule != null)
            {
                if (App.LoggedUser.balance >= selectedSchedule.priceTicket)
                {
                    tickets ticket = new tickets();
                    ticket.idSchedule = selectedSchedule.id;
                    ticket.idUser = App.LoggedUser.id;
                    App.LoggedUser.balance -= selectedSchedule.priceTicket;
                    App.DB.tickets.Add(ticket);
                    App.DB.SaveChanges();
                    MessageBox.Show("Билет куплен");
                }
                else MessageBox.Show("Недостаточно средств");
            }
            else MessageBox.Show("Выберите сеанс");
        }

        private void TicketsBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TicketUserP());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGenre = GenreCB.SelectedItem as genre;
            
            ScheduleDG.ItemsSource = App.DB.schedule.Where(a => a.film.idGenre == selectedGenre.id).ToList();
        }

        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }
    }
}
