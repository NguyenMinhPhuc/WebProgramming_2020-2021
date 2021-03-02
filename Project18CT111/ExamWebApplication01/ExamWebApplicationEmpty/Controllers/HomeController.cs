
using ExamWebApplicationEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamWebApplicationEmpty.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Tiêu đề của trang";
            return View();
        }
        //  /Home/ChaoMung
        public string ChaoMung()
        {
            return string.Format("Xin chào lớp {0} bang chao mung", "18CT111");
        }
        [HttpGet]
        public ActionResult ChaoMung(string name,int age=20)
        {
            ViewBag.name = "Nguyễn minh phúc";
            ViewBag.age = age;
            return View();
        }

        public ActionResult HienThi(string message, int number = 20)
        {
            ViewBag.Message = message;
            ViewBag.Number = number;
            return View();
        }

        public ActionResult Employee()
        {
            List<Employee> list = new List<Employee>(){
            new Employee() { ID = 1, NameEmp = "Nguyen Minh Phuc", Age = 30 },
            new Employee() { ID = 2, NameEmp = "Nguyen Minh ", Age = 31 },
            new Employee() { ID = 3, NameEmp = "Nguyen  Phuc", Age = 32 },
            new Employee() { ID = 4, NameEmp = " Minh Phuc", Age = 33 },
            new Employee() { ID = 5, NameEmp = "Nguyen Minh Phuc", Age = 34 },
            new Employee() { ID = 6, NameEmp = "Nguyen  Phuc", Age = 35 }};

            ViewBag.listEmp = list;
            return View();
        }
    }
}