
using BookReading.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.DAL
{
    public class UserOperation : IUserOperation
    {
        private BookReadingDb db;
        public UserOperation()
        {
            db = new BookReadingDb();
        }
        public bool AddUSer(User user)
        {
            try
            {
                if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
                {
                    return false;
                }
                db.Users.Add(user);
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool DeleteUser(string userName)
        {
            db.Users.Remove(db.Users.FirstOrDefault(x => x.Email == userName));
            return true;
        }

        public int GetUSerId(string userName)
        {
            return db.Users.Where(x => x.Email == userName).Select(x=>x.Id).FirstOrDefault();
        }

        public bool IsValidUser(string userName, string password)
        {
            try
            {
                var record=db.Users.FirstOrDefault(x => x.Email == userName && x.Password == password);
                if(record is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            return true;
        }
    }
}
