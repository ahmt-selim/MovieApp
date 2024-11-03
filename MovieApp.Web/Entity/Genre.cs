using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Entity
{
    public class Genre
    {
        [Key]
        public int genre_id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
