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
    /// Логика взаимодействия для SheduleListAdminP.xaml
    /// </summary>
    public partial class SheduleListAdminP : Page
    {
        public SheduleListAdminP()
        {
            InitializeComponent();
            ScheduleDG.ItemsSource = App.DB.schedule.ToList();
        }
        private void DropBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = ScheduleDG.SelectedItem as schedule;
            if (selectedSchedule != null)
            {
                App.DB.schedule.Remove(selectedSchedule);
                App.DB.SaveChanges();
                ScheduleDG.ItemsSource = App.DB.schedule.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void LogOutBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }
        private void VKBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/estoylocooo") { UseShellExecute = true });
        }
        private void TgBT_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shizzzzoooo") { UseShellExecute = true });
        }
        private void ScheduleListBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new AdminClientP());
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedSchedule = ScheduleDG.SelectedItem as schedule;
            if (selectedSchedule != null)
            {
                NavigationService.Navigate(new EditSheduleP(selectedSchedule));
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void AddScheduleBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSchedule());
        }
    }
}
