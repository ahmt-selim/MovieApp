using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string filmBasligi = "film başlığı";
            string filmAciklama = "filmin açıklaması";
            string filmYonetmen = "filmin yönetmen adı";
            string[] oyuncular = { "oyuncu 1", "oyuncu 2", "oyuncu 3", "oyuncu 4" };

            //ViewBag.FilmBasligi = filmBasligi;
            //ViewBag.FilmAciklamasi = filmAciklama;
            //ViewBag.FilmYonetmeni = filmYonetmen;
            //ViewBag.Oyuncular = oyuncular;

            var m = new Movie();
            m.Tilte = filmBasligi;
            m.Description = filmAciklama;
            m.Director = filmYonetmen;
            m.Cast = oyuncular;

            return View(m);
        }
        //public string Index()
        //{
        //    return "Anasayfa";
        //}
        public IActionResult About()
        {
            return View();
        }
    }
}
