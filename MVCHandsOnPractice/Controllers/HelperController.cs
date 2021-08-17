using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.Controllers
{
    public class HelperController : Controller
    {
        // GET: Helper
        // Helper/GetAllStudent

        public ActionResult GetAllStudent()
        {
            var StdListObj = GetStudentsDetails();
            return View(StdListObj);
        }

        // Helper/getstudent/{id}
        public ActionResult GetStudent(int id)
        {
            var StdObj = GetStudentsDetails().FirstOrDefault(x => x.Id == id);
            ViewBag.Result = "";
            if (StdObj == null)
            {
                ViewBag.Result = "Student is not Found with Respected Id";
            }
            return View(StdObj);
        }


        //Custom Helper : Created a helper for render an image 
        public ActionResult CustomHelper()
        {
            return View();
        }








        private List<Student> GetStudentsDetails()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="Snehasish",
                    Email="snehasish@gmail.com"
                },
                new Student()
                {
                    Id=2,
                    Name="Rajib",
                    Email="rajib@gmail.com"
                },
                new Student()
                {
                    Id=3,
                    Name="Sandeep",
                    Email="sandeep@gmail.com"
                },
                new Student()
                {
                    Id=4,
                    Name="Sarat",
                    Email="sarat@gmail.com"
                },
                new Student()
                {
                    Id=5,
                    Name="Supriyo",
                    Email="supriyo@gmail.com"
                },
                new Student()
                {
                    Id=6,
                    Name="Paritosh",
                    Email="paritosh@gmail.com"
                },
                 new Student()
                {
                    Id=7,
                    Name="Pratik",
                    Email="pratik@gmail.com"
                }



            };
        }
    }
}