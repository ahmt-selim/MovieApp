using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        //localhost:5000/movies
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            var filmListesi = new List<Movie>()
            {
                new Movie { Tilte = "Film 1", Description = "Açıklama 1", Director = "Yönetmen 1", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "1.jpg"},
                new Movie { Tilte = "Film 2", Description = "Açıklama 2", Director = "Yönetmen 2", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "2.jpg" }, 
                new Movie { Tilte = "Film 3", Description = "Açıklama 3", Director = "Yönetmen 3", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "3.jpg" },
                new Movie { Tilte = "Film 4", Description = "Açıklama 4", Director = "Yönetmen 4", Cast = new string[] { "oyuncu 1", "oyuncu 2" },ImageUrl = "4.jpg" }
            };
            return View("Movies", filmListesi);
        }
        //localhost:5000/movies/details
        public string Details()
        {
            return "Film Detayı";
        }
    }
}
