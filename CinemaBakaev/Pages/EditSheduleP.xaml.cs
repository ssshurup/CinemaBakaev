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

namespace CinemaBakaev.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditSheduleP.xaml
    /// </summary>
    public partial class EditSheduleP : Page
    {
        schedule context;
        public EditSheduleP(schedule editedSchedule)
        {
            InitializeComponent();
            context = editedSchedule;
            DataContext = context;

        }
        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
                if (context != null)
                {
                    App.DB.schedule.Add(context);
                }
                App.DB.SaveChanges();
                NavigationService.Navigate(new SheduleListAdminP());
            }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SheduleListAdminP());

        }
    }
}
