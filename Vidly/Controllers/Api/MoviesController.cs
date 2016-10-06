using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        public IHttpActionResult GetMovies()
        {
           var movies = _context.Movies.Include(m => m.Genre).ToList();

            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/"+movie.Id), movie);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, Movie movie)
        {
            var movie2 = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie2 == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            movie2.name = movie.name;
            movie2.GenreId = movie.GenreId;
            movie2.DateAdded = movie.DateAdded;
            movie2.NumberInStock = movie.NumberInStock;
            movie2.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

            return Ok(movie2);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok(movie);
        }
    }
}
