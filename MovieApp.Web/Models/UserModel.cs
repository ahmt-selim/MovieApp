using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "UserName için 10 karakterden fazla olamaz")]
        [Remote(action: "VerifyUserName", controller:"User")]
        public string UserName { get; set; }
        [Required]
        //Aşağıdaki gibi kullanımlarda 0:Property ismi, 2:Max değer, 1:Min değer olarak kullanılır.
        [StringLength(25, ErrorMessage = "{0} karakter uzunluğu {2}-{1} arasında olmalıdır", MinimumLength =3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz")]
        [EmailProviders]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]//Password properttsi ile karşılaştırılır. Aynı değil ise hata verir.
        public string RePassword { get; set; }
        [Url]
        public string Url { get; set; }
        //[Range(1900,2010)]
        //public int BirthYear { get; set; }
        [BirthDate(ErrorMessage ="Doğum tarihiniz şimdiki ve sonraki tarih olamaz")]
        [DataType(DataType.Date)]
        [Display(Name="Birth Date")]
        public DateTime BirthDate{ get; set; }
    }
}
