using BookReading.Business;
using BookReading.Business.Facade;
using BookReading.DAL;
using System;
using System.Linq;
using System.Web.Mvc;



namespace BookReading.Web.Controllers
{
    [Authorize]
    public class BookReadingEventController : Controller
    {
        //private readonly IBookReadingOperation _bookReading;
        //private readonly IEmailValidityCheck _emailValidity;
        //private readonly IInvitedUserOperation _invitedUser;

        //private readonly IMyEvents _myEvents;
        //private readonly IInvitedEvents _invitedEvent;
        private readonly IBookReadingAllOperation _facade;
        public BookReadingEventController(
            //IBookReadingOperation bookReading
            //, IEmailValidityCheck emailValidity
            //, IInvitedUserOperation invitedUser

            //, IMyEvents myEvents
            //, IInvitedEvents invitedEvent
            IBookReadingAllOperation facade
           )
        {
            //_bookReading = bookReading;
            //_emailValidity = emailValidity;
            //_invitedUser = invitedUser;

            //_myEvents = myEvents;
            //_invitedEvent = invitedEvent;
            _facade = facade;

        }

       

        [AllowAnonymous]
        public ViewResult Index()
        {
            var AllEvent = _facade.GetAllEvents().Where(x => x.Type == "public").ToList();
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
                if (_facade.IsInvitedUsersValid(model.InvitedUSer) != null)
                {
                    ViewBag.error = _facade.IsInvitedUsersValid(model.InvitedUSer) + " is a wrong Email id .";
                    return View(model);
                }
                model.TotalInvitedUser = model.InvitedUSer.Split(',').Length;
                model.Author = User.Identity.Name;
                int BookId = _facade.AddEvent(model);

                _facade.AddInvitedUser(model.InvitedUSer, BookId);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            if (_facade.GetAuthor(id) == User.Identity.Name)
            {
                var UpdatingModel = _facade.GetEvent(id);

                return View(UpdatingModel);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(BookEvent bookEvent)
        {
            if (_facade.GetAuthor(bookEvent.Id) == User.Identity.Name || User.IsInRole("Admin"))
            {
                if (ModelState.IsValid)
                {
                    _facade.UpdateEvent(bookEvent);
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

            return View(_facade.GetEvent(id));
        }

        public ActionResult Delete(int id)
        {
            if (User.Identity.Name == _facade.GetAuthor(id) || User.IsInRole("Admin"))
            {
                _facade.DeleteEvent(id);
                _facade.DeleteBook(id);
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
            catch (NullReferenceException)
            {

                UserName = null;
            }


            var MyAllEvents = _facade.GetEvents(UserName);
            return View("Index", MyAllEvents);
        }
        public ActionResult InvitedEvent()
        {
            string UserName;
            try
            {
                UserName = User.Identity.Name;
            }
            catch (NullReferenceException)
            {

                UserName = null;
            }
            var BookIdList = _facade.GetAllBook(UserName);

            return View(_facade.GetAllInvitedEvents(BookIdList));
        }


    }
}