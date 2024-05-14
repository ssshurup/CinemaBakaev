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
    /// Логика взаимодействия для EditFilmP.xaml
    /// </summary>
    public partial class EditFilmP : Page
    {
        film context;
        public EditFilmP(film editedFilm)
        {
            InitializeComponent();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            DirectorCB.ItemsSource = App.DB.Director.ToList();
            CountryCB.ItemsSource = App.DB.country.ToList();
            context = editedFilm;
            DataContext = context;
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            if(context == null)
            {
                App.DB.film.Add(context);
            }
            App.DB.SaveChanges();
            NavigationService.Navigate(new AdminClientP());
        }
        private void BackBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new AdminClientP());
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
