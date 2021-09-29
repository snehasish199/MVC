using BookReading.Data;
using BookReading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public class MyEvents : IMyEvents
    {
        private BookReadingDb db;
        public MyEvents()
        {
            db = new BookReadingDb();
        }


        public List<BookEvent> GetEvents(string userName)
        {
           return db.BookEvents.Where(x => x.Author == userName).ToList();
        }
    }
}
