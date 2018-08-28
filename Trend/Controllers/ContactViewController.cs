using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
 namespace Trend.Controllers
{
    public class ContactViewController : Controller
    {
        private TrendEntities db = new TrendEntities();
        // GET: ContactView
        public ActionResult Index()
        {
             return View();
        }
        public String GetCurrUserID()
        {
            // Get actual user ID later.
            return "1";
        }
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
            return View(defContact);
        }
         public ActionResult Edit([Bind(Include = "ID,FK_DefContactReferenceTypeID,FK_ReferenceID,FullName,Email,Address,Position,Telephone,Telephone1,Mobile,Mobile1,Fax,ContactReferenceTypeName")] DefContact defcontact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defcontact).State = EntityState.Modified;
                defcontact.FK_CreatorID = GetCurrUserID();
                 DateTime nowTimestamp = DateTime.Now;
                defcontact.LastModifiedDate = nowTimestamp;
                 db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defcontact);
        }
     }
} 