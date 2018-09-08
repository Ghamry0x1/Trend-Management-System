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
    [Route("Employees/{action}")]
    public class HREmployeesController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: HREmployees
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
                return View(db.HREmployees.ToList());
        }


        // GET: HREmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HREmployee hREmployee = db.HREmployees.Find(id);
            if (hREmployee == null)
            {
                return HttpNotFound();
            }
            return View(hREmployee);
        }

        // GET: HREmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HREmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeName,Surname,BirthDate,IdentificationNumber,Address,Telephone")] HREmployee hREmployee)
        {
            if (ModelState.IsValid)
            {
                db.HREmployees.Add(hREmployee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(hREmployee);
        }

        // GET: HREmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HREmployee hREmployee = db.HREmployees.Find(id);
            if (hREmployee == null)
            {
                return HttpNotFound();
            }
            return View(hREmployee);
        }

        // POST: HREmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeName,Surname,BirthDate,IdentificationNumber,Address,Telephone")] HREmployee hREmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hREmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hREmployee);
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
