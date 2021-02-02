using Keepr.Data.Models;
using Keepr.Data.Services;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace keepr.web.Controllers
{
    public class KeepsController : Controller
    {
        private readonly IKeepData db;

        public KeepsController(IKeepData db)
        {
            this.db = db;
        }
        // GET: Keeps
        [DisableCors]
        public ActionResult Index()
        {
            var models = db.GetAll();
            return View(models);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("Error");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Keep editedKeep)
        {
            if (ModelState.IsValid)
            {
                db.Update(editedKeep);
                return RedirectToAction("Details", new { id = editedKeep.Id });
            }
            return View(editedKeep);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("Error");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("Error");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string meow)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("Error");
            }
            db.Delete(id);
           return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Keep keep)
        {
            if(ModelState.IsValid)
            {
                db.Add(keep);
                return RedirectToAction("Details", new { id = keep.Id });
            }
            return View();
        }
    }
}