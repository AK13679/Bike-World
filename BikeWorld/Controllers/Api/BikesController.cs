using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikeWorld.Dto;
using BikeWorld.Models;

namespace BikeWorld.Controllers.Api
{
    public class BikesController : ApiController
    {
        private BikeDBContext _context;

        public BikesController()
        {
            _context = new BikeDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<BikeDto> GetBikes()
        {
            return _context.Bike.ToList().Select(Mapper.Map<Bike, BikeDto>);

        }

        public IHttpActionResult GetBike(int id)
        {
            var bike = _context.Bike.SingleOrDefault(c => c.Id == id);

            if (bike == null)
                return NotFound();

            return Ok(Mapper.Map<Bike, BikeDto>(bike));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public IHttpActionResult CreateBike(BikeDto bikeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bike = Mapper.Map<BikeDto, Bike>(bikeDto);

            _context.Bike.Add(bike);
            _context.SaveChanges();

            bikeDto.Id = bike.Id;

            return Created(new Uri(Request.RequestUri + "/" + bike.Id), bikeDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public void UpdateBike(int id, BikeDto bikeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var bikeinDb = _context.Bike.SingleOrDefault(c => c.Id == id);

            if (bikeinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(bikeDto, bikeinDb);

            //customerinDb.Name = customerDto.Name;
            //customerinDb.Dob = customerDto.Dob;
            //customerinDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerinDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerinDb.mobno = customerDto.mobno;
            //customerinDb.email = customerDto.email;

            _context.SaveChanges();

        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public void DeleteBike(int id)
        {
            var bikeinDb = _context.Bike.SingleOrDefault(c => c.Id == id);
            if (bikeinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Bike.Remove(bikeinDb);
            _context.SaveChanges();
        }

    }
}
