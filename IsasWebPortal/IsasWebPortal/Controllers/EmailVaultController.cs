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
using IsasWebPortal.Utilities;

namespace IsasWebPortal.Controllers
{
    public class EmailVaultController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: EmailVault/EmailVaultIndex
        public ActionResult EmailVaultIndex()
        {
            return View(db.emailVaultss.ToList());
        }

        /*
        // GET: EmailVault/EmailVaultDetails/5
        public ActionResult EmailVaultDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVault emailVault = db.emailVaultss.Find(id);
            if (emailVault == null)
            {
                return HttpNotFound();
            }
            return View(emailVault);
        }
        */

        // GET: EmailVault/EmailVaultCreate
        public ActionResult EmailVaultCreate()
        {
            return View();
        }

        // POST: EmailVault/EmailVaultCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailVaultCreate([Bind(Include = "emailcommlogs,id,password,email")] EmailVault emailVault)
        {

            emailVault.password = Crypto.EncryptStringAES(emailVault.password,"TheSecretIsThatThereIsNoSecret");
            
            if (ModelState.IsValid)
            {
                db.emailVaultss.Add(emailVault);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a EmailVault record");
                return RedirectToAction("EmailVaultIndex");
            }

            DisplayErrorMessage();
            return View(emailVault);
        }

        // GET: EmailVault/EmailVaultEdit/5
        public ActionResult EmailVaultEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVault emailVault = db.emailVaultss.Find(id);
            if (emailVault == null)
            {
                return HttpNotFound();
            }
            return View(emailVault);
        }

        // POST: EmailVaultEmailVault/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailVaultEdit([Bind(Include = "emailcommlogs,id,password,email")] EmailVault emailVault)
        {
            if (ModelState.IsValid)
            {
                emailVault.password = Crypto.EncryptStringAES(emailVault.password, "TheSecretIsThatThereIsNoSecret");
                
                db.Entry(emailVault).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a EmailVault record");
                return RedirectToAction("EmailVaultIndex");
            }
            DisplayErrorMessage();
            return View(emailVault);
        }

        // GET: EmailVault/EmailVaultDelete/5
        public ActionResult EmailVaultDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailVault emailVault = db.emailVaultss.Find(id);
            if (emailVault == null)
            {
                return HttpNotFound();
            }
            return View(emailVault);
        }

        // POST: EmailVault/EmailVaultDelete/5
        [HttpPost, ActionName("EmailVaultDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult EmailVaultDeleteConfirmed(int id)
        {
            EmailVault emailVault = db.emailVaultss.Find(id);
            db.emailVaultss.Remove(emailVault);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a EmailVault record");
            return RedirectToAction("EmailVaultIndex");
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
