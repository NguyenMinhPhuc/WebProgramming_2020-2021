using Project_20210419_Login.Areas.Admin.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210419_Login.Areas.Admin.Controllers
{
    //[Authorize]//kiem tra
   // [AllowAnonymous]//cho phep khong can kiem tra
    public class HomeController : BasicController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //if(SessionHelper.GetSession()!=null)
            //{ 
               return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Login", new { Area = "Admin" });
            //}
          
        }
    }
}