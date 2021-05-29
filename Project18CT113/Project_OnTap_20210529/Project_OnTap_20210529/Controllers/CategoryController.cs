using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap_20210529.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var categories = new CategoryDao().GetCategories();
            return View(categories);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = new CategoryDao().DeleteCategoryByID(id);
            if(result>0)
            {
                SetAlert("xoa thanh cong", "success");
            }
            else
            {
                SetAlert("xoa khong thanh cong", "error");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblCat model)
        {
            var result = new CategoryDao().InsertCategory(model);
            if(result>0 && ModelState.IsValid)
            {
                SetAlert("Them thanh coong", "success");
            }
            else
            {
                //SetAlert("Them khong thanh coong", "error");
                ModelState.AddModelError("", "Them khong thanh cong");
            }
            return View(model);
        }
        public void SetAlert(string message,string type)
        {
            TempData["AlertMessage"] = message;
            if(type.Equals("success"))
            {
                TempData["AlertType"] = "alert-success";
            }else if(type.Equals("warning"))
            {
                TempData["AlertType"] = "alert-warning";
            }else if(type.Equals("error"))
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-primary";
            }
        }
    }
}