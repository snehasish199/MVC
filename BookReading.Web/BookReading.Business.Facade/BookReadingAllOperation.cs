using BookReading.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business.Facade
{
    public class BookReadingAllOperation : IBookReadingAllOperation
    {

        private readonly IBookReadingOperation _bookReading;
        private readonly IEmailValidityCheck _emailValidity;
        private readonly IInvitedUserOperation _invitedUser;
        private readonly IUserOperation _user;
        private readonly IMyEvents _myEvents;
        private readonly IInvitedEvents _invitedEvent;
        private readonly IUserRoleOperation _userRole;

        public BookReadingAllOperation(IBookReadingOperation bookReading
            , IEmailValidityCheck emailValidity
            , IInvitedUserOperation invitedUser
            , IUserOperation user
            , IMyEvents myEvents
            , IInvitedEvents invitedEvent
            , IUserRoleOperation userRole

           )
        {
            _bookReading = bookReading;
            _emailValidity = emailValidity;
            _invitedUser = invitedUser;
            _user = user;
            _myEvents = myEvents;
            _invitedEvent = invitedEvent;
            _userRole = userRole;

        }


        public int AddEvent(BookEvent book)
        {
            return _bookReading.AddEvent(book);
        }

        public void AddInvitedUser(string InvitedUserArr, int BookId)
        {
            _invitedUser.AddInvitedUser(InvitedUserArr, BookId);
        }

        public bool AddUSer(User user)
        {
            return _user.AddUSer(user);
        }

        public void DeleteBook(int bookId)
        {
            _invitedUser.DeleteBook(bookId);
        }

        public bool DeleteEvent(int id)
        {
            return _bookReading.DeleteEvent(id);
        }

        public bool DeleteUser(string userName)
        {
            return _user.DeleteUser(userName);
        }

        public List<int> GetAllBook(string userName)
        {
            return _invitedUser.GetAllBook(userName);
        }

        public List<BookEvent> GetAllEvents()
        {
            return _bookReading.GetAllEvents();
        }

        public List<BookEvent> GetAllEventsOfAUser(string userName)
        {
            return _bookReading.GetAllEventsOfAUser(userName);
        }

        public List<BookEvent> GetAllInvitedEvents(List<int> allBookIdList)
        {
            return _invitedEvent.GetAllInvitedEvents(allBookIdList);
        }

        public string GetAuthor(int id)
        {
            return _bookReading.GetAuthor(id);
        }

        public BookEvent GetEvent(int id)
        {
            return _bookReading.GetEvent(id);
        }

        public List<BookEvent> GetEvents(string userName)
        {
            return _myEvents.GetEvents(userName);
        }

        public string[] GetRole(int userId)
        {
            return _userRole.GetRole(userId);
        }

        public int GetUSerId(string userName)
        {
            return _user.GetUSerId(userName);
        }

        public bool IsEmailValid(string email)
        {
            return _emailValidity.isEmailValid(email);
        }

        public string IsInvitedUsersValid(string AllUser)
        {
            return _invitedUser.IsInvitedUsersValid(AllUser);
        }

        public bool IsValidUser(string userName, string password)
        {
            return _user.IsValidUser(userName, password);
        }

        public void SetRole(UserRole userRole)
        {
            _userRole.SetRole(userRole);
        }

        public bool UpdateEvent(BookEvent book)
        {
            return _bookReading.UpdateEvent(book);
        }

        public bool UpdateUser(User user)
        {
            return _user.UpdateUser(user);
        }
    }
}
