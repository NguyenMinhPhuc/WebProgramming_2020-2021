using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//namespace tu tao
using Models.DAO;
using Models.EntityFramework;

namespace Project_20210503_EntityFramework.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var list = new CategoryDb().GetCategories(0);
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var list = new CategoryDb().GetCategoryByID(id);
            return View(list);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new CategoryDb().InsertUpdateCategory(model);
                if (result > 0 && ModelState.IsValid)
                {
                    //luu session

                    //return ve category
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Khong them duoc");
                }    
            }
            catch 
            {
               
            }
            return View(model);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var list = new CategoryDb().GetCategoryByID(id);
            return View(list);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {

            try
            {
                // TODO: Add insert logic here
                var result = new CategoryDb().InsertUpdateCategory(model);
                if (result > 0 && ModelState.IsValid)
                {
                    //luu session

                    //return ve category
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Khong them duoc");
                }
            }
            catch
            {

            }
            return View(model);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
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
