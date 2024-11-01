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
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) 
                || i.Description.ToLower().Contains(q.ToLower())).ToList();
            }
            var model = new MoviesViewModel()
            {
                Movies = movies
            };


            return View("Movies", model);//"Movies" ismindeki view çalışır ilk parametreden dolayı
        }
        //localhost:5000/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(MovieRepository.GetById(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Create(string Title, string Description, string Director, string ImageUrl, int genre_id) //Alternatif olarak bu şekilde de kullanılabilir.
        public IActionResult Create(Movie m)
        {
            //Model Binding

            //var m = new Movie()
            //{
            //    Title = Title,
            //    Description = Description,
            //    Director = Director,
            //    ImageUrl = ImageUrl,
            //    genre_id = genre_id
            //};

            MovieRepository.Add(m);
            //return RedirectToAction("Index", "Home"); //Bu şekilde 2. bir parametre tanımalandığı zaman Home controllerı altındaki index metoduna yönlendirilecektir.
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(MovieRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            MovieRepository.Edit(m);
            // /movies/details/1
            return RedirectToAction("Details", "Movies", new { @id = m.movie_id }); //Yönlendirdiğimiz details formu id parametresini istediği için burada bu şekilde ekleme yaptık.
        }
    }
}
