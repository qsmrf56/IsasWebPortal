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
    public class ConfigurationsController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: ConfigurationsMetadata/ConfigurationsMetadataIndex
        public ActionResult ConfigurationsIndex()
        {
            return View(db.Configurationss.ToList());
        }

        /*
        // GET: ConfigurationsMetadata/ConfigurationsMetadataDetails/5
        public ActionResult ConfigurationsMetadataDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConfigurationsMetadata configurationsMetadata = db.ConfigurationsMetadatas.Find(id);
            if (configurationsMetadata == null)
            {
                return HttpNotFound();
            }
            return View(configurationsMetadata);
        }
        */

        // GET: ConfigurationsMetadata/ConfigurationsMetadataCreate
        public ActionResult ConfigurationsCreate()
        {
            return View();
        }

        // POST: ConfigurationsMetadata/ConfigurationsMetadataCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfigurationsCreate([Bind(Include = "Id,param1,param2,param3,param4,param5,param6")] Configurations configurations)
        {
            if (ModelState.IsValid)
            {
                db.Configurationss.Add(configurations);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ConfigurationsMetadata record");
                return RedirectToAction("ConfigurationsIndex");
            }

            DisplayErrorMessage();
            return View(configurations);
        }

        // GET: ConfigurationsMetadata/ConfigurationsMetadataEdit/5
        public ActionResult ConfigurationsEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configurations configurations = db.Configurationss.Find(id);
            if (configurations == null)
            {
                return HttpNotFound();
            }
            return View(configurations);
        }

        // POST: ConfigurationsMetadataConfigurationsMetadata/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfigurationsMetadataEdit([Bind(Include = "Id,param1,param2,param3,param4,param5,param6")] Configurations configurations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(configurations).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Configurations record");
                return RedirectToAction("ConfigurationsIndex");
            }
            DisplayErrorMessage();
            return View(configurations);
        }

        // GET: ConfigurationsMetadata/ConfigurationsMetadataDelete/5
        public ActionResult ConfigurationsDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Configurations configurations = db.Configurationss.Find(id);
            if (configurations == null)
            {
                return HttpNotFound();
            }
            return View(configurations);
        }

        // POST: ConfigurationsMetadata/ConfigurationsMetadataDelete/5
        [HttpPost, ActionName("ConfigurationsDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfigurationsDeleteConfirmed(int id)
        {
            Configurations configurations = db.Configurationss.Find(id);
            db.Configurationss.Remove(configurations);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Configurations record");
            return RedirectToAction("ConfigurationsIndex");
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
