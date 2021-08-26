using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.MyDb
{
    public class UserDbOperation
    {
        public bool Add(UserModel model)
        {
           using(var context= new MVCPracticeEntities())
            {
                var NewUser = new User()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
                };
                context.User.Add(NewUser);
                context.SaveChanges();
                return true;
               
            }
        }

        public string Get(UserModel model)
        {
            using(var context=new MVCPracticeEntities())
            {
                var IsUserAvail = context.User.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (IsUserAvail == null)
                {
                    return null;
                }
                else
                {
                    return IsUserAvail.Name;
                }
            }
        }
    }
}