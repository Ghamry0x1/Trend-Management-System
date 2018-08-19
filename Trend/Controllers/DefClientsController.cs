using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trend;
using Trend.Models;

namespace Trend.Controllers
{
    public class DefClientsController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefClients
        public ActionResult Index()
        {
            return View(db.DefClients.ToList());
        }

        // GET: DefClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefClient defClient = db.DefClients.Find(id);
            if (defClient == null)
            {
                return HttpNotFound();
            }
            return View(defClient);
        }

        // GET: DefClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ClientName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefClient defClient)
        {
            if (ModelState.IsValid)
            {
                defClient.FK_CreatorID = GetCurrUserID();
                DateTime nowTimestamp = DateTime.Now; //(DateTime)SqlDateTime.MinValue;
                defClient.CreationDate = nowTimestamp;
                defClient.LastModifiedDate = nowTimestamp;

                db.DefClients.Add(defClient);
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("111111111");
                return RedirectToAction("Index");
            }
            //var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

            return View(defClient);
        }

        // GET: DefClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefClient defClient = db.DefClients.Find(id);
            if (defClient == null)
            {
                return HttpNotFound();
            }
            return View(defClient);
        }

        // POST: DefClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ClientName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefClient defClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defClient).State = EntityState.Modified;
                defClient.FK_CreatorID = GetCurrUserID();

                DateTime nowTimestamp = DateTime.Now;
                // defClient.CreationDate = db.Entry(defClient).Entity.CreationDate;
                defClient.LastModifiedDate = nowTimestamp;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defClient);
        }

        private String GetCurrUserID()
        {
            // Get actual user ID later.
            return "1";
        }

        // GET: DefClients/Delete/5
        /*public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefClient defClient = db.DefClients.Find(id);
            if (defClient == null)
            {
                return HttpNotFound();
            }
            return View(defClient);
        }

        // POST: DefClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefClient defClient = db.DefClients.Find(id);
            db.DefClients.Remove(defClient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

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
