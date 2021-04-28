using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210419_Login.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        string err = string.Empty;
        int rows = 0;
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = new CategoryDb().GetCategories(ref err, 0);
            return View(categories);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            var product = new CategoryDb().GetCategoryByID(ref err, id);
            return View(product);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new CategoryDb().InsertUpdateCategory(ref err, ref rows, model);
                if(result&&ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", string.Format("Error: {0}", err));
                }
                
            }
            catch ( Exception ex)
            {
                err = ex.Message;
            }
            return View(model);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var product = new CategoryDb().GetCategoryByID(ref err, id);
            return View(product);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                var result = new CategoryDb().InsertUpdateCategory(ref err, ref rows, model);
                if (result && ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Category", new  {Area="Admin" });
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

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            var product = new CategoryDb().GetCategoryByID(ref err, id);
            return View(product);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                var result = new CategoryDb().DeleteCategory(ref err, ref rows, model);
                if (result && ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Category", new { Area = "Admin" });
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
