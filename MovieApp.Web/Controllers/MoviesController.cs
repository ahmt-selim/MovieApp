using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
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
        //localhost:5000/movies/details/
        //localhost:5000/movies/details/1
        public IActionResult List(int? id, string q)
        {
            //{conreoller}/{action}/{id?}
            //movies/list/2

            var contoller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            var genreid = RouteData.Values["id"];

            //var kelime = HttpContext.Request.Query["q"].ToString();

            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.genre_id == id).ToList();
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Tilte.ToLower().Contains(q.ToLower()) 
                || i.Description.ToLower().Contains(q.ToLower())).ToList();
            }
            var model = new MoviesViewModel()
            {
                Movies = movies
            };


            return View("Movies", model);
        }
        //localhost:5000/movies/details/1
        public IActionResult Details(int id)
        {

            return View(MovieRepository.GetById(id));
        }
    }
}
