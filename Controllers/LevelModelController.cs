using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbyssRunSite.Models;

namespace AbyssRunSite.Controllers
{
    public class LevelModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LevelModels
        public ActionResult Index()
        {
            return View(db.LevelModels.ToList());
        }

        // GET: LevelModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // GET: LevelModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelName,LevelDescription,LevelScreenshotSrc")] LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                db.LevelModels.Add(levelModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelModel);
        }

        // GET: LevelModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: LevelModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelName,LevelDescription,LevelScreenshotSrc")] LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelModel);
        }

        // GET: LevelModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.LevelModels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: LevelModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelModel levelModel = db.LevelModels.Find(id);
            db.LevelModels.Remove(levelModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
