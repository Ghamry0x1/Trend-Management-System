using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trend;
 namespace Trend.Controllers
{
    public class DefContactsController : Controller
    {
        private TrendEntities db = new TrendEntities();
         // GET: DefContacts
        public ActionResult Index()
        {
            var defContacts = db.DefContacts.Include(d => d.DefContactReferenceType);
            return View(defContacts.ToList());
        }
         // GET: DefContacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefContact defContact = db.DefContacts.Find(id);
            if (defContact == null)
            {
                return HttpNotFound();
            }
            return View(defContact);
        }
         // GET: DefContacts/Create
        public ActionResult Create()
        {
            ViewBag.FK_DefContactReferenceTypeID = new SelectList(db.DefContactReferenceTypes, "ID", "ContactReferenceTypeName");
            return View();
        }
         // POST: DefContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_DefContactReferenceTypeID,FK_ReferenceID,FullName,Email,Address,Position,Telephone,Telephone1,Mobile,Mobile1,Fax,FK_CreatorID,CreationDate,LastModifiedDate")] DefContact defContact)
        {
            if (ModelState.IsValid)
            {
                db.DefContacts.Add(defContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
             ViewBag.FK_DefContactReferenceTypeID = new SelectList(db.DefContactReferenceTypes, "ID", "ContactReferenceTypeName", defContact.FK_DefContactReferenceTypeID);
            return View(defContact);
        }
         // GET: DefContacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefContact defContact = db.DefContacts.Find(id);
            if (defContact == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_DefContactReferenceTypeID = new SelectList(db.DefContactReferenceTypes, "ID", "ContactReferenceTypeName", defContact.FK_DefContactReferenceTypeID);
            return View(defContact);
        }
         // POST: DefContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_DefContactReferenceTypeID,FK_ReferenceID,FullName,Email,Address,Position,Telephone,Telephone1,Mobile,Mobile1,Fax,FK_CreatorID,CreationDate,LastModifiedDate")] DefContact defContact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("");
            }
            ViewBag.FK_DefContactReferenceTypeID = new SelectList(db.DefContactReferenceTypes, "ID", "ContactReferenceTypeName", defContact.FK_DefContactReferenceTypeID);
            return View(defContact);
        }
         // GET: DefContacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DefContact defContact = db.DefContacts.Find(id);
            if (defContact == null)
            {
                return HttpNotFound();
            }
            return View(defContact);
        }
         // POST: DefContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DefContact defContact = db.DefContacts.Find(id);
            db.DefContacts.Remove(defContact);
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