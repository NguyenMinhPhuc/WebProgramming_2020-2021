using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210322_SIUD_ADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //trang chủ của website 
        public ActionResult Index()
        {
            return View();
        }
    }
}