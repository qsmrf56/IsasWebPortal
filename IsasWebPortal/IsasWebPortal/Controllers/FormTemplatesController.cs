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
    public class FormTemplatesController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: FormTemplates/FormTemplatesIndex
        public ActionResult FormTemplatesIndex()
        {
            var formTemplates = db.FormTemplatess.Include(f => f.formsTypes);
            return View(formTemplates.ToList());
        }



        public ActionResult ViewForm(long? id)
        {

            return RedirectToAction("FormDataCreateToViewOnly", "FormData", new { id = id });


        }

        /*
        // GET: FormTemplates/FormTemplatesDetails/5
        public ActionResult FormTemplatesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTemplates formTemplates = db.FormTemplatess.Find(id);
            if (formTemplates == null)
            {
                return HttpNotFound();
            }
            return View(formTemplates);
        }
        */

        // GET: FormTemplates/FormTemplatesCreate
        public ActionResult FormTemplatesCreate()
        {
            ViewBag.formTypeId = new SelectList(db.FormTypess, "Id", "formType");

           


            FormTemplates ft = new FormTemplates();
           // ft.formsTypes = db.FormTypess.First();

            return View(ft);
        }


         [HttpPost]
        public JsonResult getNumberOfAttributes(string formType)
        {

            //var db = new IsasWebPortal.Models.IsasWebPortalDataContext();
            //Client client = db.Clients.Find(employeeid);
            //db.Clients.Remove(client);
            //db.SaveChanges();
            

             var numberOfAttributes = db.FormTypess.SqlQuery("SELECT Id,numberOfAttributes,formType FROM FormTypes where formType ='"+ formType + "';").ToList();


            return Json(numberOfAttributes[0].numberOfAttributes.ToString());

        }

        
        // POST: FormTemplates/FormTemplatesCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTemplatesCreate(/*[Bind(Include = "formData,formType,Id,formName,attribute1,attribute2,attribute3,attribute4,attribute5,attribute6,attribute7,attribute8,attribute9,attribute10,attribute11,attribute12,attribute13,attribute14,attribute15,formTypeId")]*/ FormTemplates formTemplates)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                formTemplates.formsTypes = db.FormTypess.Find(formTemplates.formTypeId);
              
                db.FormTemplatess.Add(formTemplates);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a FormTemplates record");
                return RedirectToAction("FormTemplatesIndex");
               
            }

            ViewBag.formTypeId = new SelectList(db.FormTypess, "Id", "formType", formTemplates.formTypeId);
            DisplayErrorMessage();
            return View(formTemplates);
        }

        // GET: FormTemplates/FormTemplatesEdit/5
        public ActionResult FormTemplatesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTemplates formTemplates = db.FormTemplatess.Find(id);
            if (formTemplates == null)
            {
                return HttpNotFound();
            }
            ViewBag.formTypeId = new SelectList(db.FormTypess, "Id", "formType", formTemplates.formTypeId);
            return View(formTemplates);
        }

        // POST: FormTemplatesFormTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTemplatesEdit(/*[Bind(Include = "formData,formType,Id,formName,attribute1,attribute2,attribute3,attribute4,attribute5,attribute6,attribute7,attribute8,attribute9,attribute10,attribute11,attribute12,attribute13,attribute14,attribute15,formTypeId")]*/ FormTemplates formTemplates)
        {
            if (ModelState.IsValid)
            {
                formTemplates.formsTypes = db.FormTypess.Find(formTemplates.formTypeId);
                db.Entry(formTemplates).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a FormTemplates record");
                return RedirectToAction("FormTemplatesIndex");
            }
            ViewBag.formTypeId = new SelectList(db.FormTypess, "Id", "formType", formTemplates.formTypeId);
            DisplayErrorMessage();
            return View(formTemplates);
        }

        // GET: FormTemplates/FormTemplatesDelete/5
        public ActionResult FormTemplatesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTemplates formTemplates = db.FormTemplatess.Find(id);
            if (formTemplates == null)
            {
                return HttpNotFound();
            }
            return View(formTemplates);
        }

        // POST: FormTemplates/FormTemplatesDelete/5
        [HttpPost, ActionName("FormTemplatesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FormTemplatesDeleteConfirmed(int id)
        {
            FormTemplates formTemplates = db.FormTemplatess.Find(id);
            db.FormTemplatess.Remove(formTemplates);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a FormTemplates record");
            return RedirectToAction("FormTemplatesIndex");
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
