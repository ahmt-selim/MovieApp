﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Web.Validators
{
    public class EmailProvidersAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = "";
            if (value != null)
            {
                email = value.ToString();
            }
            if (!email.EndsWith("@gmail.com") && !email.EndsWith("@hotmail.com"))
            {
                return new ValidationResult("Hatalı eposta sunucusu.(gmail veya hotmail olmalıdır.)");
            }
            return ValidationResult.Success;
        }
    }
}
