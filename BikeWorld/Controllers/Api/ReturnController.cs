using System;
using System.Linq;
using System.Web.Http;
using BikeWorld.Dto;
using BikeWorld.Models;

namespace BikeWorld.Controllers.Api
{
    public class ReturnController : ApiController
    {

        private BikeDBContext _context;

        public ReturnController()
        {
            _context = new BikeDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateBooking(BookingDto Bookingdto)
        {
            // throw new NotImplementedException();
            var customers = _context.Customers.Single(c => c.Id == Bookingdto.CustomerId);


            //important

            var bikes = _context.Bike.Where(b => Bookingdto.BikeIds.Contains(b.Id));

            foreach (var bike in bikes)
            {
                if (bike.NoAvailable == bike.NumberInStock)
                  return BadRequest("All bikes are returned.");
               
                        bike.NoAvailable++;

                        var Return = new Return
                        {
                            Customer = customers,
                            Bike = bike,
                            DateRented = DateTime.Now

                        };

                        _context.Return.Add(Return);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
