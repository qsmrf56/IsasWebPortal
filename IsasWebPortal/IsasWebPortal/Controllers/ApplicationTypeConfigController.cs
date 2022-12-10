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
    public class ApplicationTypeConfigController : Controller
    {
        private IsasWebPortal.Models.IsasWebPortalDataContext db = new IsasWebPortal.Models.IsasWebPortalDataContext();

        // GET: ApplicationTypeConfig/ApplicationTypeConfigIndex
        public ActionResult ApplicationTypeConfigIndex()
        {
            return View(db.ApplicationTypeConfigs.ToList());
        }

        /*
        // GET: ApplicationTypeConfig/ApplicationTypeConfigDetails/5
        public ActionResult ApplicationTypeConfigDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationTypeConfig applicationTypeConfig = db.ApplicationTypeConfigs.Find(id);
            if (applicationTypeConfig == null)
            {
                return HttpNotFound();
            }
            return View(applicationTypeConfig);
        }
        */

        // GET: ApplicationTypeConfig/ApplicationTypeConfigCreate
        public ActionResult ApplicationTypeConfigCreate()
        {

            ApplicationTypeConfig atc = new ApplicationTypeConfig();

            return View(atc);
        }

        // POST: ApplicationTypeConfig/ApplicationTypeConfigCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationTypeConfigCreate(/*[Bind(Include = "clientCases,ApplicationTypeConfigId,applicationType")]*/ ApplicationTypeConfig applicationTypeConfig)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.ApplicationTypeConfigs.Add(applicationTypeConfig);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ApplicationTypeConfig record");
                return RedirectToAction("ApplicationTypeConfigIndex");
            }

            DisplayErrorMessage();
            return View(applicationTypeConfig);
        }

        // GET: ApplicationTypeConfig/ApplicationTypeConfigEdit/5
        public ActionResult ApplicationTypeConfigEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationTypeConfig applicationTypeConfig = db.ApplicationTypeConfigs.Find(id);
            if (applicationTypeConfig == null)
            {
                return HttpNotFound();
            }
            return View(applicationTypeConfig);
        }

        // POST: ApplicationTypeConfigApplicationTypeConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationTypeConfigEdit([Bind(Include = "clientCases,ApplicationTypeConfigId,applicationType")] ApplicationTypeConfig applicationTypeConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationTypeConfig).State = EntityState.Modified;

                
                    db.SaveChanges();
                
                DisplaySuccessMessage("Has update a ApplicationTypeConfig record");
                return RedirectToAction("ApplicationTypeConfigIndex");
            }
            DisplayErrorMessage();
            return View(applicationTypeConfig);
        }

        // GET: ApplicationTypeConfig/ApplicationTypeConfigDelete/5
        public ActionResult ApplicationTypeConfigDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationTypeConfig applicationTypeConfig = db.ApplicationTypeConfigs.Find(id);
            if (applicationTypeConfig == null)
            {
                return HttpNotFound();
            }
            return View(applicationTypeConfig);
        }

        // POST: ApplicationTypeConfig/ApplicationTypeConfigDelete/5
        [HttpPost, ActionName("ApplicationTypeConfigDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationTypeConfigDeleteConfirmed(long id)
        {
            ApplicationTypeConfig applicationTypeConfig = db.ApplicationTypeConfigs.Find(id);
            db.ApplicationTypeConfigs.Remove(applicationTypeConfig);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ApplicationTypeConfig record");
            return RedirectToAction("ApplicationTypeConfigIndex");
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
