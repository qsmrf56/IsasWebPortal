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
    public class CountryConfigController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: CountryConfig/CountryConfigIndex
        public ActionResult CountryConfigIndex()
        {
            return View(db.CountryConfigs.ToList());
        }

        /*
        // GET: CountryConfig/CountryConfigDetails/5
        public ActionResult CountryConfigDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryConfig countryConfig = db.CountryConfigs.Find(id);
            if (countryConfig == null)
            {
                return HttpNotFound();
            }
            return View(countryConfig);
        }
        */

        // GET: CountryConfig/CountryConfigCreate
        public ActionResult CountryConfigCreate()
        {

            CountryConfig cc = new CountryConfig();
            return View(cc);
        }

        // POST: CountryConfig/CountryConfigCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CountryConfigCreate([Bind(Include = "clientCases,Id,countryName")] CountryConfig countryConfig)
        {
            if (ModelState.IsValid)
            {
                db.CountryConfigs.Add(countryConfig);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a CountryConfig record");
                return RedirectToAction("CountryConfigIndex");
            }

            DisplayErrorMessage();
            return View(countryConfig);
        }

        // GET: CountryConfig/CountryConfigEdit/5
        public ActionResult CountryConfigEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryConfig countryConfig = db.CountryConfigs.Find(id);
            if (countryConfig == null)
            {
                return HttpNotFound();
            }
            return View(countryConfig);
        }

        // POST: CountryConfigCountryConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CountryConfigEdit(/*[Bind(Include = "clientCases,Id,countryName")] */CountryConfig countryConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryConfig).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a CountryConfig record");
                return RedirectToAction("CountryConfigIndex");
            }
            DisplayErrorMessage();
            return View(countryConfig);
        }

        // GET: CountryConfig/CountryConfigDelete/5
        public ActionResult CountryConfigDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryConfig countryConfig = db.CountryConfigs.Find(id);
            if (countryConfig == null)
            {
                return HttpNotFound();
            }
            return View(countryConfig);
        }

        // POST: CountryConfig/CountryConfigDelete/5
        [HttpPost, ActionName("CountryConfigDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CountryConfigDeleteConfirmed(int id)
        {
            CountryConfig countryConfig = db.CountryConfigs.Find(id);
            db.CountryConfigs.Remove(countryConfig);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a CountryConfig record");
            return RedirectToAction("CountryConfigIndex");
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
