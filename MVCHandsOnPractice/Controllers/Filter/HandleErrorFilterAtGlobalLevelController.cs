using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHandsOnPractice.Controllers.Filter
{
    public class HandleErrorFilterAtGlobalLevelController : Controller
    {
        // GET: HadleErrorFilterAtGlobalLevel
        public ActionResult Index()
        {
            throw new Exception("throwing an exception");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}