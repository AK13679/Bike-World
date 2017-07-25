using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeWorld.Models;
using BikeWorld.ViewModels;

namespace BikeWorld.Controllers
{
    public class CustomerController : Controller
    {

        private BikeDBContext _context;

        public CustomerController()
        {
            _context = new BikeDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        [Route("Customers")]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBikes))
            {  //var viewModel = new CustomersViewModel();
                //var customers = _context.Customers.ToList();
                //var membershiptypes = _context.MembershipTypes.ToList();
                //var viewModel = new CustomersViewModel()
                //{
                //    Customers = customers,
                //    MembershipTypes = membershiptypes,

                //};
                return View("Index");
            }
            else
            {
                return View("ReadonlyIndex");
            }
        }

        [Route("New_Customer")]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            //var customer = new Customer
            //{
            //    Name = "ak",
            //     Dob = DateTime.Now,
            //    IsSubscribedToNewsletter = true,

            //};
            var viewModel = new NewCustomerViewModel
            {
               Customer = new Customer(),
               MembershipTypes = membershiptypes,
            };
         
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            

            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("New", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            { var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerinDb);
                customerinDb.Name = customer.Name;
                customerinDb.Dob = customer.Dob;
                customerinDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.mobno = customer.mobno;
                customerinDb.email = customer.email;
            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
           // var viewModel = new CustomersViewModel();
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
        };

            return View("New",viewModel);
        }

        [Route("customer/details/{Id:regex(\\d+)}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                return View(customer);
            }
            return HttpNotFound();
        }

    }
}