using Project_1_DataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1_DataFromControllerToView.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Chào cả lớp, Đây là dữ liệu được gửi từ Controller Home sang View";

            ViewBag.LoiChao =string.Format("Tôi đã biết lập trình web bằng ASP.NET MVC 5 từ ngày: {0}",DateTime.Now.ToString());
            ViewBag.SoLan = 30;
            TempData["Number"] = 30;
            return View();
        }
        public ActionResult HienThiSinhVien()
        {
            //Tạo một đối tượng Student có tên là sv1;
            Student sv1 = new Student();
            //Gán giá trị cho từng thuộc tính của sv1
            sv1.StudentID = 1;
            sv1.StudentName = "Nguyễn Văn A".ToUpper();
            sv1.ClassName = "18CT113";
            sv1.Address = "Đồng nai";
            //Gán đối tượng sv1 cho ViewBag.student
            ViewBag.student = sv1;
            return View();
        }
        public ActionResult HienThiDSSinhVien()
        {
            //Khai báo đối tượng StudentDAO.
            StudentDAO sd = new StudentDAO();
            //Gọi hàm GetStudentList() để lấy về danh sách student được khởi tạo trong StudentDAO.
            var list = sd.GetStudentList();
            
            //Gán đối tượng sv1 cho ViewBag.student
            ViewBag.students = list;
            return View();
        }
        public ActionResult StudentByID(int? StudentID=1)
        {
            StudentDAO sd = new StudentDAO();
            var _student = sd.GetStudentByID(StudentID);
            ViewBag._student = _student;
            return View();
        }
    }
}