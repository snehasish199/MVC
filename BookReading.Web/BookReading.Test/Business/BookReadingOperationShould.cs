using System;

using Xunit;
using Moq;
using BookReading.Business;
using BookReading.Data;
using BookReading.Model;

namespace BookReading.Test.Business
{
    public class BookReadingOperationShould
    {
        [Fact]
        public void AddBook()
        {

            var MockDb = new Mock<BookReadingDb>();
            var MockInviteUser = new Mock<IInvitedUserOperation>();
            //MockDb.SetupAllProperties();
           
           
            MockDb.Setup(x => x.BookEvents.Add(It.IsAny<BookEvent>())).Returns(new BookEvent());
            MockDb.Setup(x => x.SaveChanges()).Returns(1);

            var sut = new BookReadingOperation(MockInviteUser.Object);

            var BookEvent = new BookEvent
            {
                Title = "This is my first demo",
                StartTime = DateTime.Now.ToLocalTime(),
                Date = DateTime.Now.Date,
                Type="public",
                Duration=2

            };
           
            var id = sut.AddEvent(BookEvent);
            Assert.IsType<int>(id);
        }
    }
}
