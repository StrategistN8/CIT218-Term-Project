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
    public class FeedbackModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FeedbackModels
        public ActionResult Index()
        {
            return View(db.FeedbackModels.ToList());
        }

        // GET: FeedbackModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackModel feedbackModel = db.FeedbackModels.Find(id);
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // GET: FeedbackModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FeedbackModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FeedbackEmail,FeedbackMessage")] FeedbackModel feedbackModel)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackModels.Add(feedbackModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedbackModel);
        }

        // GET: FeedbackModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackModel feedbackModel = db.FeedbackModels.Find(id);
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // POST: FeedbackModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FeedbackEmail,FeedbackMessage")] FeedbackModel feedbackModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedbackModel);
        }

        // GET: FeedbackModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackModel feedbackModel = db.FeedbackModels.Find(id);
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // POST: FeedbackModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackModel feedbackModel = db.FeedbackModels.Find(id);
            db.FeedbackModels.Remove(feedbackModel);
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
