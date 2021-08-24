using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHandsOnPractice.Controllers.Filter
{
    public class CacheFilterController : Controller
    {
        
        //default location is any
        [OutputCache(Duration =20)]
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration =20, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult CacheAtServerSide()
        {
            return View();
        }
        [OutputCache(Duration =20, Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult CacheAtClientSide()
        {
            return View();
        }
    }
}