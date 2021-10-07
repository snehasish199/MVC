using BookReading.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace BookReading.DAL
{
   public class BookReadingOperation:IBookReadingOperation
    {
        private  BookReadingDb _db;
        private IInvitedUserOperation _InvitedUser;


        public BookReadingOperation(IInvitedUserOperation invitedUser)
        {
            _db = new BookReadingDb();
            _InvitedUser = invitedUser;
        }

        public int AddEvent(BookEvent book)
        {
            try
            {
                
                _db.BookEvents.Add(book);
               _db.SaveChanges();
                return book.Id;
               
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public bool DeleteEvent(int id)
        {
            try
            {
                //db.BookEvents.Remove(GetEvent(id));
                _InvitedUser.DeleteBook(id);
                _db.Entry(GetEvent(id)).State = System.Data.Entity.EntityState.Deleted;
                _db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
         
        }

        public List<BookEvent> GetAllEvents()
        {

            return _db.BookEvents.OrderByDescending(x => x.Date).ToList();
        }

        public List<BookEvent> GetAllEventsOfAUser(string userName)
        {
            return _db.BookEvents.Where(x => x.Author == userName).ToList();
        }

        public string GetAuthor(int id)
        {
            return _db.BookEvents.Where(x => x.Id == id).Select(x => x.Author).FirstOrDefault();
        }

        public BookEvent GetEvent(int id)
        {
            return _db.BookEvents.FirstOrDefault(x => x.Id == id);
        }

        public bool UpdateEvent(BookEvent bookEvent)
        {
           
                _db.Entry(bookEvent).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            
            
        }
    }
}
