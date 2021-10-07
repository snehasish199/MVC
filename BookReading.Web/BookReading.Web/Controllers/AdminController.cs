using BookReading.Business.Facade;
using BookReading.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReading.Web.Controllers
{
    [Authorize(Roles ="Admin"), ]
    public class AdminController : Controller
    {
        // GET: Admin
        //  private readonly IBookReadingOperation _bookReading;
        private readonly IBookReadingAllOperation _facade;
        public AdminController( IBookReadingAllOperation facade)
        {
            _facade = facade;
        }
      
        public ActionResult Index()
        {
            
            return View(_facade.GetAllEvents());
        }
        public ActionResult AllEvents()
        {
            return RedirectToAction("Index");
        }
    }
}