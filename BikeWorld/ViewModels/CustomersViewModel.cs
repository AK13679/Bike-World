using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeWorld.Models;

namespace BikeWorld.ViewModels
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        
    }
}