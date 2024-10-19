using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class Movie
    {
        public string Tilte { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Cast { get; set; }
        public string ImageUrl { get; set; }
    }
}
