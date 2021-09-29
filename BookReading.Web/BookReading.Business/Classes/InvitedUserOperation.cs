using BookReading.Data;
using BookReading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookReading.Business
{
   public class InvitedUserOperation : IInvitedUserOperation
    {
        private BookReadingDb db;
        private readonly IEmailValidityCheck _emailValidity;
        public InvitedUserOperation(IEmailValidityCheck emailValidity)
        {
            db = new BookReadingDb();
            _emailValidity = emailValidity;
        }
        public void AddInvitedUser(string invitedUser, int bookId)
        {
            string[] InvitedUserArr = invitedUser.Split(',');
            foreach(var user in InvitedUserArr)
            {
                 var modelObj = new InvitedUser()
                    {
                        Email = user,
                        BookId = bookId
                    };
                    db.InvitedUsers.Add(modelObj);
                    db.SaveChanges();
            }
      
            }
           

        

        public List<int> GetAllBook(string userName)
        {
            return db.InvitedUsers.Where(x => x.Email == userName).Select(x => x.BookId).ToList();
        }

        public void DeleteBook(int bookId)
        {
            db.InvitedUsers.RemoveRange(db.InvitedUsers.Where(x => x.BookId == bookId).ToList());
            db.SaveChanges();
        }



         public string IsInvitedUsersValid(string AllUser)
        {
            string[] InviteUserArr = AllUser.Split(',');
            foreach (var user in InviteUserArr)
            {
                if (!_emailValidity.isEmailValid(user))
                {
                    return user;
                }
            }
            return null;
        }

    }
}
