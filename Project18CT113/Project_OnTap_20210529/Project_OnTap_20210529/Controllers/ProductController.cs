using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap_20210529.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int CategoryID = 0)
        {
            var products = new ProductDao().GetProductByID(CategoryID);
            var cats = new ProductDao().GetCategories();
            ViewBag.CategoryID = cats; //new SelectList(cats, "CatID", "CatName");
            TempData["CatID"] = CategoryID;
            TempData.Keep();
            return View(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblPro model)
        {
            model.CatID =(int)TempData["CatID"];
            //thuc hien viec insert pro 

            return View();
        }
        [ChildActionOnly]
        public PartialViewResult MenuCategory()
        {
            var cats = new ProductDao().GetCategories();
            return PartialView(cats);
        }
    }
}