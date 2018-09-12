using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Trend
{
    [Route("Landlords/{action}")]
    public class DefLandlordsController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefLandlords
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
                return View(db.DefLandlords.ToList());
        }

        // GET: DefLandlords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefLandlord defLandlord = db.DefLandlords.Find(id);
            if (defLandlord == null)
            {
                return HttpNotFound();
            }
            return View(defLandlord);
        }

        // GET: DefLandlords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefLandlords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LandlordName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefLandlord defLandlord)
        {
            if (ModelState.IsValid)
            {
                defLandlord.FK_CreatorID = User.Identity.GetUserId();
                DateTime nowTimestamp = DateTime.Now;
                defLandlord.CreationDate = nowTimestamp;
                defLandlord.LastModifiedDate = nowTimestamp;

                db.DefLandlords.Add(defLandlord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defLandlord);
        }

        // GET: DefLandlords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefLandlord defLandlord = db.DefLandlords.Find(id);
            if (defLandlord == null)
            {
                return HttpNotFound();
            }
            return View(defLandlord);
        }

        // POST: DefLandlords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LandlordName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefLandlord defLandlord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defLandlord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defLandlord);
        }

        // GET: DefLandlords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefLandlord defLandlord = db.DefLandlords.Find(id);
            if (defLandlord == null)
            {
                return HttpNotFound();
            }
            return View(defLandlord);
        }

        // POST: DefLandlords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefLandlord defLandlord = db.DefLandlords.Find(id);
            db.DefLandlords.Remove(defLandlord);
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
