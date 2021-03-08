using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWebsite_EmptyTemplate.Controllers
{
    public class HienThiController : Controller
    {
        // GET: HienThi
        public string Index()
        {
            return string.Format("Đây là Controller Hiển thị với Action index");
        }
        [HttpGet]
        public string ThongTin(string name,int age=20)
        {
            return string.Format("Tôi tên là {0}. tuổi của tôi là {1} tuổi",name,age);
        }
    }
}