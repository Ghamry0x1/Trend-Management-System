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
    public class DefBrokersController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefBrokers
        public ActionResult Index()
        {
            return View(db.DefBrokers.ToList());
        }

        // GET: DefBrokers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefBroker defBroker = db.DefBrokers.Find(id);
            if (defBroker == null)
            {
                return HttpNotFound();
            }
            return View(defBroker);
        }

        // GET: DefBrokers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefBrokers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrokerName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefBroker defBroker)
        {
            if (ModelState.IsValid)
            {
                db.DefBrokers.Add(defBroker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defBroker);
        }

        // GET: DefBrokers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefBroker defBroker = db.DefBrokers.Find(id);
            if (defBroker == null)
            {
                return HttpNotFound();
            }
            return View(defBroker);
        }

        // POST: DefBrokers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BrokerName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefBroker defBroker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defBroker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defBroker);
        }

        // GET: DefBrokers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefBroker defBroker = db.DefBrokers.Find(id);
            if (defBroker == null)
            {
                return HttpNotFound();
            }
            return View(defBroker);
        }

        // POST: DefBrokers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefBroker defBroker = db.DefBrokers.Find(id);
            db.DefBrokers.Remove(defBroker);
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
