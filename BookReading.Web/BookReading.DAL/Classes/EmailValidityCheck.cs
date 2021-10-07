using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookReading.DAL
{
   public class EmailValidityCheck : IEmailValidityCheck
    {
        public bool isEmailValid(string email)
        {
           return  Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }
}
