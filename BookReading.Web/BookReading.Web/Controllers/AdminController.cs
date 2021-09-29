using BookReading.Business;
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
        private readonly IBookReadingOperation _bookReading;
        public AdminController(IBookReadingOperation bookReading)
        {
            _bookReading = bookReading;
        }
      
        public ActionResult Index()
        {
            
            return View(_bookReading.GetAllEvents());
        }
        public ActionResult AllEvents()
        {
            return RedirectToAction("Index");
        }
    }
}