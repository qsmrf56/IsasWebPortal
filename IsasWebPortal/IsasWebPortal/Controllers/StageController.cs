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
    public class StageController : Controller
    {
        private IsasWebPortal.Models.IsasWebPortalDataContext db = new IsasWebPortal.Models.IsasWebPortalDataContext();

        // GET: Stage/StageIndex
        public ActionResult StageIndex()
        {
            return View(db.Stages.ToList());
        }

        /*
        // GET: Stage/StageDetails/5
        public ActionResult StageDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }
        */

        // GET: Stage/StageCreate
        public ActionResult StageCreate()
        {
            return View();
        }

        // POST: Stage/StageCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StageCreate([Bind(Include = "clientCases,paymentConfigs,StageId,Title,sequenceNumber")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Stages.Add(stage);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Stage record");
                return RedirectToAction("StageIndex");
            }

            DisplayErrorMessage();
            return View(stage);
        }

        // GET: Stage/StageEdit/5
        public ActionResult StageEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: StageStage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StageEdit([Bind(Include = "clientCases,paymentConfigs,StageId,Title,sequenceNumber")] Stage stage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stage).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Stage record");
                return RedirectToAction("StageIndex");
            }
            DisplayErrorMessage();
            return View(stage);
        }

        // GET: Stage/StageDelete/5
        public ActionResult StageDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stage stage = db.Stages.Find(id);
            if (stage == null)
            {
                return HttpNotFound();
            }
            return View(stage);
        }

        // POST: Stage/StageDelete/5
        [HttpPost, ActionName("StageDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult StageDeleteConfirmed(long id)
        {
            Stage stage = db.Stages.Find(id);
            db.Stages.Remove(stage);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Stage record");
            return RedirectToAction("StageIndex");
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
