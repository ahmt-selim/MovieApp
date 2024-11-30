using Microsoft.AspNetCore.Mvc;
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
        public IActionResult MovieList()
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
        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.movie_id,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
                SelectedGenres =m.Genres
            }).FirstOrDefault(m=>m.MovieId==id);

            ViewBag.Genres = _context.Genres.ToList();
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model, int[] genreIds)//Buraya yazılan parametre adı viewdeki name ile aynı olmalı.
        {
            var entity = _context.Movies.Include("Genres").FirstOrDefault(m=>m.movie_id==model.MovieId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;
            entity.Genres = genreIds.Select(id => _context.Genres.FirstOrDefault(i => i.genre_id == id)).ToList();
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
        public IActionResult Genrelist()
        {

            return View(new AdminGenresViewModel
            {
                Genres = _context.Genres.Select(g => new AdminGenreViewModel
                {
                    GenreId = g.genre_id,
                    Name = g.Name,
                    Count = g.Movies.Count
                }).ToList()
            });
        }
        public IActionResult GenreUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = _context
                .Genres
                .Select(g=> new AdminGenreEditViewModel
                {
                    GenreId = g.genre_id,
                    Name = g.Name,
                    Movies = g.Movies.Select(i=> new AdminMovieViewModel
                    {
                        MovieId=i.movie_id,
                        Title = i.Title,
                        ImageUrl = i.ImageUrl
                    }).ToList()
                }).FirstOrDefault(g => g.GenreId == id);

            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [HttpPost]
        public IActionResult GenreUpdate(AdminGenreEditViewModel model, int[] movieIds)
        {
            var entity = _context.Genres.Include("Movies").FirstOrDefault(i => i.genre_id == model.GenreId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            foreach (var id in movieIds)
            {
                entity.Movies.Remove(entity.Movies.FirstOrDefault(m => m.movie_id == id));
            }
            _context.SaveChanges();
            return RedirectToAction("GenreList");
        }
        [HttpPost]
        public IActionResult GenreDelete(int genreId)
        {
            var entity = _context.Genres.Find(genreId);
            if (entity != null)
            {
                _context.Genres.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("GenreList");
        }
        [HttpPost]
        public IActionResult MovieDelete(int movieId)
        {
            var entity = _context.Movies.Find(movieId);
            if (entity != null)
            {
                _context.Movies.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction("MovieList");
        }
        public IActionResult MovieCreate()
        {
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult MovieCreate(AdminCreateMovieModel model, int[] genreIds)
        {
            if (ModelState.IsValid)
            {
                var entity = new Movie
                {
                    Title = model.Title,
                    Description = model.Description,
                    ImageUrl = "no-image.png"
                };
                foreach (var id in genreIds)
                {
                    entity.Genres.Add(_context.Genres.FirstOrDefault(i => i.genre_id == id));
                }
                _context.Movies.Add(entity);
                _context.SaveChanges();
                return RedirectToAction("MovieList", "Admin");
            }
            ViewBag.Genres = _context.Genres.ToList();
            return View();
        }
    }
}
