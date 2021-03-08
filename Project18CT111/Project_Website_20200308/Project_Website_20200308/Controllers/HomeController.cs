using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Website_20200308.Models;

namespace Project_Website_20200308.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Dữ liệu được tạo từ controller và gửi sang view Index.cshtml sử dụng ViewBag";
            ViewBag.Name = "Nguyễn Minh Phúc";
            ViewBag.Age = 45;

            ViewData["Message"] = "Dữ liệu được tạo từ controller và gửi sang view Index.cshtml sử dụng viewData";
            ViewData["Name"] = "Nguyễn Hoang";
            ViewData["Age"] = 45;

            Student st1 = new Student();
            st1.StudentID = 1;
            st1.StudentName = "Nguyễn Văn A";
            st1.ClassName = "18CT111";
            st1.Age = 23;

            ViewBag.Student1 = st1;
            ViewData["StudentData"] = st1;


            List<Student> Students = new List<Student>() { 
                new Student(){ StudentID=1,StudentName="Nguyễn Văn A",ClassName="18CT111",Age=19},
                new Student(){ StudentID=2,StudentName="Nguyễn A",ClassName="18CT111",Age=20},
                new Student(){ StudentID=3,StudentName="Văn A",ClassName="18CT111",Age=21},
                new Student(){ StudentID=4,StudentName="Nguyễn Văn Bảo",ClassName="18CT111",Age=22},
                new Student(){ StudentID=5,StudentName="Nguyễn Văn Phúc",ClassName="18CT111",Age=23},
                new Student(){ StudentID=6,StudentName="Nguyễn Thị Ngọc",ClassName="18CT111",Age=23},
                new Student(){ StudentID=7,StudentName="Trần Văn A",ClassName="18CT111",Age=24}
            };
            ViewBag.StudentList = Students;
            return View();
        }

        public ActionResult StudentByID(int StudentID)
        {
            List<Student> Students = new List<Student>() { 
                new Student(){ StudentID=1,StudentName="Nguyễn Văn A",ClassName="18CT111",Age=19},
                new Student(){ StudentID=2,StudentName="Nguyễn A",ClassName="18CT111",Age=20},
                new Student(){ StudentID=3,StudentName="Văn A",ClassName="18CT111",Age=21},
                new Student(){ StudentID=4,StudentName="Nguyễn Văn Bảo",ClassName="18CT111",Age=22},
                new Student(){ StudentID=5,StudentName="Nguyễn Văn Phúc",ClassName="18CT111",Age=23},
                new Student(){ StudentID=6,StudentName="Nguyễn Thị Ngọc",ClassName="18CT111",Age=23},
                new Student(){ StudentID=7,StudentName="Trần Văn A",ClassName="18CT111",Age=24}
            };
           Student st1 = Students.SingleOrDefault(x => x.StudentID == StudentID);
            ViewBag.student1 = st1;
            return View();
        }
    }
}