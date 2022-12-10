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
    public class FormLinksController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: FormLinks/FormLinksIndex
        public ActionResult FormLinksIndex()
        {
            var formLinks = db.formLinks.Include(f => f.emailcommlogs).Include(f => f.formTemplatess);
            return View(formLinks.ToList());
        }

        /*
        // GET: FormLinks/FormLinksDetails/5
        public ActionResult FormLinksDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormLinks formLinks = db.formLinks.Find(id);
            if (formLinks == null)
            {
                return HttpNotFound();
            }
            return View(formLinks);
        }
        */

        [HttpGet]
        // GET: FormLinks/FormLinksCreate
        public ActionResult FormLinksCreate()
        {
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body");

            ViewBag.formDataId = new SelectList(db.FormDatas, "formDataId", "attribute1Data");
            ViewBag.formTemplatesId = new SelectList(db.FormTemplatess, "Id", "formName");

            FormLinks fl = new FormLinks();

            return PartialView(fl);
        }


        //simply return URLs to be appended to email body.

        [HttpPost]
        public JsonResult formLinksCreatePreliminaries(int emailCommunicationLogId,int formTemplatesId,string formLink, bool isPath)
        {

            FormLinks formlink = new FormLinks();
            formlink.emailCommunicationLogId = emailCommunicationLogId;
            formlink.isPath = isPath;

            if (formTemplatesId != 0)
            {
                formlink.formTemplatess = db.FormTemplatess.Find(formTemplatesId);
                formlink.formTemplatesId = formTemplatesId;
            }
            else
            {
                formlink.formTemplatesId = db.FormTemplatess.First().Id;
            }

            if (formLink == "")
            {
                formlink.formLink = CreateFormLink(formTemplatesId, emailCommunicationLogId);
            }
            else
            { formlink.formLink = formLink; }

            if(FormLinksCreate(formlink))
            { return Json("Success"); }
            else
            {
                return Json("Failed");
            };
          
           
        }


        public string CreateFormLink(int templateId, int emailCommLogid)
        {

            string url = "http://localhost:5216/FormData/FormDataCreate/?templateId=" + templateId + "&emailcommlogId=" + emailCommLogid;

            return url;
        }


        // POST: FormLinks/FormLinksCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    
       // [HttpPost]
       // [ValidateAntiForgeryToken]
        public bool FormLinksCreate([Bind(Include = "formLink,emailCommunicationLogId,formTemplatesId")] FormLinks formLinks)
        {


            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                db.formLinks.Add(formLinks);

//before saving this record we'll have to save the email record for insertion integrity.
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                  
                }

                return true;
               // DisplaySuccessMessage("Has append a FormLinks record");
               // return RedirectToAction("FormLinksIndex");
            }

           // ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", formLinks.emailCommunicationLogId);
           // ViewBag.formDataId = new SelectList(db.FormDatas, "formDataId", "attribute1Data", formLinks.formDataId);
          //  ViewBag.formTemplatesId = new SelectList(db.FormTemplatess, "Id", "formName", formLinks.formTemplatesId);
           // DisplayErrorMessage();
           // return View(formLinks);

            return false;
        }

        // GET: FormLinks/FormLinksEdit/5
        public ActionResult FormLinksEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormLinks formLinks = db.formLinks.Find(id);
            if (formLinks == null)
            {
                return HttpNotFound();
            }
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", formLinks.emailCommunicationLogId);
           // ViewBag.formDataId = new SelectList(db.FormDatas, "formDataId", "attribute1Data", formLinks.formDataId);
            ViewBag.formTemplatesId = new SelectList(db.FormTemplatess, "Id", "formName", formLinks.formTemplatesId);
            return View(formLinks);
        }

        // POST: FormLinksFormLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormLinksEdit([Bind(Include = "emailcommlogs,formDatas,formTemplatess,id,formLink,emailCommunicationLogId,formDataId,formTemplatesId")] FormLinks formLinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formLinks).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a FormLinks record");
                return RedirectToAction("FormLinksIndex");
            }
            ViewBag.emailCommunicationLogId = new SelectList(db.EmailCommunicationLogs, "Id", "Body", formLinks.emailCommunicationLogId);
           // ViewBag.formDataId = new SelectList(db.FormDatas, "formDataId", "attribute1Data", formLinks.formDataId);
            ViewBag.formTemplatesId = new SelectList(db.FormTemplatess, "Id", "formName", formLinks.formTemplatesId);
            DisplayErrorMessage();
            return View(formLinks);
        }

        // GET: FormLinks/FormLinksDelete/5
        public ActionResult FormLinksDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormLinks formLinks = db.formLinks.Find(id);
            if (formLinks == null)
            {
                return HttpNotFound();
            }
            return View(formLinks);
        }

        // POST: FormLinks/FormLinksDelete/5
        //deleting wrt emailcommunicationlogid
        [HttpPost, ActionName("FormLinksDelete")]
       // [ValidateAntiForgeryToken]
        public JsonResult FormLinksDeleteConfirmed(int id)
        {
            FormLinks[] formLinks = db.formLinks.Where(x => x.emailCommunicationLogId == id).ToArray();//.Find(id);
            
            int c = formLinks.Count();

            for (int i = 0; i < c;i++ )
            {
            db.formLinks.Remove(formLinks[i]);
            db.SaveChanges();
            
        }
            return Json("Success");
            //DisplaySuccessMessage("Has delete a FormLinks record");
            //return RedirectToAction("FormLinksIndex");
           
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
