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
    public class EnemyModelController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EnemyModel
        public ActionResult Index()
        {
            return View(db.EnemyModels.ToList());
        }

        // GET: EnemyModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemyModel = db.EnemyModels.Find(id);
            if (enemyModel == null)
            {
                return HttpNotFound();
            }
            return View(enemyModel);
        }

        // GET: EnemyModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnemyModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EnemyHP,EnemyName,EnemyAttack,EnemyDescription,EnemyImageSrc,LevelModelId")] EnemyModel enemyModel)
        {
            if (ModelState.IsValid)
            {
                db.EnemyModels.Add(enemyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enemyModel);
        }

        // GET: EnemyModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemyModel = db.EnemyModels.Find(id);
            if (enemyModel == null)
            {
                return HttpNotFound();
            }
            return View(enemyModel);
        }

        // POST: EnemyModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EnemyHP,EnemyName,EnemyAttack,EnemyDescription,EnemyImageSrc,LevelModelId")] EnemyModel enemyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enemyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enemyModel);
        }

        // GET: EnemyModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemyModel = db.EnemyModels.Find(id);
            if (enemyModel == null)
            {
                return HttpNotFound();
            }
            return View(enemyModel);
        }

        // POST: EnemyModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnemyModel enemyModel = db.EnemyModels.Find(id);
            db.EnemyModels.Remove(enemyModel);
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
