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
using PagedList;

namespace AbyssRunSite.Controllers
{
    [Authorize]
    public class LevelController : Controller
    {
        private AbyssContext db = new AbyssContext();

        // GET: Level
        public ActionResult Index()
        {
            return View(db.Levels.ToList());
        }

        // GET: Level/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.Levels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        /// <summary>
        /// Display Item Info Page (for public viewing).
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult DisplayInfo(int? page)
        {
            LevelPopulatonViewModel levelInfo = new LevelPopulatonViewModel();

            levelInfo.LevelData = db.Levels.ToList();
            levelInfo.EnemyData = db.Enemies.ToList();
            levelInfo.ItemData = db.Items.ToList();
                       
            return View(levelInfo);
        }

        // GET: Level/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Level/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LevelName,LevelDescription")] LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                db.Levels.Add(levelModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelModel);
        }

        // GET: Level/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.Levels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: Level/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LevelName,LevelDescription")] LevelModel levelModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelModel);
        }

        // GET: Level/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelModel levelModel = db.Levels.Find(id);
            if (levelModel == null)
            {
                return HttpNotFound();
            }
            return View(levelModel);
        }

        // POST: Level/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelModel levelModel = db.Levels.Find(id);
            db.Levels.Remove(levelModel);
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
