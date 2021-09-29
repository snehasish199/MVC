using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReading.Business;
using BookReading.Model;


namespace BookReading.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBookReadingOperation _bookReading;
        private readonly IEmailValidityCheck _emailValidity;
        private readonly IInvitedUserOperation _invitedUser;
       
        private readonly IMyEvents _myEvents;
        private readonly IInvitedEvents _invitedEvent;
       
        public HomeController(IBookReadingOperation bookReading
            , IEmailValidityCheck emailValidity
            , IInvitedUserOperation invitedUser
            
            ,IMyEvents myEvents
            ,IInvitedEvents invitedEvent
           )
        {
            _bookReading = bookReading;
            _emailValidity = emailValidity;
            _invitedUser = invitedUser;
            
            _myEvents = myEvents;
            _invitedEvent = invitedEvent;
          
        }

        public HomeController()
        {
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var AllEvent = _bookReading.GetAllEvents().Where(x => x.Type == "public").ToList();
             return View(AllEvent);
            
        }
        public ActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEvent(BookEvent model)
        {
            if (ModelState.IsValid)
            {
                if (_invitedUser.IsInvitedUsersValid(model.InvitedUSer) != null)
                {
                    ViewBag.error =_invitedUser.IsInvitedUsersValid(model.InvitedUSer) + " is a wrong Email id .";
                    return View(model);
                }
                model.TotalInvitedUser = model.InvitedUSer.Split(',').Length;
                model.Author = User.Identity.Name;
                int BookId = _bookReading.AddEvent(model);
               
                _invitedUser.AddInvitedUser(model.InvitedUSer, BookId);
               
                return RedirectToAction("Index");
            }
            return View(model);
        }
       
        public ActionResult Edit(int id)
        {
            if (_bookReading.GetAuthor(id) == User.Identity.Name)
            {
                var UpdatingModel = _bookReading.GetEvent(id);

                return View(UpdatingModel);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(BookEvent bookEvent)
        {
            if (_bookReading.GetAuthor(bookEvent.Id) == User.Identity.Name || User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    _bookReading.UpdateEvent(bookEvent);
                    return RedirectToAction("Index");
                }
                return View(bookEvent);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {

            return View(_bookReading.GetEvent(id));
        }
      
        public ActionResult Delete(int id)
        {
            if(User.Identity.Name==_bookReading.GetAuthor(id)|| User.IsInRole("Admin"))
            {
                _bookReading.DeleteEvent(id);
                _invitedUser.DeleteBook(id);
            }
            return RedirectToAction("Index");
        }

    
        public ActionResult MyEvents()
        {
            string UserName;
            try
            {
                UserName = User.Identity.Name;
            }
            catch(NullReferenceException e)
            {

                UserName = null;
            }
           
            
            var MyAllEvents =_myEvents.GetEvents(UserName);
            return View("Index", MyAllEvents);
        }
        public ActionResult InvitedEvent()
        {
            string UserName;
            try
            {
                UserName = User.Identity.Name;
            }
            catch (NullReferenceException e)
            {

                UserName = null;
            }
            var BookIdList= _invitedUser.GetAllBook(UserName);
           
          return View(_invitedEvent.GetAllInvitedEvents(BookIdList));
        }


    }
}