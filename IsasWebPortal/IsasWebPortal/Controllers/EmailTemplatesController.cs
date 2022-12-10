using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsasWebPortal.Models;
using IsasWebPortal.IsasWebPortal.Models;

namespace IsasWebPortal.Controllers
{
    public class EmailTemplatesController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: EmailTemplates/EmailTemplatesIndex
        public ActionResult EmailTemplatesIndex()
        {
            return View(db.EmailTemplatess.ToList());
        }

        /*
        // GET: EmailTemplates/EmailTemplatesDetails/5
        public ActionResult EmailTemplatesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = db.EmailTemplatess.Find(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }
        */

        // GET: EmailTemplates/EmailTemplatesCreate
        public ActionResult EmailTemplatesCreate()
        {
            return View();
        }

        // POST: EmailTemplates/EmailTemplatesCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailTemplatesCreate([Bind(Include = "emailCommunicationLogs,Id,templateName,Body")] EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                db.EmailTemplatess.Add(emailTemplates);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a EmailTemplates record");
                return RedirectToAction("EmailTemplatesIndex");
            }

            DisplayErrorMessage();
            return View(emailTemplates);
        }

        // GET: EmailTemplates/EmailTemplatesEdit/5
        public ActionResult EmailTemplatesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = db.EmailTemplatess.Find(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }

        // POST: EmailTemplatesEmailTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailTemplatesEdit([Bind(Include = "emailCommunicationLogs,Id,templateName,Body")] EmailTemplates emailTemplates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailTemplates).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a EmailTemplates record");
                return RedirectToAction("EmailTemplatesIndex");
            }
            DisplayErrorMessage();
            return View(emailTemplates);
        }

        // GET: EmailTemplates/EmailTemplatesDelete/5
        public ActionResult EmailTemplatesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailTemplates emailTemplates = db.EmailTemplatess.Find(id);
            if (emailTemplates == null)
            {
                return HttpNotFound();
            }
            return View(emailTemplates);
        }

        // POST: EmailTemplates/EmailTemplatesDelete/5
        [HttpPost, ActionName("EmailTemplatesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EmailTemplatesDeleteConfirmed(int id)
        {
            EmailTemplates emailTemplates = db.EmailTemplatess.Find(id);
            db.EmailTemplatess.Remove(emailTemplates);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a EmailTemplates record");
            return RedirectToAction("EmailTemplatesIndex");
        }

        private void DisplaySuccessMessage(string msgText)
        {
            TempData["SuccessMessage"] = msgText;
        }

        private void DisplayErrorMessage()
        {
            TempData["ErrorMessage"] = "Save changes was unsuccessful.";
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
