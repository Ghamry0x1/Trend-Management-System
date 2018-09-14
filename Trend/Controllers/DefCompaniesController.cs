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
    [Route("Companies/{action}")]
    public class DefCompaniesController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefCompanies
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
                return View(db.DefCompanies.ToList());
        }

        // GET: DefCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefCompany defCompany = db.DefCompanies.Find(id);
            if (defCompany == null)
            {
                return HttpNotFound();
            }
            return View(defCompany);
        }

        // GET: DefCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DefCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,CompanyAddress")] DefCompany defCompany)
        {
            if (ModelState.IsValid)
            {
                db.DefCompanies.Add(defCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defCompany);
        }

        // GET: DefCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefCompany defCompany = db.DefCompanies.Find(id);
            if (defCompany == null)
            {
                return HttpNotFound();
            }
            return View(defCompany);
        }

        // POST: DefCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,CompanyAddress")] DefCompany defCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defCompany);
        }

        // GET: DefCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefCompany defCompany = db.DefCompanies.Find(id);
            if (defCompany == null)
            {
                return HttpNotFound();
            }
            return View(defCompany);
        }

        // POST: DefCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefCompany defCompany = db.DefCompanies.Find(id);
            db.DefCompanies.Remove(defCompany);
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
