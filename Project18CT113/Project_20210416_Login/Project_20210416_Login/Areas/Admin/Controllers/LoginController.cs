using Models;
using Project_20210416_Login.Areas.Admin.Commons;
using Project_20210416_Login.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_20210416_Login.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        string err = string.Empty;
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
           // var result = new AccountDb().CheckLogin(ref err, model.UserName, model.PassWord);
            if(Membership.ValidateUser(model.UserName,model.PassWord) && ModelState.IsValid)
            {
                //luu session
               // SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }else
            {
                ModelState.AddModelError("","UserName hoặc password không đúng");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            //xoa session
            //SessionHelper.SetSession(null);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
    }
}