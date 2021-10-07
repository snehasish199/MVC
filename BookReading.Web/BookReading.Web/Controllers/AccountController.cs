using BookReading.Business;
using BookReading.Business.Facade;
using BookReading.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookReading.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //private readonly IUserOperation _user;
        //private readonly IUserRoleOperation _userRole;
        private readonly IBookReadingAllOperation _facade;
        public AccountController(  IBookReadingAllOperation facade)
        {
            _facade = facade;
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
               if( _facade.AddUSer(model))
                {

                   var UserID= _facade.GetUSerId(model.Email);
                    UserRole userRole = new UserRole()
                    {
                        UserId = UserID,
                        Role = "User"
                    };
                    _facade.SetRole(userRole);

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.message = "User Already Exist";
                }

               
            }
            return View(model);
           
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
               if( _facade.IsValidUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                   
                  
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.error = "Email or Password is Wrong";
            return View(model);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            return RedirectToAction("Index","Home");
        }
    }
}