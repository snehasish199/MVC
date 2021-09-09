using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDI.Repository;
using MvcDI.Models;

namespace MvcDI.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepos _employeeRepos;
        public HomeController(IEmployeeRepos employeeRepos)
        {
            _employeeRepos = employeeRepos;
        }
        public ActionResult Index()
        {
            return View(_employeeRepos.GetAllEmployees());
        }

        public ActionResult Details( int id)
        {
            

            return View(_employeeRepos.GetEmployee(id));
        }

        public ActionResult Delete(int id)
        {
            _employeeRepos.Delete(id);
            return RedirectToAction("Index");

    
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            if (ModelState.IsValid)
            {
                if (_employeeRepos.Add(emp))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(emp);
    }
        public ActionResult Edit(int id)
        {
          
            return View(_employeeRepos.GetEmployee(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepos.Update(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }
    }
}