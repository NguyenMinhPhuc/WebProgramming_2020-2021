using Models;
using Models.EF;
using Project_OnTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_OnTap.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var list = new UserDb().GetUsers();
            return View(list);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new UserDb().InsertUser(model.Username,model.Fullname,model.Address,model.Phone);
                if (result > 0 && ModelState.IsValid)
                {
                    ViewBag.infor = "Thêm thành công";
                    return RedirectToAction("Create");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }   
            }
            catch
            {
               
            } 
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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
        // Delete: User/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = new UserDb().DeleteUser(id);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Khong xoa duoc");
                }
            }
            catch (Exception ex) { return View("Index"); } 
            return View("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new UserDb().ChangeStatus(id);
            return Json(new {
                status=result
            });
        }
    }
}
