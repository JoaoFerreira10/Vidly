using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalsController : ApiController
    {

        public ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto RentalDto) {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == RentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Customer doesn't exit. "+ RentalDto);


            var movies = _context.Movies.Where(m => RentalDto.MoviesId.Contains(m.Id));
                
            foreach (var item in movies)
            {
                item.Available--;
                var rental = new Rental { Customer = customer, Movie = item, DateRented = DateTime.Now };
                _context.Rentals.Add(rental);            
            };

            _context.SaveChanges();

            return Ok();
        }
    }
}
