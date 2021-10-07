
using BookReading.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.DAL
{
  public interface IInvitedEvents
    {
        List<BookEvent> GetAllInvitedEvents(List<int> allBookIdList);
    }
}
