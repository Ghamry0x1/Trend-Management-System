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
    [Route("Lead/{action}")]
    public class LedLeadsController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: LedLeads
        public ActionResult Index()
        {
            var ledLeads = db.LedLeads.Include(l => l.DefBroker).Include(l => l.DefClient).Include(l => l.DefCompany).Include(l => l.DefContact).Include(l => l.DefModuleStatu).Include(l => l.HREmployee).Include(l => l.HREmployee1).Include(l => l.LedLeadSource);
            return View(ledLeads.ToList());
        }

        // GET: LedLeads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedLead ledLead = db.LedLeads.Find(id);
            if (ledLead == null)
            {
                return HttpNotFound();
            }
            return View(ledLead);
        }

        // GET: LedLeads/Create
        public ActionResult Create()
        {
            ViewBag.FK_DefBrokerID = new SelectList(db.DefBrokers, "ID", "BrokerName");
            ViewBag.FK_DefClientID = new SelectList(db.DefClients, "ID", "ClientName");
            ViewBag.FK_DefCompanyID = new SelectList(db.DefCompanies, "ID", "CompanyName");
            ViewBag.FK_BrokerDefContactID = new SelectList(db.DefContacts, "ID", "FullName");
            ViewBag.FK_DefModuleStatusID = new SelectList(db.DefModuleStatus, "ID", "ModuleStatusName");
            ViewBag.FK_AssignedByHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName");
            ViewBag.FK_AssignedToHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName");
            ViewBag.FK_LedLeadSourceID = new SelectList(db.LedLeadSources, "ID", "LeadSourceName");
            return View();
        }

        // POST: LedLeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FK_DefCompanyID,LeadSerial,LeadName,LeadDate,NewOfficeSize,NewOfficeAddress,ExpectedBudget,FK_DefClientID,FK_DefBrokerID,FK_BrokerDefContactID,FK_DefModuleStatusID,FK_LedLeadSourceID,FK_AssignedByHREmployeeID,FK_AssignedToHREmployeeID,LeadAssignedDate,Notes,FK_CreatorID,CreationDate,LastModifiedDate")] LedLead ledLead)
        {
            if (ModelState.IsValid)
            {
                db.LedLeads.Add(ledLead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_DefBrokerID = new SelectList(db.DefBrokers, "ID", "BrokerName", ledLead.FK_DefBrokerID);
            ViewBag.FK_DefClientID = new SelectList(db.DefClients, "ID", "ClientName", ledLead.FK_DefClientID);
            ViewBag.FK_DefCompanyID = new SelectList(db.DefCompanies, "ID", "CompanyName", ledLead.FK_DefCompanyID);
            ViewBag.FK_BrokerDefContactID = new SelectList(db.DefContacts, "ID", "FullName", ledLead.FK_BrokerDefContactID);
            ViewBag.FK_DefModuleStatusID = new SelectList(db.DefModuleStatus, "ID", "ModuleStatusName", ledLead.FK_DefModuleStatusID);
            ViewBag.FK_AssignedByHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedByHREmployeeID);
            ViewBag.FK_AssignedToHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedToHREmployeeID);
            ViewBag.FK_LedLeadSourceID = new SelectList(db.LedLeadSources, "ID", "LeadSourceName", ledLead.FK_LedLeadSourceID);
            return View(ledLead);
        }

        // GET: LedLeads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedLead ledLead = db.LedLeads.Find(id);
            if (ledLead == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_DefBrokerID = new SelectList(db.DefBrokers, "ID", "BrokerName", ledLead.FK_DefBrokerID);
            ViewBag.FK_DefClientID = new SelectList(db.DefClients, "ID", "ClientName", ledLead.FK_DefClientID);
            ViewBag.FK_DefCompanyID = new SelectList(db.DefCompanies, "ID", "CompanyName", ledLead.FK_DefCompanyID);
            ViewBag.FK_BrokerDefContactID = new SelectList(db.DefContacts, "ID", "FullName", ledLead.FK_BrokerDefContactID);
            ViewBag.FK_DefModuleStatusID = new SelectList(db.DefModuleStatus, "ID", "ModuleStatusName", ledLead.FK_DefModuleStatusID);
            ViewBag.FK_AssignedByHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedByHREmployeeID);
            ViewBag.FK_AssignedToHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedToHREmployeeID);
            ViewBag.FK_LedLeadSourceID = new SelectList(db.LedLeadSources, "ID", "LeadSourceName", ledLead.FK_LedLeadSourceID);
            return View(ledLead);
        }

        // POST: LedLeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FK_DefCompanyID,LeadSerial,LeadName,LeadDate,NewOfficeSize,NewOfficeAddress,ExpectedBudget,FK_DefClientID,FK_DefBrokerID,FK_BrokerDefContactID,FK_DefModuleStatusID,FK_LedLeadSourceID,FK_AssignedByHREmployeeID,FK_AssignedToHREmployeeID,LeadAssignedDate,Notes,FK_CreatorID,CreationDate,LastModifiedDate")] LedLead ledLead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ledLead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_DefBrokerID = new SelectList(db.DefBrokers, "ID", "BrokerName", ledLead.FK_DefBrokerID);
            ViewBag.FK_DefClientID = new SelectList(db.DefClients, "ID", "ClientName", ledLead.FK_DefClientID);
            ViewBag.FK_DefCompanyID = new SelectList(db.DefCompanies, "ID", "CompanyName", ledLead.FK_DefCompanyID);
            ViewBag.FK_BrokerDefContactID = new SelectList(db.DefContacts, "ID", "FullName", ledLead.FK_BrokerDefContactID);
            ViewBag.FK_DefModuleStatusID = new SelectList(db.DefModuleStatus, "ID", "ModuleStatusName", ledLead.FK_DefModuleStatusID);
            ViewBag.FK_AssignedByHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedByHREmployeeID);
            ViewBag.FK_AssignedToHREmployeeID = new SelectList(db.HREmployees, "ID", "EmployeeName", ledLead.FK_AssignedToHREmployeeID);
            ViewBag.FK_LedLeadSourceID = new SelectList(db.LedLeadSources, "ID", "LeadSourceName", ledLead.FK_LedLeadSourceID);
            return View(ledLead);
        }

        // GET: LedLeads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LedLead ledLead = db.LedLeads.Find(id);
            if (ledLead == null)
            {
                return HttpNotFound();
            }
            return View(ledLead);
        }

        // POST: LedLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LedLead ledLead = db.LedLeads.Find(id);
            db.LedLeads.Remove(ledLead);
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
