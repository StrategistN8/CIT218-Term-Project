using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbyssRunSite.Models;
using AbyssRunSite.DataAccessLayer;

namespace AbyssRunSite.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private AbyssContext db = new AbyssContext();

        /// <summary>
        /// Index Page for Items.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string sortOrder)
        {
            ViewBag.SortName = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";

            var items = from i in db.Items
                          select i;
            switch (sortOrder)
            {
                case "nameDesc":
                    items = items.OrderByDescending(i => i.ItemName);
                    break;
                default:
                    items = items.OrderBy(i => i.ItemName);
                    break;
            }

                    return View(items.ToList());
        }

        /// <summary>
        /// Details page for Items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        /// <summary>
        /// Create Page for Items.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

     /// <summary>
     /// POST page for Creating Items.
     /// </summary>
     /// <param name="itemModel"></param>
     /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemName")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(itemModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemModel);
        }

        /// <summary>
        /// Edit Page for items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

       /// <summary>
       /// POST edit page for items.
       /// </summary>
       /// <param name="itemModel"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemName")] ItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemModel);
        }

       /// <summary>
       /// Delete page for items.
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemModel itemModel = db.Items.Find(id);
            if (itemModel == null)
            {
                return HttpNotFound();
            }
            return View(itemModel);
        }

        /// <summary>
        /// POST delete page for items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemModel itemModel = db.Items.Find(id);
            db.Items.Remove(itemModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Required for IDisposable.
        /// </summary>
        /// <param name="disposing"></param>
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
