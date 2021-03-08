using Project_Website_20200308.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Website_20200308.Controllers
{
    public class ProductController : Controller
    {
        List<Product> list;
        // GET: Product
        public ActionResult Index()
        {
           list = new List<Product>() { 
                new Product(){ProductID=1,ProductName="Giầy Bitis",Color="red",Size="L",Quantity=23},
                new Product(){ProductID=2,ProductName="Giầy Adidas",Color="blue",Size="L",Quantity=23},
                new Product(){ProductID=3,ProductName=" Giầy Nike",Color="Yellow",Size="L",Quantity=23},
                new Product(){ProductID=4,ProductName=" Giầy Bitis",Color="Pink",Size="L",Quantity=23},
                new Product(){ProductID=5,ProductName=" Giầy Bitis",Color="Black",Size="L",Quantity=23},
                new Product(){ProductID=6,ProductName=" Giầy Bitis",Color="red",Size="L",Quantity=23},
                new Product(){ProductID=7,ProductName=" Giầy Bitis",Color="red",Size="L",Quantity=23}
            };

            ViewBag.Products = list;
            return View();
        }
        [HttpGet]
        public ActionResult ProductByID(int? ProductID=1)
        {
            list = new List<Product>() { 
                new Product(){ProductID=1,ProductName="Giầy Bitis",Color="red",Size="L",Quantity=23},
                new Product(){ProductID=2,ProductName="Giầy Adidas",Color="blue",Size="L",Quantity=23},
                new Product(){ProductID=3,ProductName=" Giầy Nike",Color="Yellow",Size="L",Quantity=23},
                new Product(){ProductID=4,ProductName=" Giầy Bitis",Color="Pink",Size="L",Quantity=23},
                new Product(){ProductID=5,ProductName=" Giầy Bitis",Color="Black",Size="L",Quantity=23},
                new Product(){ProductID=6,ProductName=" Giầy Bitis",Color="red",Size="L",Quantity=23},
                new Product(){ProductID=7,ProductName=" Giầy Bitis",Color="red",Size="L",Quantity=23}
            };
            Product _product = list.SingleOrDefault(x => x.ProductID == ProductID);
            ViewBag.product = _product;
            return View();
        }
    }
}