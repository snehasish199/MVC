using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCHandsOnPractice.Models;
using Newtonsoft.Json;

namespace MVCHandsOnPractice.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajaxs

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Country()
        {
            List<string> Country = new List<string>()
            {
               " Afghanistan ",

                "Albania ",
                "Algeria",
                "Andorra ",
                "Angola  ",
                "Antigua and Barbuda",
                "Argentina   ",
                "Armenia",
                "Australia",
                "Austria ",
                "Azerbaijan",
                "Bahamas ",
                "Bahrain ",
                "Bangladesh  ",
                "Barbados   ",
                "Belarus",
                "Belgium ",
                "Belize  ",
                "Benin  ",
                "Bhutan  ",
                "Bolivia ",
                "Bosnia and Herzegovina ",
                "Botswana    ",

                "Brazil  ",
                "Brunei ",
                "Bulgaria ",
                "Burkina Faso",
                "Burundi ",
                "Côte d'Ivoire",
                "Cabo Verde  ",
                "Cambodia    ",
                "Cameroon   ",
                "Canada  ",
                "Central African Republic  ",
                "Chad ",
                "Chile  ",
                "China ",
                "Comoros ",
                "Congo (Congo-Brazzaville)",
                 "Costa Rica"            };


            var json = JsonConvert.SerializeObject(Country);
            return Json(json, JsonRequestBehavior.AllowGet);
        }



        public JsonResult State()
        {
            List<string> State = new List<string>()
            {
               "state- Afghanistan ",
                "state-Albania ",
                "state-Algeria",
                "state-Andorra ",
                "state-Angola  ",
                "state-Antigua and Barbuda",
                "state-Argentina   "       };
            var json = JsonConvert.SerializeObject(State);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public JsonResult City()
        {
            List<string> City = new List<string>()
            {
               "City- Afghanistan ",
                "City-Albania ",
                "City-Algeria",
                "City-Andorra ",
                "City-Angola  ",
                "City-Antigua and Barbuda",
                "City-Argentina   "  
            };
            var json = JsonConvert.SerializeObject(City);
            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddUsingAjaxForm()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddUsingAjaxForm(Student std)
        {
            if (ModelState.IsValid)
            {
                return Json("Data Successfully Added", JsonRequestBehavior.AllowGet);
            }

            return Json("Failed to Submit Data", JsonRequestBehavior.AllowGet);
        }


        public ActionResult StudentDetails()
        {
            return View();
        }

        public JsonResult GetStudent()
        {
            Student Std = new Student()
            {
                Id = 1,
                Name = "Snehasish Pramanik",
                Email = "1998pramanik@gmail.com"
            };
            var json = JsonConvert.SerializeObject(Std);
            return Json(json, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddStudent(Student std)
        {
            var json = JsonConvert.SerializeObject(std);
            return Json(json, JsonRequestBehavior.AllowGet);
        }



    }
}