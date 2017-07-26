using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BikeWorld.Dto;
using System.Data.Entity;
using BikeWorld.Models;

namespace BikeWorld.Controllers.Api
{
    public class BookingController : ApiController
    {


        private BikeDBContext _context;

        public BookingController()
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

            var bikes = _context.Bike.Where(m => Bookingdto.BikeIds.Contains(m.Id));

            foreach (var bike in bikes)
            {
                if (bike.NoAvailable == 0)
                    return BadRequest("Bike is not available now.");
                bike.NoAvailable--;

                var booking = new Booking
                {
                    Customer = customers,
                    Bike = bike,
                    DateRented = DateTime.Now

                };

                _context.Booking.Add(booking);
               
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
