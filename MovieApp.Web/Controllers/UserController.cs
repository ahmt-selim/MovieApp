using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MovieApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            
            return View();
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyUserName(string UserName)
        {
            var users = new List<string> { "ahmetselim", "mehmetturan" };
            if (users.Any(i => i == UserName))
            {
                return Json($"zaten {UserName} isimli kullanıcı adı daha önce alınmış.");
            }
            return Json(true);
        }
    }
}
