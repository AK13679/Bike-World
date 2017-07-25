using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeWorld.Models;
using BikeWorld.ViewModels;

namespace BikeWorld.Controllers
{
    public class BikeController : Controller
    {

        private BikeDBContext _context;

        public BikeController()
        {
            _context = new BikeDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("Bikes")]
        public ViewResult Index()
        {
            //var viewModel = new BikesViewModel();
            //viewModel.Bike = _context.Bike.ToList();
            //return View(viewModel);
            if (User.IsInRole(RoleName.CanManageBikes))
            
                return View("Index");
           
            return View("ReadonlyIndex");
        }

        [Route("Bike/details/{id}")]
        public ActionResult Details(int id)
        {
            var bike = _context.Bike.SingleOrDefault(c => c.Id == id);

            if (bike != null)
            {
                return View(bike);
            }

            return HttpNotFound();
        }


        // GET: Bikes
        //public ActionResult Random()
        //{
        //    var bike = new Bike() { Name = "Harley" };
        //    var customers = new List<Customer>
        //    {
        //      new Customer(){  Name = "Abhi" },
        //        new Customer(){ Name = "Ashish" },
        //    };

        //    var viewModel = new RandomBikeViewModel
        //    {
        //        Bike = bike,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}

        [Route("New_Bike")]
        [Authorize(Roles = RoleName.CanManageBikes)] //overide global authorization
        public ActionResult New()
        {
            
            var viewModel = new NewBikeViewModel()
            {
                Bike = new Bike(),
               
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Bike bike)
        {


            if (!ModelState.IsValid)
            {
                var viewModel = new NewBikeViewModel
                {
                    Bike = bike
                   
                };

                return View("New", viewModel);
            }

            if (bike.Id == 0)
            {
                _context.Bike.Add(bike);
            }
            else
            {
                var bikeinDb = _context.Bike.Single(c => c.Id == bike.Id);
                //TryUpdateModel(customerinDb);
                bikeinDb.Name = bike.Name;
                bikeinDb.NumberInStock = bike.NumberInStock;
               
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Bike");
        }

      
        [Authorize(Roles = RoleName.CanManageBikes)]
        public ActionResult Edit(int Id)
        {
            // var viewModel = new CustomersViewModel();
            var bike = _context.Bike.SingleOrDefault(c => c.Id == Id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewBikeViewModel
            {
                Bike = bike
               
            };

            return View("New", viewModel);
        }


    }
}