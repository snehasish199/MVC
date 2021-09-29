using BookReading.Data;
using BookReading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public class UserRoleOperation : IUserRoleOperation
    {
        private readonly BookReadingDb db;
        public UserRoleOperation()
        {
            db = new BookReadingDb();
        }
        public string[] GetRole(int userId)
        {
           return db.UserRoles.Where(x => x.UserId == userId).Select(x=>x.Role).ToArray();
        }

        public void SetRole(UserRole userRole)
        {
            db.UserRoles.Add(userRole);
            db.SaveChanges();
        }
    }
}
