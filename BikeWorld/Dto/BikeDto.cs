﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BikeWorld.Dto
{
    public class BikeDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        // public descrp Descrp { get; set; }

        //[Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }
    }
}