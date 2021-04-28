using Models;
using Project_20210419_Login.Areas.Admin.Commons;
using Project_20210419_Login.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_20210419_Login.Areas.Admin.Controllers
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
            if(Membership.ValidateUser(model.UserName,model.PassWord)&&ModelState.IsValid)
            {
                //Luu Session
                //SessionHelper.SetSession(new UserSession() { UserName=model.UserName});
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                //Tra ve trang Admin
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            else
            {
               //Luu loi
                ModelState.AddModelError("", string.Format("UserName và Password không đúng \n{0}",err));
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            //xoa session
            //SessionHelper.SetSession(null);
            FormsAuthentication.SignOut();
            // chuye view ve login
            return RedirectToAction("Index", "Home", new { Area = "Admin" });
        }
    }
}