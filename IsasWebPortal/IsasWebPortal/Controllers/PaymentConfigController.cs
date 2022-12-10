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
    public class PaymentConfigController : Controller
    {
        private IsasWebPortal.Models.IsasWebPortalDataContext db = new IsasWebPortal.Models.IsasWebPortalDataContext();

        // GET: PaymentConfig/PaymentConfigIndex
        public ActionResult PaymentConfigIndex()
        {
            return View(db.PaymentConfigs.ToList());
        }

        /*
        // GET: PaymentConfig/PaymentConfigDetails/5
        public ActionResult PaymentConfigDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentConfig paymentConfig = db.PaymentConfigs.Find(id);
            if (paymentConfig == null)
            {
                return HttpNotFound();
            }
            return View(paymentConfig);
        }
        */

        // GET: PaymentConfig/PaymentConfigCreate
        public ActionResult PaymentConfigCreate()
        {
            return View();
        }

        // POST: PaymentConfig/PaymentConfigCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentConfigCreate([Bind(Include = "amountConfig,stage,PaymentConfigId,planTitle,paymentSeqNum,Percentage,flatAmount")] PaymentConfig paymentConfig)
        {
            if (ModelState.IsValid)
            {
                db.PaymentConfigs.Add(paymentConfig);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a PaymentConfig record");
                return RedirectToAction("PaymentConfigIndex");
            }

            DisplayErrorMessage();
            return View(paymentConfig);
        }

        // GET: PaymentConfig/PaymentConfigEdit/5
        public ActionResult PaymentConfigEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentConfig paymentConfig = db.PaymentConfigs.Find(id);
            if (paymentConfig == null)
            {
                return HttpNotFound();
            }
            return View(paymentConfig);
        }

        // POST: PaymentConfigPaymentConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentConfigEdit([Bind(Include = "amountConfig,stage,PaymentConfigId,planTitle,paymentSeqNum,Percentage,flatAmount")] PaymentConfig paymentConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentConfig).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a PaymentConfig record");
                return RedirectToAction("PaymentConfigIndex");
            }
            DisplayErrorMessage();
            return View(paymentConfig);
        }

        // GET: PaymentConfig/PaymentConfigDelete/5
        public ActionResult PaymentConfigDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentConfig paymentConfig = db.PaymentConfigs.Find(id);
            if (paymentConfig == null)
            {
                return HttpNotFound();
            }
            return View(paymentConfig);
        }

        // POST: PaymentConfig/PaymentConfigDelete/5
        [HttpPost, ActionName("PaymentConfigDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentConfigDeleteConfirmed(long id)
        {
            PaymentConfig paymentConfig = db.PaymentConfigs.Find(id);
            db.PaymentConfigs.Remove(paymentConfig);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a PaymentConfig record");
            return RedirectToAction("PaymentConfigIndex");
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
