using Microsoft.Azure.Cosmos;
using System.Net;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace AppMovies
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string EndpointUrl = "https://appmovies.documents.azure.com:443/";
        private const string AuthorizationKey = "UEnvTs9yOBCpx03MVQAub60FSTcn0dJhsaJKP2eb2kVeVSvNADP7dxgtgBC9GGtB0OQeh3wIvE6rUd5pQ4DKJQ==";
        private const string DatabaseId = "UserListMovies";
        private const string ContainerId = "SamuelDastous";
        // OPEN CONNEXION (I don't know if it's ok like this, maybe the connection stay open until the program stop and it's a vulnerability)
        CosmosClient cosmosClient = new CosmosClient(EndpointUrl, AuthorizationKey);

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
            imdbIDTxt.Text = movie.imdbID;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
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
                    if(searchTxt.Text == "Movie title...")
                        searchTxt.Text = "";
                    break;
                case 2:
                    if (searchYear.Text == "Movie year...")
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
        //---------- EVENTS HANDLERS ----------//
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
                try
                {
                    await LoadMovieData(searchTxt.Text, searchYear.Text);
                }
                catch
                {
                    MessageBox.Show("There is an error in the movie title or in the released year");
                }
            }
        }
        private async void searchYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                try
                {
                    await LoadMovieData(searchTxt.Text, searchYear.Text);
                }
                catch
                {
                    MessageBox.Show("There is an error in the movie title or in the released year");
                }
            }
        }
        private async void addToListBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await AddItemsToContainerAsync(cosmosClient);
            }
            catch(CosmosException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task AddItemsToContainerAsync(CosmosClient cosmosClient)
        {
            // Create a movie object
            Movie movie = new Movie
            {
                id = imdbIDTxt.Text,
                title = titleTxt.Text,
                Rate = rateTxt.Text,
                Description = apreciationTxt.Text,
            };

            Container container = cosmosClient.GetContainer(MainWindow.DatabaseId, MainWindow.ContainerId);
            Console.WriteLine(movie);
            try
            {
                // Read the item to see if it exists.  
                ItemResponse<Movie> MovieListResponse = await container.ReadItemAsync<Movie>(movie.id, new PartitionKey(movie.title));
                MessageBox.Show("You already have this movie in your list");
                //Console.WriteLine("Item in database with id: {0} already exists\n", MovieListResponse.Value.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Create an item in the container representing the Andersen family. Note we provide the value of the partition key for this item, which is "Andersen"
                ItemResponse<Movie> MovieListResponse = await container.CreateItemAsync<Movie>(movie, new PartitionKey(movie.title));

                // Note that after creating the item, we can access the body of the item with the Resource property off the ItemResponse.
                //Console.WriteLine("Created item in database with id: {0}\n", andersenFamilyResponse.Value.Id);
            }
        }
    }
}
