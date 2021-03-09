using ProjectWebSite_20210309.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWebSite_20210309.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewData["Message"] = "Dữ liệu được truyền từ Controller Product sang View theo ViewData";

            ViewData["Number"] = 10;

            return View();
        }
        public ActionResult Product()
        {
            var productDao=new ProductDAO();
            var result = productDao.GetProduct();

            ViewData["_product"] = result;
            return View();
        }
        public ActionResult ProductList()
        {
            var productDao = new ProductDAO();
            var result = productDao.GetProductList();

            ViewData["_productList"] = result;
            return View();
        }

        public ActionResult ProductByID(int? ProductID=1)
        {
            var productDao = new ProductDAO();
            var result = productDao.GetProductByID(ProductID);

            ViewData["_product"] = result;
            return View();
        }
    }
}