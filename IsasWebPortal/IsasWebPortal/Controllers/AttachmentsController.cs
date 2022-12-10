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
    public class AttachmentsController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: Attachments/AttachmentsIndex
        public ActionResult AttachmentsIndex()
        {
            var attachments = db.Attachmentss.Include(a => a.emailCommunicationLogs);
            return PartialView(attachments.ToList());
        }

        /*
        // GET: Attachments/AttachmentsDetails/5
        public ActionResult AttachmentsDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachments attachments = db.Attachmentss.Find(id);
            if (attachments == null)
            {
                return HttpNotFound();
            }
            return View(attachments);
        }
        */

        // GET: Attachments/AttachmentsCreate
        public ActionResult AttachmentsCreate()
        {
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body");
            return PartialView();
        }


        // GET: Attachments/AttachmentsCreate
        public ActionResult AttachmentsCreateView()//(int emailcommlogid)
        {
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body");
            Attachments att = new Attachments();
            //att.emailCommunicationLogId = emailcommlogid;
            return PartialView();
        }

        // POST: Attachments/AttachmentsCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttachmentsCreateView(/*[Bind(Include = "emailCommunicationLogs,Id,attachmentPath,emailCommunicationLogId")]*/ Attachments attachments)
        {
            if (ModelState.IsValid)
            {
                db.Attachmentss.Add(attachments);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Attachments record");
                return RedirectToAction("AttachmentsIndex");
            }

            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", attachments.emailCommunicationLogId);
            DisplayErrorMessage();
            return View(attachments);
        }

        // GET: Attachments/AttachmentsEdit/5
        public ActionResult AttachmentsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachments attachments = db.Attachmentss.Find(id);
            if (attachments == null)
            {
                return HttpNotFound();
            }
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", attachments.emailCommunicationLogId);
            return View(attachments);
        }

        // POST: AttachmentsAttachments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttachmentsEdit([Bind(Include = "emailCommunicationLogs,Id,attachmentPath,emailCommunicationLogId")] Attachments attachments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachments).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Attachments record");
                return RedirectToAction("AttachmentsIndex");
            }
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", attachments.emailCommunicationLogId);
            DisplayErrorMessage();
            return View(attachments);
        }

        // GET: Attachments/AttachmentsDelete/5
        public ActionResult AttachmentsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attachments attachments = db.Attachmentss.Find(id);
            if (attachments == null)
            {
                return HttpNotFound();
            }
            return View(attachments);
        }

        // POST: Attachments/AttachmentsDelete/5
        [HttpPost, ActionName("AttachmentsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AttachmentsDeleteConfirmed(int id)
        {
            Attachments attachments = db.Attachmentss.Find(id);
            db.Attachmentss.Remove(attachments);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Attachments record");
            return RedirectToAction("AttachmentsIndex");
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
