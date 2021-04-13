using Models;
using Project_20210406_PhanVungAdmin.Areas.Admin.Code;
using Project_20210406_PhanVungAdmin.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_20210406_PhanVungAdmin.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        string err=string.Empty;
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//kiểm tra token, tránh request liên tục
        public ActionResult Index(LoginModel loginModel)
        {
            ////var result=new AccountDb().Login(ref err,loginModel.UserName,loginModel.Password);
            ////if(result && ModelState.IsValid)
            ////{
            ////    SessionHelper.SetSession(new UserSession() { UserName = loginModel.UserName });
            ////    return RedirectToAction("Index", "Home");
            ////}
            ////else
            ////{
            ////    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            ////}
            ////return View(loginModel);



            //Thuc hiem su dung membership
          
            if(Membership.ValidateUser(loginModel.UserName,loginModel.Password) && ModelState.IsValid)
            {
               FormsAuthentication.SetAuthCookie(loginModel.UserName,loginModel.RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
            }
           
            return View(loginModel);
        }

        public ActionResult Logout()
        {
           // SessionHelper.SetSession(null);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");

        }


    }
}