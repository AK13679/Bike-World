using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeWorld.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult New()
        {
            return View();
        }
    }
}