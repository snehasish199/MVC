using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;
using MVCHandsOnPractice.MyDb;

namespace MVCHandsOnPractice.Controllers
{
    public class CRUDOperationController : Controller
    {
        // GET: CRUDOperation

        EmployeeDbOperation DbOperationObj;
        public CRUDOperationController()
        {
            DbOperationObj = new EmployeeDbOperation();
        }
       // localhost:xxxxx/CRUDoperation/allemployee
        public ActionResult AllEmployee()
        {
            var EmpListObj = DbOperationObj.GetAllEmployee();
            return View(EmpListObj);
        }
        
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeModel emp)
        {
            if (ModelState.IsValid)
            {
               int Id= DbOperationObj.AddEmployee(emp);
                if (Id > 0)
                {
                    return RedirectToAction("AllEmployee");
                }
              
            }
            return View();
        }
         
        public ActionResult Details(int id)
        {
            var EmpObj = DbOperationObj.GetEmployee(id);
            return View(EmpObj);
        }

       
        public ActionResult Delete(int id)
        {
            var Result = DbOperationObj.Delete(id);
           
            return View("AllEmployee");
        }

        
        public ActionResult Edit(int id)
        {
            var Emp = DbOperationObj.GetEmployee(id);
            return View(Emp);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
          if(ModelState.IsValid)
            {
                var id = DbOperationObj.Edit(emp);
                return RedirectToAction("AllEmployee");
            }
            return View(emp);
            
        }
    }
}