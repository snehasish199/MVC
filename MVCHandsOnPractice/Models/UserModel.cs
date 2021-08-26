using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCHandsOnPractice.Models
{
    public class UserModel
    {
       
        public string Name { get; set; }
        [Required]
       
        [EmailAddress(ErrorMessage ="Please Enter a valid email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}