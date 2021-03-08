using HelloWebsite_EmptyTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWebsite_EmptyTemplate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Trang của tôi";
            List<Student> list = new List<Student>()
            {
                 new Student(){ Name="NGuyên minh PHúc",Age=24},
                 new Student(){ Name="NGuyên  PHúc",Age=25},
                 new Student(){ Name="NGuyên minh ",Age=26},
                 new Student(){ Name=" minh PHúc",Age=27},
                 new Student(){ Name="NGuyên  PHúc",Age=28},
                 new Student(){ Name="NGuyên minh PHúc",Age=29}

            };

            ViewBag.StudentList = list;
            return View();
        }
    }
}