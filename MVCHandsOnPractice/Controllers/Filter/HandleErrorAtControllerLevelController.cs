using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHandsOnPractice.Controllers.Filter
{
    [HandleError]
    public class HandleErrorAtControllerLevelController : Controller
    {
        // GET: HandleErrorAtControllerLevel
        public ActionResult Index()
        {
            throw new Exception("This is an Exception");
        }
        public ActionResult About()
        {
            throw new Exception("This is another Exception ");
        }
    }
}