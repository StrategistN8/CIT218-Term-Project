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
    public class ItemModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ItemModels
        public ActionResult Index()
        {
            return View(db.ItemModels.ToList());
        }

        // GET: ItemModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.ItemModels.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // GET: ItemModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemName,ItemDescription,ItemImageSrc,LevelModelId")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.ItemModels.Add(itemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemModel);
        }

        // GET: ItemModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.ItemModels.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // POST: ItemModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemName,ItemDescription,ItemImageSrc,LevelModelId")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemModel);
        }

        // GET: ItemModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.ItemModels.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        // POST: ItemModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel itemModel = db.ItemModels.Find(id);
            db.ItemModels.Remove(itemModel);
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
