using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitEmployeeData(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
              
                return View(emp);
            }
            return View("AddEmployee");
        }
    }
}