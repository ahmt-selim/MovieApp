using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class Movie
    {
        public int movie_id { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Cast { get; set; }
        public string ImageUrl { get; set; }
        public int genre_id { get; set; }
    }
}
