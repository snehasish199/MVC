using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public interface IEmailValidityCheck
    {
        bool isEmailValid(string email);
    }
}
