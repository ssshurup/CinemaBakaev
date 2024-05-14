using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для AdminClientP.xaml
    /// </summary>
    public partial class AdminClientP : Page
    {
        public AdminClientP()
        {
            InitializeComponent();
            GenreCB.ItemsSource = App.DB.genre.ToList();
            FilmDG.ItemsSource = App.DB.film.ToList();
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddFilmP());

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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedGenre = GenreCB.SelectedItem as genre;
            int idGenre = selectedGenre.id;
            FilmDG.ItemsSource = App.DB.film.Where(a => a.idGenre == idGenre).ToList();

        }
        private void DropBT_Click(object sender, object e)
        {
            var selectedFilm = FilmDG.SelectedItem as film;
            if (selectedFilm != null)
            {
                App.DB.film.Remove(selectedFilm);
                App.DB.SaveChanges();
                FilmDG.ItemsSource = App.DB.film.ToList();
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilm = FilmDG.SelectedItem as film;
            if (selectedFilm != null)
            {
                NavigationService.Navigate(new EditFilmP(selectedFilm));
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void TitleTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilmDG.ItemsSource = App.DB.film.Where(a => a.title.Contains(TitleTB.Text)).ToList() ;
        }
        private void AboutBT_Click(object sender, RoutedEventArgs e)
        {
            var selectedFilm = FilmDG.SelectedItem as film;
            
            if (selectedFilm != null)
            {
                DateTime dateFilm = (DateTime)selectedFilm.releaseDate;
                MessageBox.Show("Название: " + selectedFilm.title + "\nСтрана: " + selectedFilm.country.name + "\nЖанр: " + selectedFilm.genre.name + "\nРежжисёр: " + selectedFilm.Director.name + "\nОписание: " + selectedFilm.description + "\nРелиз: " + dateFilm.ToString("yyyyг. dd MMMM"));
            }
            else MessageBox.Show("Выберите что-то");
        }
        private void ClearBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminClientP());
        }
        private void AddSessionBT_Click(object sender, object e)
        {
            NavigationService.Navigate(new AddSchedule());
        }

        private void ScheduleListBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SheduleListAdminP());

        }
    }
}
