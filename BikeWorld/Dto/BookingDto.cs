using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeWorld.Dto
{
    public class BookingDto
    {
        public int CustomerId { get; set; }
        public List<int> BikeIds { get; set; }

    }
}