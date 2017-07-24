using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BikeWorld.Models; 

namespace BikeWorld.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

       // [Min18years]
      //  [Display(Name = "Date of Birth")]
        public DateTime? Dob { get; set; }

      //  [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Required]
        [StringLength(255)]
      //  [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
       // [Display(Name = "Mobile No.")]
        public string mobno { get; set; }
    }
}