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
    public class ClientStatusConfigController : Controller
    {
        private IsasWebPortal.Models.IsasWebPortalDataContext db = new IsasWebPortal.Models.IsasWebPortalDataContext();

        // GET: ClientStatusConfig/ClientStatusConfigIndex
        public ActionResult ClientStatusConfigIndex()
        {
            return View(db.ClientStatusConfigs.ToList());
        }

        /*
        // GET: ClientStatusConfig/ClientStatusConfigDetails/5
        public ActionResult ClientStatusConfigDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientStatusConfig clientStatusConfig = db.ClientStatusConfigs.Find(id);
            if (clientStatusConfig == null)
            {
                return HttpNotFound();
            }
            return View(clientStatusConfig);
        }
        */

        // GET: ClientStatusConfig/ClientStatusConfigCreate
        public ActionResult ClientStatusConfigCreate()
        {
            return View();
        }

        // POST: ClientStatusConfig/ClientStatusConfigCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientStatusConfigCreate([Bind(Include = "clientCases,ClientStatusConfigId,Status")] ClientStatusConfig clientStatusConfig)
        {
            if (ModelState.IsValid)
            {
                db.ClientStatusConfigs.Add(clientStatusConfig);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ClientStatusConfig record");
                return RedirectToAction("ClientStatusConfigIndex");
            }

            DisplayErrorMessage();
            return View(clientStatusConfig);
        }

        // GET: ClientStatusConfig/ClientStatusConfigEdit/5
        public ActionResult ClientStatusConfigEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientStatusConfig clientStatusConfig = db.ClientStatusConfigs.Find(id);
            if (clientStatusConfig == null)
            {
                return HttpNotFound();
            }
            return View(clientStatusConfig);
        }

        // POST: ClientStatusConfigClientStatusConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientStatusConfigEdit([Bind(Include = "clientCases,ClientStatusConfigId,Status")] ClientStatusConfig clientStatusConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientStatusConfig).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a ClientStatusConfig record");
                return RedirectToAction("ClientStatusConfigIndex");
            }
            DisplayErrorMessage();
            return View(clientStatusConfig);
        }

        // GET: ClientStatusConfig/ClientStatusConfigDelete/5
        public ActionResult ClientStatusConfigDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientStatusConfig clientStatusConfig = db.ClientStatusConfigs.Find(id);
            if (clientStatusConfig == null)
            {
                return HttpNotFound();
            }
            return View(clientStatusConfig);
        }

        // POST: ClientStatusConfig/ClientStatusConfigDelete/5
        [HttpPost, ActionName("ClientStatusConfigDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ClientStatusConfigDeleteConfirmed(long id)
        {
            ClientStatusConfig clientStatusConfig = db.ClientStatusConfigs.Find(id);
            db.ClientStatusConfigs.Remove(clientStatusConfig);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ClientStatusConfig record");
            return RedirectToAction("ClientStatusConfigIndex");
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
