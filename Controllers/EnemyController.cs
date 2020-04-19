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
    public class EnemyController : Controller
    {
        // Database:
        private AbyssContext db = new AbyssContext();

        /// <summary>
        /// Index (for private viewing)
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string sortOrder, string search)
        {
            ViewBag.SortName = String.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewBag.SortHP = sortOrder == "health" ? "healthDesc" : "health";

            var enemies = from e in db.Enemies
                          select e;
            if (!String.IsNullOrEmpty(search))
            {
                enemies = enemies.Where(e => e.EnemyName.Contains(search));
            }

            switch(sortOrder)
            {
                case "nameDesc":
                    enemies = enemies.OrderByDescending(e => e.EnemyName);
                    break;
                case "healthDesc":
                    enemies = enemies.OrderByDescending(e => e.EnemyHP);
                    break;
                case "health":
                    enemies = enemies.OrderBy(e => e.EnemyHP);
                    break;
                default:
                    enemies = enemies.OrderBy(e => e.EnemyName);
                    break;
            }

            return View(enemies.ToList());
        }

        /// <summary>
        /// Display Enemy Info Page (for public viewing).
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult DisplayInfo()
        {
            return View(db.Enemies.ToList());
        }

        /// <summary>
        /// POST Edit Display Info
        /// </summary>
        /// <param name="enemyModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplayInfo([Bind(Include = "Id,EnemyHP,EnemyName,EnemyAttack,EnemyDescription,EnemyImageSrc")] EnemyModel enemyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enemyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayInfo");
            }

            return View(enemyModel);
        }

        /// <summary>
        /// Edit for the Display Info page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EditDisplayInfo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemy = db.Enemies.Find(id);
            if (enemy == null)
            {
                return HttpNotFound();
            }

            return View(enemy);
        }

        /// <summary>
        /// Details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemy = db.Enemies.Find(id);
            if (enemy == null)
            {
                return HttpNotFound();
            }
            return View(enemy);
        }

        /// <summary>
        /// Create.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnemyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EnemyHP,EnemyName,EnemyAttack,EnemyDescription,EnemyImageSrc")] EnemyModel enemyModel)
        {
            if (ModelState.IsValid)
            {
                db.Enemies.Add(enemyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enemyModel);
        }

        /// <summary>
        /// Edit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemyModel = db.Enemies.Find(id);
            if (enemyModel == null)
            {
                return HttpNotFound();
            }
            return View(enemyModel);
        }

        /// <summary>
        /// POST Edit with anti-forgery token.
        /// </summary>
        /// <param name="enemyModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EnemyHP,EnemyName,EnemyAttack,EnemyDescription,EnemyImageSrc")] EnemyModel enemyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enemyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enemyModel);
        }

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnemyModel enemyModel = db.Enemies.Find(id);
            if (enemyModel == null)
            {
                return HttpNotFound();
            }
            return View(enemyModel);
        }

        /// <summary>
        /// Delete Confirmation Page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnemyModel enemyModel = db.Enemies.Find(id);
            db.Enemies.Remove(enemyModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Method to dispose items once connection is closed.
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
