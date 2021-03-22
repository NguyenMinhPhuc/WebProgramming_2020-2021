using Project_20210322_SIUD_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210322_SIUD_ADO.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            string err=string.Empty;
            var categories = new CategoryDb().GetCategories(ref err);
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            string err=string.Empty;
          //  var category = new CategoryDb().GetCategoryByID(ref err, id);
            var categories = new CategoryDb().GetCategories(ref err);
            var category = categories.SingleOrDefault(x => x.ID == id);
            if (category != null)
                return View(category);
            else
            {
                if(!string.IsNullOrEmpty(err))
                ViewBag.err =string.Format("Lỗi: {0}", err);
                else
                {
                    ViewBag.err = "Không có giá trị";
                }
                return View();
            }
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                // TODO: Add insert logic here
                string err = string.Empty;
                int rows = 0;
                var result = new CategoryDb().InsertCategory(ref err, ref rows, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        string err = string.Empty;
        int rows = 0;

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {

            var category = new CategoryDb().GetCategoryByID(ref err, id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {
                // TODO: Add update logic here
              
                var result = new CategoryDb().UpdateCategory(ref err, ref rows, collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = new CategoryDb().GetCategoryByID(ref err, id);
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = new CategoryDb().DeleteCategoryByID(ref err, ref rows, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
