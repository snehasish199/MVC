using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FactoryDesignPattern.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Dept { get; set; }

        public int Salary { get; set; }
        public int Bonus { get; set; }
        [Required]
        [Display(Name = "Employee Type")]
        public string EmployeeType { get; set; }
    }
}