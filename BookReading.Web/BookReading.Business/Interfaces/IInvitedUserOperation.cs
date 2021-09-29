using BookReading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public interface IInvitedUserOperation
    {
      void AddInvitedUser(string InvitedUserArr, int BookId);
       string  IsInvitedUsersValid(string AllUser);

        List<int> GetAllBook(string userName);
        void DeleteBook(int bookId);
    }
}
