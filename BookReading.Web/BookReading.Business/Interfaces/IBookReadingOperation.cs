using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReading.Model;

namespace BookReading.Business
{
    public interface IBookReadingOperation
    {
        int AddEvent(BookEvent book);
       List<BookEvent> GetAllEvents();
        List<BookEvent> GetAllEventsOfAUser(string userName);
        BookEvent GetEvent(int id);
        bool DeleteEvent(int id);
        bool UpdateEvent(BookEvent book);

        string GetAuthor(int id);
    }
}
