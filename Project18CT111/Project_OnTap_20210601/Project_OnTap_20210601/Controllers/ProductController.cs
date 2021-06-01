using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap_20210601.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int catID=0)
        {
            var categories = new ProductDao().GetCategories();
            ViewBag.Categories = categories;
            var products = new ProductDao().GetProducts(catID);
            TempData["catID"] = catID;
            TempData.Keep();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (TempData["catID"] != null)
            {
                if (!TempData["catID"].ToString().Equals("0"))
                {
                    ViewBag.CatID = TempData["catID"].ToString();
                    TempData.Keep();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblPro model)
        {
            model.CatID =(int) TempData["catID"];
            var result = new ProductDao().InsertProduct(model);
            if(result>0)
            {
                SetAlert("Them thanh cong", "success");
            }
            else
            {
                SetAlert("Them  khong thanh cong", "error");
            }
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = new ProductDao().DeleteProduct(id);
            if (result > 0)
            {
                SetAlert("Xoa thanh cong", "success");
            }
            else
            {
                SetAlert("xoa  khong thanh cong", "error");
            }
            return View();
        }
        private void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type.Equals("success"))
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type.Equals("warning"))
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type.Equals("error"))
            {
                TempData["AlertType"] = "alert-danger";
            }
            else
            {
                TempData["AlertType"] = "alert-primary";
            }
        }
        [ChildActionOnly]
        public PartialViewResult _MenuCategory()
        {
            var categories = new ProductDao().GetCategories();
            return PartialView(categories);
        }
    }
}