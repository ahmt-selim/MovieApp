using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context;
        public AdminController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Movielist()
        {
            return View(new AdminMoviesViewModel 
            {
                Movies = _context.Movies
                .Include(m=>m.Genres).Select(m=>new AdminMovieViewModel 
                {
                    MovieId=m.movie_id,
                    Title=m.Title,
                    ImageUrl=m.ImageUrl,
                    Genres=m.Genres.ToList()
                })
                .ToList()
            });
        }
    }
}
