using Project_20210412_ChiaPhanVungAdmin.Areas.Admin.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210412_ChiaPhanVungAdmin.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (SessionHelper.GetSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Admin" });
            }
        }
    }
}