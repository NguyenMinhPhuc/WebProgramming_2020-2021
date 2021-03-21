using ProjectWebSite_20210320_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectWebSite_20210320_Model.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //gọi trang danh sách sản phẩm (product)
        public ActionResult Index()
        {
            var products = new ProductDb().List;
            TempData["products"] = products;
            TempData.Keep();
            return View();
        }
        
        public ActionResult ProductByID(int ProductID)
        {
            var products = TempData["products"] as List<Product>;
            if (products != null)
            {
                var product = products.SingleOrDefault(x => x.ProductID == ProductID);
                if (product != null) {
                    TempData["product"] = product;
                }
                else
                {
                    TempData["product"] = "Không có product cần tìm";
                }
                TempData.Keep(); 
            }
            else
            {
                TempData["product"] = "Không có danh sách sản phẩm";
            }
            return View();
        }

        public ActionResult ProductList()
        {
            //Lấy data từ ProductDb
            var products = new ProductDb().List;
            //truyền data sang view theo dạng Model
            return View(products);
        }

        public ActionResult Edit(int id)
        {
            var product = new ProductDb().List.SingleOrDefault(x => x.ProductID == id);
            return View(product);
        }
    }
}