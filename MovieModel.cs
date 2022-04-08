using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovies
{
    public class MovieModel
    {
        public string imdbID { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public string Director { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public int Metascore { get; set; }
        public string BoxOffice { get; set; }
    }
}
