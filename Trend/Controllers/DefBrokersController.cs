using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Trend.Controllers
{
    [Route("Brokers/{action}")]
    public class DefBrokersController : Controller
    {
        private TrendEntities db = new TrendEntities();

        // GET: DefBrokers
        public ActionResult Index()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
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
            defBroker.ContactList = db.DefContacts.Where(x => x.FK_DefContactReferenceTypeID == 2 && x.FK_ReferenceID == id).ToList();

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

        //create list of notification items
        List<SelectListItem> notificationList = new List<SelectListItem>();

        // POST: DefBrokers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BrokerName,WebSite,Email,Address,Industry,FK_CreatorID,CreationDate,LastModifiedDate")] DefBroker defBroker)
        {
            if (ModelState.IsValid)
            {
                defBroker.FK_CreatorID = User.Identity.GetUserId();
                DateTime nowTimestamp = DateTime.Now;
                defBroker.CreationDate = nowTimestamp;
                defBroker.LastModifiedDate = nowTimestamp;

                db.DefBrokers.Add(defBroker);
                db.SaveChanges();

                String message = HttpContext.User.Identity.Name + " has created a new Broker";
                //System.Diagnostics.Debug.WriteLine(loggedUsername);
                
                //call the function with the new object to be created
                createNotificationObject(message, notificationList);
                //createEmailObject("jash.kaydn@lndex.org", "Trend Notification!", message);

                return RedirectToAction("Index");
            }

            return View(defBroker);
        }

        public void createNotificationObject(String message, List<SelectListItem> notificationList)
        {
            //create the object
            SelectListItem item = new SelectListItem() { Text = message };
            //add it to the list
            notificationList.Add(item);
            //send the whole list to the brokers view to be rendered
            ViewBag.notificationList = notificationList;
            //log list
            foreach (SelectListItem i in notificationList)
            {
                System.Diagnostics.Debug.WriteLine(i.Text);
            }
            
        }

        public void createEmailObject(String receiver, String subject, String message)
        {
            var senderEmail = new MailAddress("jash.kaydn@lndex.org", "Jash");
            var receiverEmail = new MailAddress(receiver, "Receiver");
            var password = "wetab5X$";
            var sub = subject;
            var body = message;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(mess);
            }

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
                defBroker.FK_CreatorID = User.Identity.GetUserId();
                defBroker.LastModifiedDate = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defBroker);
        }

        public JsonResult isBrokerNameExist(string brokerName, int? Id)
        {
            var validateName = db.DefBrokers.FirstOrDefault
                                (x => x.BrokerName == brokerName && x.ID != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
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
