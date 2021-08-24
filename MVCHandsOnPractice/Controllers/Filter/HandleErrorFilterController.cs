using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHandsOnPractice.Controllers.Filter
{
    public class HandleErrorFilterController : Controller
    {
        // GET: HandleErrorFilter
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception("This is an unhandle exception");
        }
    }
}