using System;
using Xunit;
using Moq;
using BookReading.Business;
using BookReading.Model;
using BookReading.Web.Controllers;
using System.Web.Mvc;

namespace BookReading.Test.Controller
{
   public class HomeControllerShould
    {
        [Fact]
        public void AllBookEventResult()
        {
            var mockBookReading = new Mock<IBookReadingOperation>();

            mockBookReading.Setup(x => x.GetAllEvents()).Returns(new System.Collections.Generic.List<BookEvent> { });
            var mockEmailValidityCheck = new Mock<IEmailValidityCheck>();
            var mockInvitedUserOperation = new Mock<IInvitedUserOperation>();
            var mockMyEvents = new Mock<IMyEvents>();
            var mockInvitedEvents = new Mock<IInvitedEvents>();
           // mockBookReading.SetupAllProperties();

            var sut = new HomeController(mockBookReading.Object, mockEmailValidityCheck.Object, mockInvitedUserOperation.Object, mockMyEvents.Object, mockInvitedEvents.Object);

            var Result = sut.Index();
            Assert.IsType<ViewResult>(Result);
        }
            
        
    }
}
