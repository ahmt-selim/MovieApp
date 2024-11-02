using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class Movie
    {
        public int movie_id { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage ="Film başlığı eklemelisiniz.")]
        [StringLength(50,MinimumLength =5,ErrorMessage ="Fil başlığı 5 ile 50 karakter arasında olmalıdır.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Film açıklamsı boş olamaz.")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public string Director { get; set; }
        public string[] Cast { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public int? genre_id { get; set; }
    }
}
