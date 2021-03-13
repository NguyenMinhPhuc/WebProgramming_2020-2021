using Project_1_DataFromControllerToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_1_DataFromControllerToView.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var list = new ProductDao().GetProducts();
            ViewData["products"] = list;
            return View();
        }
        public ActionResult ProductByID(int ProductID)
        {
            var _product = new ProductDao().GetProductByID(ProductID);
            if (_product != null)
                ViewData["product"] = _product;
            else
                ViewData["product"] = "Không tìm thấy";
            return View();
        }
    }
}