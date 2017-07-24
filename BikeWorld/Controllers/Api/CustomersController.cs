using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikeWorld.Dto;
using BikeWorld.Models;
using System.Data.Entity;

namespace BikeWorld.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private BikeDBContext _context;

        public CustomersController()
        {
            _context = new BikeDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c=> c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>);

        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerinDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto,customerinDb);

            //customerinDb.Name = customerDto.Name;
            //customerinDb.Dob = customerDto.Dob;
            //customerinDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerinDb.MembershipTypeId = customerDto.MembershipTypeId;
            //customerinDb.mobno = customerDto.mobno;
            //customerinDb.email = customerDto.email;

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerinDb);
            _context.SaveChanges();
        }
    }
}
