using ProjectWebSite_20210309.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWebSite_20210309.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Khai báo ViewBag có tên là Message
            ViewBag.Message = string.Format("Dữ liệu được tạo từ Controller và truyền sang View Theo ViewBag");
            ViewBag.Name = "Nguyễn Minh Phúc";
            ViewBag.Age = 35;
            ViewBag.Address = "Đồng Nai";
            ViewBag.Number = 10;
            return View();
        }

        public ActionResult Students()
        {
            Student _student = new Student() { StudentID = 1, StudentName = "Nguyễn Minh Phúc", ClassName = "18Ct111".ToUpper(), Address = "Biên Hòa Đồng Nai" };

            ViewBag.student = _student;
            return View();
        }

        public ActionResult StudentsList()
        {
            List<Student> list = new List<Student>();
            Student _student;
            for (int i = 0; i < 20; i++)
            {
                _student = new Student();
                _student.StudentID = i + 1;
                _student.StudentName = string.Format("Nguyễn Minh Phúc_Thứ {0}", i + 1);
                _student.ClassName = "18Ct111".ToUpper();
                _student.Address = "Biên Hòa Đồng Nai";
                list.Add(_student);
            }
            #region rút gọn
            //List<Student> _list = new List<Student>() { 
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //   new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //    new Student(){ StudentID=1,StudentName="kdkdk",ClassName="18CT111",Address="Dong nai"},
            //};

            #endregion
            ViewBag.studentList = list;
            return View();
        }

        public ActionResult StudentByID(int? StudentID = 1)
        {
            StudentDAO sd = new StudentDAO();
            var list = sd.GetStudentList();

            Student studentResult = list.SingleOrDefault(x => x.StudentID == StudentID);
            ViewBag.Result = studentResult;

            return View();
        }
    }
}