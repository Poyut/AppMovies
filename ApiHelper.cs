using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppMovies
{
    class ApiHelper
    {
        public static HttpClient ApiClient { get; set; } = new HttpClient();

        public static void InititalizeClient()
        {
            //http://www.omdbapi.com/?apikey=b4ef8f09&t&
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
