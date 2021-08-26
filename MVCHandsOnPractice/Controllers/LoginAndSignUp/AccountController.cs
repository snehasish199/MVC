using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;
using MVCHandsOnPractice.MyDb;
using System.Web.Security;

namespace MVCHandsOnPractice.Controllers.LoginAndSignUp
{
    public class AccountController : Controller
    {
        UserDbOperation UserObj;
       public AccountController()
        {
            UserObj = new UserDbOperation();
        }
        // GET: Account
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
               bool Result= UserObj.Add(model);
                if (Result)
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
              var Result=  UserObj.Get(model);
                if (Result == null)
                {
                    ViewBag.error = "User details not found";
                    return View();
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(Result, false);
                    return RedirectToAction("AllEmployee", "CRUDOperation");
                }
            }
            return View();
           
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}