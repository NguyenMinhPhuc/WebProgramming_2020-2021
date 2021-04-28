using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210416_Login.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        string err = string.Empty;
        // GET: Admin/Product
        public ActionResult Index(string searchString="",int categoryID=0)
        {
            var categories = new CategoryDb().GetCategories(ref err,0);
            ViewBag.categoryID = new SelectList(categories, "ID", "Name");

            var products =(IEnumerable<Product>) new ProductDb().GetProducts(ref err, 0);
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(x => x.Alias.ToLower().Contains(searchString.ToLower()));
            }
            if (categoryID != 0)
            {
                products = products.Where(x => x.CategoryID == categoryID);
            }
            return View(products);
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
