using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeWorld.Models;

namespace BikeWorld.ViewModels
{
    public class BikesViewModel
    {
        public List<Bike> Bike;
        public Bike Bikes { get; set; }
       // public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}