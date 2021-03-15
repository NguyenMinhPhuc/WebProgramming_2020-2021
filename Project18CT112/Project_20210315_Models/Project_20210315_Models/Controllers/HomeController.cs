
using Project_20210315_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210315_Models.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            TempData["Message"] = "18CT112";
            TempData["Number"] = 10;
            TempData.Keep();
            return View();
        }

        public ActionResult About()
        {
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"];
            }
            if (TempData.ContainsKey("Number"))
                ViewBag.Number = TempData["Number"];
            return View();
        }

        public ActionResult Students()
        {
            var _students = new StudentDB().GetStudents();
            TempData["students"] = _students;
            return View();
        }
    }
}