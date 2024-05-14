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
    /// Логика взаимодействия для ProfileP.xaml
    /// </summary>
    public partial class ProfileP : Page
    {
        users context;
        public ProfileP(users user)
        {
            InitializeComponent();
            context = user;
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

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientP());
        }
    }
}
