using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BikeWorld.Models;
using BikeWorld.Dto;

namespace BikeWorld.Models
{
    public class Min18years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.Dob == null)
            {
                return new ValidationResult("Birth date is Required!");
            }
            else
            {
                //calculate age 
                var age = DateTime.Now.Year - customer.Dob.Value.Year;
                return (age >= 18) ? ValidationResult.Success : new ValidationResult("You should be 18 year or more !");
            }

        }
    }
}