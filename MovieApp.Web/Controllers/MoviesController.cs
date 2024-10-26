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
        public IActionResult List()
        {

            var model = new MoviesViewModel()
            {
                Movies = MovieRepository.Movies
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
