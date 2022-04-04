using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppMovies
{
    class MovieProcessor
    {
        public static async Task<MovieModel> LoadMovie(string movieTitle, string movieYear)
        {
            string url = "";
            url = "http://www.omdbapi.com/?apikey=b4ef8f09&t="+movieTitle+"&y="+movieYear;
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    MovieModel movie = await response.Content.ReadAsAsync<MovieModel>();
                    return movie;
                }
                else
                {
                    Console.WriteLine("dosen't exist");
                    throw new Exception(response.ReasonPhrase);
                    //return null;
                }
            }
        }
    }
}
