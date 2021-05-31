using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap20210531.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int catId=0)
        {
            var categories = new ProductDao().GetCategories();
            ViewBag.ListCategory = categories; //new SelectList(categories, "CatID", "CatName");
            var products = new ProductDao().GetProducts(catId);

            TempData["catId"] = catId;
            TempData.Keep();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Create(tblPro model)
        {
            model.CatID = (int)TempData["catId"];
            var result = new ProductDao().InsertPro(model);
            if (result > 0)
                SetAlert("Them thanh công", "success");
            else
            {
                SetAlert("Them không thanh công", "error");
            }
            return View(model);
        }
        public void SetAlert(string message, string type)
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