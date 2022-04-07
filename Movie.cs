using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppMovies
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        public string Title { get; set; }
        public string Rate { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
