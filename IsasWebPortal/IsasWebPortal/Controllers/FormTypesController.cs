using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IsasWebPortal.Models;

namespace IsasWebPortal.Controllers
{
    public class FormTypesController : Controller
    {
        private IsasWebPortal.Models.IsasWebPortalDataContext db = new IsasWebPortal.Models.IsasWebPortalDataContext();

        // GET: FormTypes/FormTypesIndex
        public ActionResult FormTypesIndex()
        {
            return View(db.FormTypess.ToList());
        }

        /*
        // GET: FormTypes/FormTypesDetails/5
        public ActionResult FormTypesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTypes formTypes = db.FormTypess.Find(id);
            if (formTypes == null)
            {
                return HttpNotFound();
            }
            return View(formTypes);
        }
        */

        // GET: FormTypes/FormTypesCreate
        public ActionResult FormTypesCreate()
        {
            return View();
        }

        // POST: FormTypes/FormTypesCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTypesCreate([Bind(Include = "formTemplates,Id,formType,numberOfAttributes")] FormTypes formTypes)
        {
            if (ModelState.IsValid)
            {
                db.FormTypess.Add(formTypes);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a FormTypes record");
                return RedirectToAction("FormTypesIndex");
            }

            DisplayErrorMessage();
            return View(formTypes);
        }

        // GET: FormTypes/FormTypesEdit/5
        public ActionResult FormTypesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTypes formTypes = db.FormTypess.Find(id);
            if (formTypes == null)
            {
                return HttpNotFound();
            }
            return View(formTypes);
        }

        // POST: FormTypesFormTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FormTypesEdit([Bind(Include = "formTemplates,Id,formType,numberOfAttributes")] FormTypes formTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formTypes).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a FormTypes record");
                return RedirectToAction("FormTypesIndex");
            }
            DisplayErrorMessage();
            return View(formTypes);
        }

        // GET: FormTypes/FormTypesDelete/5
        public ActionResult FormTypesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormTypes formTypes = db.FormTypess.Find(id);
            if (formTypes == null)
            {
                return HttpNotFound();
            }
            return View(formTypes);
        }

        // POST: FormTypes/FormTypesDelete/5
        [HttpPost, ActionName("FormTypesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FormTypesDeleteConfirmed(int id)
        {
            FormTypes formTypes = db.FormTypess.Find(id);
            db.FormTypess.Remove(formTypes);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a FormTypes record");
            return RedirectToAction("FormTypesIndex");
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
