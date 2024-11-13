using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
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
        private readonly MovieContext _context;
        public MoviesController(MovieContext context)
        {
            _context = context;
        }
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

            //var movies = MovieRepository.Movies;//Db kullanmadan önceki yöntem
            var movies = _context.Movies.AsQueryable(); //AsQueryable _context üzerine ekstra sorgulae yükleyebieceğiz. Fitreleme işlemleri tamamlandıktan sonra En son ToList ile veri tabanına ilgili sorgu hazırlanıp gönderilir.
            if (id != null)
            {
                //Include ile moviesdeki tüm Genres bilgilerini çekip Any ile yukardan dönen genre id bilgisi ile eşleşen film var mı bulmak için bu şekilde bir yapı kullanıyoruz.
                movies = movies
                    .Include(m=> m.Genres)
                    .Where(m => m.Genres.Any(g =>g.genre_id == id));
            }
            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i => i.Title.ToLower().Contains(q.ToLower()) 
                || i.Description.ToLower().Contains(q.ToLower()));
            }
            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
            };


            return View("Movies", model);//"Movies" ismindeki view çalışır ilk parametreden dolayı
        }
        //localhost:5000/movies/details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            //return View(MovieRepository.GetById(id)); //Db kullanmadan önceki yöntem
            return View(_context.Movies.Find(id));
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Genres = new SelectList(GenreRepository.Genres, "genre_id", "Name"); //Db kullanmadan önceki yöntem
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genre_id", "Name");
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

            if (ModelState.IsValid)
            {
                //MovieRepository.Add(m);//Db kullanmadan önceki yöntem
                //return RedirectToAction("Index", "Home"); //Bu şekilde 2. bir parametre tanımalandığı zaman Home controllerı altındaki index metoduna yönlendirilecektir.
                _context.Movies.Add(m);
                _context.SaveChanges();

                TempData["Message"] = $"{m.Title} isimli film eklendi.";
                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genre_id", "Name");
            return View();
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genre_id", "Name");
            return View(_context.Movies.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                //MovieRepository.Edit(m);
                _context.Movies.Update(m);
                _context.SaveChanges();
                TempData["Message"] = $"{m.Title} isimli film güncelendi.";
                //return RedirectToAction("Index", "Home"); //Bu şekilde 2. bir parametre tanımalandığı zaman Home controllerı altındaki index metoduna yönlendirilecektir.
                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(_context.Genres.ToList(), "genre_id", "Name");
            // /movies/details/1
            return View(m);
        }
        [HttpPost]
        public IActionResult Delete(int movie_id, string Title)
        {
            //MovieRepository.Delete(movie_id);
            var entity = _context.Movies.Find(movie_id);
            _context.Movies.Remove(entity);
            _context.SaveChanges();
            TempData["Message"] = $"{Title} isimli film silindi.";//Burada delete işlmeinden sonra sayfa yönlendirmesi yaptığımız için ViewBag içindeki veri siliniyor. Bu yüzden TempData metodu ile veri taşıması yaptık
            return RedirectToAction("List");
        }
    }
}
