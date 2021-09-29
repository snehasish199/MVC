using BookReading.Data;
using BookReading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Business
{
    public class InvitedEvents : IInvitedEvents
    {
        private readonly BookReadingDb db;
        public InvitedEvents()
        {
            db = new BookReadingDb();
        }

        public List<BookEvent> GetAllInvitedEvents(List<int> allBookIdList)
        {
           
            List<BookEvent> InvitedEventList = new List<BookEvent>();
            foreach(var id in allBookIdList)
            {
                InvitedEventList.Add(db.BookEvents.FirstOrDefault(x => x.Id == id));


            }
            return InvitedEventList;

        }
    }
}
