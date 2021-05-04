using Models.DAO;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210504_SuDungEF.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var list = new CategoryDb().GetsCategories(0);
            return View(list);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = new CategoryDb().GetsCategoryByID(id);
            return View(category);
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
            try{
                var result = new CategoryDb().InsertUpdateCategory(model);
                if (result != 0 & ModelState.IsValid){
                    //Luu session
                    //Tra ve view index
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Luu khong thanh cong");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            } 
            return View(model);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = new CategoryDb().GetsCategoryByID(id);
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category model)
        {
            try
            {
                var result = new CategoryDb().InsertUpdateCategory(model);
                if (result != 0 & ModelState.IsValid)
                {
                    //Luu session
                    //Tra ve view index
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Luu khong thanh cong");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(model);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = new CategoryDb().GetsCategoryByID(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category model)
        {
            try
            {
                var result = new CategoryDb().DeleteCategory(model);
                if (result != 0 & ModelState.IsValid)
                {
                    //Luu session
                    //Tra ve view index
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Xoa khong thanh cong");
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
            }
            return View(model);
        }
    }
}
