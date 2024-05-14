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
    /// Логика взаимодействия для RegisterP.xaml
    /// </summary>
    public partial class RegisterP : Page
    {
        users context;
        static public bool RegLogExept = true;
        static public bool RegPasExept = false;
        public RegisterP()
        {
            InitializeComponent();
            context = new users();
            DataContext = context;
        }
        private void RegBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var regData = App.DB.users.Where(a => a.login == context.login);
                if (regData.Any())
                {
                    ExceptionTB.Visibility = Visibility.Visible;
                    return;
                }

                context.idRole = 2;
                App.DB.users.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new LoginP());
            }
            catch
            {
                ExceptionTB.Visibility = Visibility.Visible;
            }
        }
        private void TgBT_Click(object sender, object e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shizzzzoooo") { UseShellExecute = true });
        }
        private void VKBT_Click(object sender, object e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/estoylocooo") { UseShellExecute = true });
        }
        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginP());
        }
    }
}
