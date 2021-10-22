using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FactoryDesignPattern.Business;
using FactoryDesignPattern.Business.Manager.Interface;
using FactoryDesignPattern.Business.ManagerFactory;
using FactoryDesignPattern.DataFacade;
using FactoryDesignPattern.Models;

namespace FactoryDesignPattern.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeFacade _db;

        public EmployeesController(IEmployeeFacade employeeFacade)
        {
            this._db = employeeFacade;
        }

        // GET: Employees
        public ActionResult Index()
        {
           
            return View(_db.GetAllEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee =_db.GetById(id) ;
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Dept,Salary,Bonus,EmployeeType")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeManagerFactory managerFactory = new EmployeeManagerFactory();
                IEmployeeManager emp = managerFactory.GetEmployeeManager(employee.EmployeeType);
                employee.Salary = emp.GetPay();
                employee.Bonus = emp.GetBonus();
               
                _db.Add(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
         var employee = _db.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Dept,Salary,Bonus,EmployeeType")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee= _db.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _db.GetById(id);
            _db.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
