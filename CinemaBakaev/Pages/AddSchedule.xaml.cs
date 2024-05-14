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
    /// Логика взаимодействия для AddSchedule.xaml
    /// </summary>
    public partial class AddSchedule : Page
    {
        schedule context;
        public AddSchedule()
        {
            InitializeComponent();
            ScheduleDP.SelectedDate = DateTime.Now;
            FilmCB.ItemsSource = App.DB.film.ToList();
            HallCB.ItemsSource = App.DB.hall.ToList();
            context = new schedule();
            DataContext = context;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedFilm = FilmCB.SelectedItem as film;
                context.idFilm = selectedFilm.id;

                var selectedHall = HallCB.SelectedItem as hall;
                context.idHall = selectedHall.id;

                context.dateSchedule = ScheduleDP.SelectedDate;
                App.DB.schedule.Add(context);
                App.DB.SaveChanges();
                NavigationService.Navigate(new SheduleListAdminP());
            }
            catch { }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SheduleListAdminP());
        }
    }
}
