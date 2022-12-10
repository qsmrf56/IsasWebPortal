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
    public class FormDataController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: FormData/FormDataIndex
        public ActionResult FormDataIndex()
        {
            return View(db.FormDatas.ToList());
        }

        public ActionResult ThankYouView()
        {

            return View();


        }

        /*
        // GET: FormData/FormDataDetails/5
        public ActionResult FormDataDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormData formData = db.FormDatas.Find(id);
            if (formData == null)
            {
                return HttpNotFound();
            }
            return View(formData);
        }
        */

        // GET: FormData/FormDataCreate

        //FormDataCreateToViewOnly: only to view form, can't submit this form.

        public ActionResult FormDataCreateToViewOnly(int? id)
        {

            FormTemplates ft = db.FormTemplatess.Find(id);
            int numOfAtt = ft.formsTypes.numberOfAttributes;
            ViewBag.NumOfAtt = numOfAtt;


            FormData fd = new FormData();
            fd.formTemplate = ft;
            fd.formTemplateId = ft.Id;
            
                
          
                

            return View(fd);


        }


        // GET: FormData/FormDataCreate
        public ActionResult FormDataCreate(int templateId, int emailcommlogId)
        {

            FormTemplates ft = db.FormTemplatess.Find(templateId);
            int numOfAtt = ft.formsTypes.numberOfAttributes;
            ViewBag.NumOfAtt = numOfAtt;


            FormData fd = new FormData();
            fd.formTemplate = ft;
            fd.formTemplateId = ft.Id;
            fd.emailCommLogId = emailcommlogId;
            
                
          
                

            return View(fd);


        }

        // POST: FormData/FormDataCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormDataCreate(/*[Bind(Include = "formDataId,attribute1Data,attribute2Data,attribute3Data,attribute4Data,attribute5Data,attribute6Data,attribute7Data,attribute8Data,attribute9Data,attribute10Data,attribute11Data,attribute12Data,attribute13Data,attribute14Data,attribute15Data")]*/ FormData formData)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                db.FormDatas.Add(formData);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a FormData record");
                return RedirectToAction("ThankYouView");
            }

            DisplayErrorMessage();
            return View(formData);
        }

        // GET: FormData/FormDataEdit/5
        public ActionResult FormDataEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormData formData = db.FormDatas.Find(id);
            if (formData == null)
            {
                return HttpNotFound();
            }
            return View(formData);
        }

        // POST: FormDataFormData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormDataEdit([Bind(Include = "formDataId,attribute1Data,attribute2Data,attribute3Data,attribute4Data,attribute5Data,attribute6Data,attribute7Data,attribute8Data,attribute9Data,attribute10Data,attribute11Data,attribute12Data,attribute13Data,attribute14Data,attribute15Data")] FormData formData)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                db.Entry(formData).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a FormData record");
                return RedirectToAction("FormDataIndex");
            }
            DisplayErrorMessage();
            return View(formData);
        }

        // GET: FormData/FormDataDelete/5
        public ActionResult FormDataDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormData formData = db.FormDatas.Find(id);
            if (formData == null)
            {
                return HttpNotFound();
            }
            return View(formData);
        }

        // POST: FormData/FormDataDelete/5
        [HttpPost, ActionName("FormDataDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FormDataDeleteConfirmed(int id)
        {
            FormData formData = db.FormDatas.Find(id);
            db.FormDatas.Remove(formData);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a FormData record");
            return RedirectToAction("FormDataIndex");
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
