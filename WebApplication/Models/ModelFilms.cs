using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ModelFilms
    {
        public int IdFilm { get; set; }
        public string NameFilm { get; set; }
        public string Country { get; set; }
        public int ReleaseYear { get; set; }
        public string ImageFilm { get; set; }

        public ModelFilms(Films film)
        {
            IdFilm = film.IdFilm;
            NameFilm = film.NameFilm;
            Country = film.Country;
            ReleaseYear = film.ReleaseYear;
            ImageFilm = film.ImageFilm;
        }
    }
}