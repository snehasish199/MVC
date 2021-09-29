using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReading.Model;

namespace BookReading.Business
{
   public interface IUserOperation
    {
        bool AddUSer(User user);
       bool IsValidUser(string userName, string password);
        bool UpdateUser(User user);
        bool DeleteUser(string userName);
        int GetUSerId(string userName);

    }
}
