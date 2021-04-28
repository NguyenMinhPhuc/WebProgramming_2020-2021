using Project_20210416_Login.Areas.Admin.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210416_Login.Areas.Admin.Controllers
{
   // [Authorize]
   //// [AllowAnonymous]
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

                return View();

        }
    }
}