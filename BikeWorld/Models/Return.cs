using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeWorld.Models
{
    public class Return
    {
        public int Id { get; set; }

        //[Required]
        //[StringLength(255)]
        //public string Name { get; set; }
        //// public descrp Descrp { get; set; }\
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Bike Bike { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }
    }
}