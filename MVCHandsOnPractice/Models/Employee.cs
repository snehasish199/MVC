using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCHandsOnPractice.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [CustomValidationOnName]  //This is a Custom Validation
        public string Name { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        [Display(Name="Office Location")]
        public string Address { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}