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

namespace AppMovies
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InititalizeClient();
        }

        private async Task LoadMovieData(string movieTitle, string movieYear)
        {
            if (movieYear == "Movie year...")
                movieYear = "";

            var movie = await MovieProcessor.LoadMovie(movieTitle,movieYear);

            // Replace all appropriate textbox text with the right infos
            var uriSource = new Uri(movie.Poster, UriKind.Absolute);
            moviePoster.Source = new BitmapImage(uriSource);
            titleTxt.Text = movie.Title;
            releasedTxt.Text = movie.Released;
            directorTxt.Text = movie.Director;
            awardsTxt.Text = movie.Awards;
            metascoreTxt.Text = (movie.Metascore.ToString()+"/100");
            boxOfficeTxt.Text = movie.BoxOffice;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //ISSUE if movie title is not perfectly writed
            try
            {
                await LoadMovieData(searchTxt.Text,searchYear.Text);
            }
            catch
            {
                MessageBox.Show("There is an error in the movie title or in the released year");
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadMovieData("apocalypse+now","1979");
        }

        public void RemoveText(int position)
        {
            switch (position)
            {
                case 1:
                    searchTxt.Text = "";
                    break;
                case 2:
                    searchYear.Text = "";
                    break;
            }
        }
        public void AddText(int position)
        {
            switch(position)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(searchTxt.Text))
                        searchTxt.Text = "Movie title...";
                    break;
                case 2:
                    if (string.IsNullOrWhiteSpace(searchYear.Text))
                        searchYear.Text = "Movie year...";
                    break;

            }
        }
        //---------- EVENT HANDLER ----------//
        private void searchTxt_GotFocus(object sender, RoutedEventArgs e)
        {
            RemoveText(1);
        }

        private void searchTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            AddText(1);
        }

        private void searchYear_GotFocus(object sender, RoutedEventArgs e)
        {
            RemoveText(2);
        }

        private void searchYear_LostFocus(object sender, RoutedEventArgs e)
        {
            AddText(2);
        }

        private async void searchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                await LoadMovieData(searchTxt.Text,searchYear.Text);
            }
        }
        private async void searchYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                await LoadMovieData(searchTxt.Text, searchYear.Text);
            }
        }
    }
}
