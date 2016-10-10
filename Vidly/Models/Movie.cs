using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

       [Required(ErrorMessage ="Insert name.")]
       [StringLength(255)]
        public String name { get; set; }
        public String ReleaseDate { get; set; }
        public String DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }
        public int Available { get; set; }
        public Genre Genre { get; set; }

        [Display(Name ="Genre")]
        public byte GenreId { get; set; }

    }
}