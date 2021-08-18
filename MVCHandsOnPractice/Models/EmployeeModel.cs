using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCHandsOnPractice.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [CustomValidationOnName]  //This is a Custom Validation
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
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
        public int? AddressId { get; set; }
        public virtual AddressModel Address1 { get; set; }
    }
}