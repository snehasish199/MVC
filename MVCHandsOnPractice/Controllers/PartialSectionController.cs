using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;

namespace MVCHandsOnPractice.Controllers
{
    public class PartialSectionController : Controller
    {
        // GET: PartialSection
        public ActionResult Index()
        {
            var StdList = GetStudents();
            return View(StdList);
        }

        public ActionResult Section()
        {
            return View();
        }


        public ActionResult RenderPage()
        {
            return View();
        }


        private IEnumerable<Student> GetStudents()
        {
            return new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="Snehasish Pramanik",
                    Email="snehasish@gmail.com"
                },
                new Student()
                {
                    Id=2,
                    Name="Sarat saibya",
                    Email="Sarat@gmail.com"
                },
                new Student()
                {
                    Id=3,
                    Name="rajib mahato",
                    Email="rajib@gmail.com"
                },
                new Student()
                {
                    Id=1,
                    Name="Sandeep panjiyaar",
                    Email="sandeep@gmail.com"
                },
                new Student()
                {
                    Id=1,
                    Name="sakil Mandal",
                    Email="sakil@gmail.com"
                }

            };
        }
    }
}