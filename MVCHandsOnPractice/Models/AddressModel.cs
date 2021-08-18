using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCHandsOnPractice.MyDb;

namespace MVCHandsOnPractice.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }
        public string Details { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PinCode { get; set; }

    }
}