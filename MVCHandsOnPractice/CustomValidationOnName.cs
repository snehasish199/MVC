using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCHandsOnPractice
{
    public class CustomValidationOnName : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var Name = value.ToString();
                if (Name.Length < 3)
                {
                    return new ValidationResult("Name should contain atleast 3 characters");
                }
                else if (Name.Length > 50)
                {
                    return new ValidationResult("Name should contain maximum 50 characters");

                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Something error occur");
        }
    }
}