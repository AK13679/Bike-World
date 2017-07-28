using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeWorld.Controllers
{
    public class ReturnController : Controller
    {
        // GET: Booking
        [Route("Return")]
        public ActionResult New()
        {
            return View();
        }
    }
}