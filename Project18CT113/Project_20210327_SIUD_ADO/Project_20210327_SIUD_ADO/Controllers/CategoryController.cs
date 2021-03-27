﻿using Project_20210327_SIUD_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_20210327_SIUD_ADO.Controllers
{
    public class CategoryController : Controller
    {
        string err = string.Empty;
        int rows = 0;
        // GET: Category
        public ActionResult Index()
        {
            var categories = new CategoryDb().GetCategories(ref err);
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = new CategoryDb().GetCategoryByID(ref err,id);
            if (category != null)
            {
                return View(category);
            }
            else
            {
                if (!string.IsNullOrEmpty(err))
                    ViewBag.Err =string.Format("Lỗi: {0}", err);
                else
                    ViewBag.Err = "Category khong co giá trị";
            }
            return View();
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
                var result = new CategoryDb().InsertUpdateCategory(ref err, ref rows, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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
                var result = new CategoryDb().InsertUpdateCategory(ref err, ref rows, collection);
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
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = new CategoryDb().DeleteCategory(ref err, ref rows, collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
