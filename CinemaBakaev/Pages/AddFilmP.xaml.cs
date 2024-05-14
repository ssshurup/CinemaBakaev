using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AddFilmP.xaml
    /// </summary>
    public partial class AddFilmP : Page
    {
        film context;
        public AddFilmP()
        {
            InitializeComponent();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            GenreCB.SelectedIndex = 0;
            DirectorCB.ItemsSource = App.DB.Director.ToList();
            DirectorCB.SelectedIndex = 0;
            CountryCB.ItemsSource = App.DB.country.ToList();
            CountryCB.SelectedIndex = 0;
            ReleaseDP.SelectedDate = DateTime.Now;
            context = new film();
            DataContext = context; 
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var addedPet = App.DB.film.Where(a => a.title == context.title);
                if (addedPet.Any())
                {
                    MessageBox.Show("This pet is already added");
                    return;
                }
                else
                {
                    var selectedGenre = GenreCB.SelectedItem as genre;
                    context.idGenre = selectedGenre.id;

                    var selectedDirector = DirectorCB.SelectedItem as Director;
                    context.idDirector = selectedDirector.id;

                    var selectedCountry = CountryCB.SelectedItem as country;
                    context.idCountry = selectedCountry.id;
                    context.releaseDate = ReleaseDP.SelectedDate;

                    if (context != null)
                    {
                        App.DB.film.Add(context);
                        App.DB.SaveChanges();
                        NavigationService.Navigate(new AdminClientP());
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminClientP());
        }
    }
}
