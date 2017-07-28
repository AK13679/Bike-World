using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeWorld.Models
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        // public descrp Descrp { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Display(Name = "Available")]
        public int NoAvailable { get; set; }
    }
}