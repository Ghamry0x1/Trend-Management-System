using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trend;
using Trend.Models;

namespace Trend.Controllers
{
    [Route("Clients/{action}")]
    public class DefClientsController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefClients
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
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
                defClient.FK_CreatorID = User.Identity.GetUserId();
                DateTime nowTimestamp = DateTime.Now;
                defClient.CreationDate = nowTimestamp;
                defClient.LastModifiedDate = nowTimestamp;

                db.DefClients.Add(defClient);

                /////////////
                Notif a = new Notif();
                a.Message = "User " + User.Identity.GetUserName().ToString() + " Added a new Client: " + defClient.ClientName.ToString();
                db.Notifs.Add(a);
                ///////////

                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
                defClient.FK_CreatorID = User.Identity.GetUserId();
                defClient.LastModifiedDate = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defClient);
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
