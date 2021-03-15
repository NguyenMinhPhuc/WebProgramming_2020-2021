using Project_20210315_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210315_Models.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            //Khai báo 1 biến students để nắm giữ 
            //danh sách sinh viên được đọc từ Database
            var students = new StudentDB().GetStudentList();
            //Trả list về view theo dạng truyền Models
            return View(students);
        }
    }
}