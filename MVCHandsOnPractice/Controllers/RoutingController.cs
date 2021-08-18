using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.Controllers
{
    public class RoutingController : Controller
    {
      
        // localhost:xxxxx/AllEmployees
        public ActionResult ConventionalRouting()
        {
            var EmpObj = AllEmployeeDetails();
            return View(EmpObj);
        }

        //attribute Routing

        // localhost:xxxxx/AllEmployeesDetails
        [Route("AllEmployeesDetails")]
        public ActionResult GetAllEmployees()
        {
            var EmpListObj = AllEmployeeDetails();
            return View(EmpListObj);
        }

        // localhost:xxxxx/AllEmployeesDetails/id

        [Route("AllEmployeesDetails/{id}")]
        public ActionResult GetEmployee(int id)
        {
           
                var EmpObj = AllEmployeeDetails().FirstOrDefault(x => x.Id == id);
                ViewBag.Result = "";
                if (EmpObj == null)
                {
                    ViewBag.Result = "Employee of respected Id is not found";
                }
                return View(EmpObj);
           
            
        }

        //attribute routing
        // localhost:xxxxx/AllEmployeesDetails/id/address

        [Route("AllEmployeesDetails/{id}/address")]
        public ActionResult GetEmployeeAddress(int id)
        {
            var EmpObj = AllEmployeeDetails().FirstOrDefault(x => x.Id == id);
            ViewBag.Result = "";
            if (EmpObj == null)
            {
                ViewBag.Result = "Employee of respected Id is not found";
            }
            return View(EmpObj);
        }
        private List<EmployeeModel> AllEmployeeDetails()
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel()
                {
                    Id=1,
                    Name="Snehasish Pramanik",
                    Email="snehasish@nagarro.com",
                    Address="West Bengal",
                    DateOfBirth=new DateTime(1998,4,14),
                   Gender="Male"

                },
                 new EmployeeModel()
                {
                    Id=2,
                    Name="Puspendu Khan",
                    Email="puspendu@nagarro.com",
                    Address="West Bengal",
                    DateOfBirth=new DateTime(1999,8,17),
                    Gender="Male"

                },
                  new EmployeeModel()
                {
                    Id=1,
                    Name="Vivek Agarwal",
                    Email="vivek@nagarro.com",
                    Address="Uttar Pradesh",
                    DateOfBirth=new DateTime(1998,7,4),
                    Gender="Male"

                },
                   new EmployeeModel()
                {
                    Id=4,
                    Name="Pratik Sutradhar",
                    Email="pratik@nagarro.com",
                    Address="West Bengal",
                    DateOfBirth=new DateTime(1999,12,24),
                    Gender="Male"

                },
                    new EmployeeModel()
                {
                    Id=5,
                    Name="Sandeep Panjiyaar",
                    Email="sarat@nagarro.com",
                    Address="Assam",
                    DateOfBirth=new DateTime(1996,12,29),
                    Gender="Male"

                }

            };
        }
    }
}