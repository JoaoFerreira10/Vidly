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
    public class CustomersController : ApiController
    {

        public ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = _context.Customers.Include(m => m.MemberShipType).ToList();

            return Ok(customers);

        }
    }
}
