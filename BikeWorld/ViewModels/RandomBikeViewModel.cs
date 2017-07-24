using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeWorld.Models;

namespace BikeWorld.ViewModels
{
    public class RandomBikeViewModel

    {
        public Bike Bike { get; set; }
        public List<Customer> Customers { get; set; }
    }
}