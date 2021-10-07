using BookReading.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business.Facade
{
    public interface IBookReadingAllOperation
    {


        int AddEvent(BookEvent book);
        List<BookEvent> GetAllEvents();
        List<BookEvent> GetAllEventsOfAUser(string userName);
        BookEvent GetEvent(int id);
        bool DeleteEvent(int id);
        bool UpdateEvent(BookEvent book);

        string GetAuthor(int id);


        //--------------------------------------------------------------

        bool IsEmailValid(string email);
        //---------------------------------------------------------------

        List<BookEvent> GetAllInvitedEvents(List<int> allBookIdList);
        //--------------------------------------------------------------
        void AddInvitedUser(string InvitedUserArr, int BookId);
        string IsInvitedUsersValid(string AllUser);

        List<int> GetAllBook(string userName);
        void DeleteBook(int bookId);
        //-----------------------------------------------------------------
        List<BookEvent> GetEvents(string userName);
        //---------------------------------------------------------------

        bool AddUSer(User user);
        bool IsValidUser(string userName, string password);
        bool UpdateUser(User user);
        bool DeleteUser(string userName);
        int GetUSerId(string userName);
        //---------------------------------------------------------

        string[] GetRole(int userId);
        void SetRole(UserRole userRole);
    }
}
