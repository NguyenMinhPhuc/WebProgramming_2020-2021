using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210419_Login.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        string err = string.Empty;
        int rows = 0;
        // GET: Admin/Product
        public ActionResult Index(string searching = "", int categoryID = 0)
        {

            var categories = new CategoryDb().GetCategories(ref err, 0);
            ViewBag.categoryID = new SelectList(categories, "ID", "Name"); // danh sách Category


            var products = (IEnumerable<Product>)new ProductDb().GetProductsC2(ref err,0);

            #region Cách 2
            if (!string.IsNullOrEmpty(searching))
            {
                products = products.Where(s => s.Alias.Contains(searching));
            }
            if (categoryID > 0)
            {
                products = products.Where(s => s.CategoryID == categoryID);
            }
            #endregion
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                 var result = new ProductDb().InsertUpdateProduct(ref err, ref rows, model);
                if (result && ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Product", new  { Area="Admin"});
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Error: {0}", err));
                }

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return View(model);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product model)
        {
            try
            {
                var result = new ProductDb().InsertUpdateProduct(ref err, ref rows, model);
                if (result && ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Error: {0}", err));
                }

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return View(model);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = new ProductDb().GetProductByID(ref err, id);
            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product model)
        {
            try
            {
                  var result = new ProductDb().DeleteProduct(ref err, ref rows, model);
                if (result && ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Product", new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Error: {0}", err));
                }

            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return View(model);
        }
    }
}
