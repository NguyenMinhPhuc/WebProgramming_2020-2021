using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap.Controllers
{
    public class CatController : Controller
    {
        // GET: Cat
        public ActionResult Index()
        {
            var cats = new CatDb().GetCats();
            return View(cats);
        }

        // GET: Cat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cat/Create
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

        // GET: Cat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cat/Edit/5
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
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                var result = new CatDb().DelectCat(id);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Khong xoa duoc");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Khong xoa duoc "+ex.Message);
            }
            return View("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new CatDb().UpdateCat(id);
            return Json(new 
            {
                status=result
            });
        }
    }
}
