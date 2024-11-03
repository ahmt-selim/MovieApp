using MovieApp.Web.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class HomePAgeViewModel
    {
        public List<Movie> PopularMovies { get; set; }
    }
}
