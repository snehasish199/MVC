
using BookReading.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.DAL
{
    public interface IUserRoleOperation
    {
        string[] GetRole(int userId);
        void SetRole(UserRole userRole);
    }
}
