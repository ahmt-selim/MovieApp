using MovieApp.Web.Entity;
using MovieApp.Web.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Models
{
    public class AdminMoviesViewModel
    {
        public List<AdminMovieViewModel> Movies { get; set; }
    }
    public class AdminMovieViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public List<Genre> Genres { get; set; }
    }
    public class AdminEditMovieViewModel
    {
        public int MovieId { get; set; }
        [Display(Name = "Film Adı")]
        [Required(ErrorMessage = "Film adı girmelisiniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Film adı için 3-50 karakter girmelisiniz.")]
        public string Title { get; set; }
        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage = "Film açıklaması girmelisiniz.")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklaması için 10-3000 karakter girmelisiniz.")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "En az bir tür bilgisi seçmelisiniz.")]
        public int[] GenreIds { get; set; }
    }
    public class AdminCreateMovieModel
    {
        [Display(Name ="Film Adı")]
        [Required(ErrorMessage ="Film adı girmelisiniz.")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Film adı için 3-50 karakter girmelisiniz.")]
        public string Title { get; set; }
        [Display(Name = "Film Açıklama")]
        [Required(ErrorMessage = "Film açıklaması girmelisiniz.")]
        [StringLength(3000, MinimumLength = 10, ErrorMessage = "Film açıklaması için 10-3000 karakter girmelisiniz.")]
        public string Description { get; set; }
        public bool IsClassic { get; set; }
        public int[] GenreIds { get; set; }
        [ClassicMovie(1950)]//1950 ve üstü değer girildiğinde classic film false olması gerekiyor.
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
    }
}
