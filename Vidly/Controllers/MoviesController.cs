using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [System.Runtime.InteropServices.Guid("DB0CE0CC-63D6-4391-A638-5FD7AE116FA5")]
    public class MoviesController : Controller
    {

        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {

            //var customers = new List<Customer>
            //{
            //    new Customer() { Name = "Joao" },
            //    new Customer() { Name = "Zé" }
            //};

            //var rmvm = new RandomMovieViewModel() { Movie = movies() };

            var movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);
            return View(movie);
        }

        [Authorize]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movies = new NewMovieViewModel
            {
                Movie = new Movie(),
                Genre = genres
            };

            return View("Form", movies);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genre = _context.Genres.ToList()
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var movie2 = new NewMovieViewModel
                {
                    Movie = movie,
                    Genre = _context.Genres.ToList()
                };

                return View("Form", movie2);
            }

            //new movie
            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else//update movie
            {
                var moviedb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);

                moviedb.name = movie.name;
                moviedb.GenreId = movie.GenreId;
                moviedb.DateAdded = movie.DateAdded;
                moviedb.NumberInStock = movie.NumberInStock;
                moviedb.ReleaseDate = movie.ReleaseDate;

            }
            

            try
            {
             _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }


            return RedirectToAction("Index", "Movies");
        }

        [Route("movies/release/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }
   
    }
}