using Project_WebSite_20210316_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_WebSite_20210316_Models.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            //lấy danh sách sinh viên tử lớp StudentDB gán vào biền students
            var students = new StudentDB().GetStudents();
            //Truyền students sang view sử dụng TempData
            TempData["students"] = students;
            TempData.Keep();
            return View();
        }

        public ActionResult StudentByID(string StudentID)
        {
            var students = TempData["students"] as List<Student>;
            var student = students.SingleOrDefault(x => x.StudentID == StudentID);
            TempData["student"]=student;
            TempData.Keep();
            return View();
        }

        public ActionResult GetStudents()
        {
            //lấy danh sách sinh viên tử lớp StudentDB gán vào biền students
            var students = new StudentDB().GetStudents();
            return View(students);
        }

        public ActionResult GetStudetList()
        {
            var students = new StudentDB().GetStudents();

            return View(students);
        }
    }
}