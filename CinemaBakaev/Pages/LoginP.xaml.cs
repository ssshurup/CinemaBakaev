using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для LoginP.xaml
    /// </summary>
    public partial class LoginP : Page
    {
        users context;
        public LoginP()
        {
            InitializeComponent();
            context = new users();
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

        private void LogBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var tryLogin = App.DB.users.Where(a => a.login == context.login && a.password == context.password);
                if (tryLogin.Any())
                {
                    App.LoggedUser = tryLogin.First();
                    if(App.LoggedUser.idRole == 1) NavigationService.Navigate(new AdminClientP());
                    else if( App.LoggedUser.idRole == 2) NavigationService.Navigate(new ClientP());

                }
                else ExceptionTB.Visibility = Visibility.Visible;
            }
            catch
            {

            }
        }

   

        private void RegisterBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterP());
        }
    }
}
