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
    public class ClientController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();

        // GET: Client/ClientIndex
        public ActionResult ClientIndex()
        {
            return View(db.Clients.ToList());
        }

        /*
        // GET: Client/ClientDetails/5
        public ActionResult ClientDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
        */

        // GET: Client/ClientCreate
        public ActionResult ClientCreate()
        {
            return View();
        }

        // POST: Client/ClientCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCreate([Bind(Include = "clientCases,Id,firstName,middleName,lastName,Address,contactNumber")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a Client record");
                return RedirectToAction("ClientIndex");
            }

            DisplayErrorMessage();
            return View(client);
        }

        // GET: Client/ClientEdit/5
        public ActionResult ClientEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: ClientClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientEdit(/*[Bind(Include = "clientCases,Id,firstName,middleName,lastName,Address,contactNumber")] */Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a Client record");
                return RedirectToAction("ClientIndex");
            }
            DisplayErrorMessage();
            return View(client);
        }



        public ActionResult AddCase(long? id)
        {

        return RedirectToAction("ClientCaseIndex","ClientCase", new { id = id });
        
        
        }

        // GET: Client/ClientDelete/5
        public ActionResult ClientDelete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Client/ClientDelete/5
        [HttpPost, ActionName("ClientDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ClientDeleteConfirmed(long id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a Client record");
            return RedirectToAction("ClientIndex");
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
