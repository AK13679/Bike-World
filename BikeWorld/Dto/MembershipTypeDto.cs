using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BikeWorld.Dto
{
    public class MembershipTypeDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public byte Id { get; set; }
    }
}