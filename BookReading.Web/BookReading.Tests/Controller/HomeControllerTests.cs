using System;
using Xunit;
using Moq;
using BookReading.Business;
using BookReading.Model;
using BookReading.Web.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web.Security;

namespace BookReading.Tests.Controller
{
    public class HomeControllerTests
    {
        private readonly HomeController _sut;
        private readonly Mock<IBookReadingOperation> _mockBookReading;
        private readonly Mock<IEmailValidityCheck> _mockEmailValidityCheck;
        private readonly Mock<IInvitedUserOperation> _mockInvitedUserOperation;
        private readonly Mock<IMyEvents> _mockMyEvents;
        private readonly Mock<IInvitedEvents> _mockInvitedEvents;

        public HomeControllerTests()
        {
            
            _mockBookReading = new Mock<IBookReadingOperation>();
             _mockEmailValidityCheck = new Mock<IEmailValidityCheck>();
            _mockInvitedUserOperation = new Mock<IInvitedUserOperation>();
            _mockMyEvents = new Mock<IMyEvents>();
            _mockInvitedEvents = new Mock<IInvitedEvents>();
            _sut = new HomeController(_mockBookReading.Object
                                        , _mockEmailValidityCheck.Object
                                        , _mockInvitedUserOperation.Object
                                        , _mockMyEvents.Object
                                        , _mockInvitedEvents.Object);
        }
        [Fact]
        public void AllBookEventResult()
        {
           
            _mockBookReading.Setup(x => x.GetAllEvents()).Returns(new List<BookEvent> { });
           

            var Result = _sut.Index();

          var ViewResult=  Assert.IsType<ViewResult>(Result);

          var model=  Assert.IsType<List<BookEvent>>(ViewResult.Model);
            Assert.Equal(new List<BookEvent> { }, model);

            _mockBookReading.Verify(x => x.GetAllEvents(), Times.Once);
        }

        [Fact]
        public void ReturnWhenInvalidModelStateOnCreateEventMethod()
        {
            _sut.ModelState.AddModelError("x", "xyz");
            var bookEvent = new BookEvent
            {
                Id = 2,
                Title = "Second Event"
            };
           var result= _sut.CreateEvent(bookEvent);
           var viewResult= Assert.IsType<ViewResult>(result);
            var model= Assert.IsType<BookEvent>(viewResult.Model);
            Assert.Equal(bookEvent.Id, model.Id);
            Assert.Equal("", viewResult.ViewName);

        }

        [Fact]
        public void ReturnMyEvent()
        {

            
            _mockMyEvents.Setup(x => x.GetEvents(It.IsAny<string>())).Returns(new List<BookEvent> { });

          ActionResult Result= _sut.MyEvents();
           
           var viewResult= Assert.IsType<ViewResult>(Result);
            Assert.Equal("Index", viewResult.ViewName);
            Assert.Equal(new List<BookEvent> { }, viewResult.Model);
           
        }

        [Fact]
        public void ReturnAllInvitedEvent()
        {
            _mockInvitedUserOperation.Setup(x => x.GetAllBook(It.IsAny<string>())).Returns(new List<int> { });
            _mockInvitedEvents.Setup(x => x.GetAllInvitedEvents(It.IsAny<List<int>>())).Returns(new List<BookEvent> { });

            var Result = _sut.InvitedEvent();
             var viewResult=Assert.IsType<ViewResult>(Result);
            Assert.Equal(new List<BookEvent> { }, viewResult.Model);
        }

    }
}

