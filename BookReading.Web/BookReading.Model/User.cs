using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookReading.Model
{
   public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [EmailAddress]
       public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
