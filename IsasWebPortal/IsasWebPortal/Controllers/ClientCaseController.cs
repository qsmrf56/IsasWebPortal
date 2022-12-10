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
    public class ClientCaseController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();
      

        // GET: ClientCase/ClientCaseIndex
        public ActionResult ClientCaseIndex(int? id)
        {
        
         // var clientCases = db.ClientCases.Where(a => a.clientId == id).Include(a => a.client).ToList();

            var clientCases = db.ClientCases.Where(a => a.clientId == id).ToList();
                    
            //ViewBag.countryConfigId = new SelectList(clientCasesQuery, "countryConfigId", "countryName", selectedCountry);

            ViewBag.storedClientId = id;
            var client = db.Clients.Find(id);

            if (client !=null)
            {
                ViewBag.clientName = client.firstName + " " + client.middleName + " " + client.lastName;

            }


            return View(clientCases); //View(db.ClientCases.ToList());//
        }

        /*
        // GET: ClientCase/ClientCaseDetails/5
        public ActionResult ClientCaseDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCase clientCase = db.ClientCases.Find(id);
            if (clientCase == null)
            {
                return HttpNotFound();
            }
            return View(clientCase);
        }
        */

        // GET: ClientCase/ClientCaseCreate
        public ActionResult ClientCaseCreate(int id)
        {



            //PopulateCountriesDropDownList();


            var countriesQuery = from d in db.CountryConfigs
                                 orderby d.countryName
                                 select d;
            ViewBag.countryConfigId = new SelectList(countriesQuery, "countryConfigId", "countryName");
            
            
            //ViewBag.Countries = new SelectList(db.CountryConfigs, "Id", "countryName");


            //PopulateClientStatusDropDownList();
            var statusQuery = from d in db.ClientStatusConfigs

                              select d;
            ViewBag.ClientStatusConfigId = new SelectList(statusQuery, "ClientStatusConfigId", "Status");
            

            ViewBag.ApplicationTypeConfigIdView = new SelectList(db.ApplicationTypeConfigs, "applicationTypeConfigId", "ApplicationType");

            //PopulateStageDropDownList();
            var Stages = db.Stages
        .Select(s => new
        {
            Text = ((double)s.sequenceNumber) + " - " + s.Title,
            Value = s.StageId
        })
        .ToList();

            ViewBag.StagesId = new SelectList(Stages, "Value", "Text");

            ClientCase cc = new ClientCase();
            cc.clientId = id;
            
          
            return View(cc);
        }



        private void PopulateCountriesDropDownList(object selectedCountry = null)
        {
            var countriesQuery = from d in db.CountryConfigs
                                 orderby d.countryName
                                 select d;
            ViewBag.countryConfigId = new SelectList(countriesQuery, "countryConfigId", "countryName", selectedCountry);
            
        
        }


        private void PopulateClientStatusDropDownList(object selectedStatus = null)
        {
            //ViewBag.ClientStatusConfigId = new SelectList(db.ClientStatusConfigs, "ClientStatusConfigId", "Status");

            var statusQuery = from d in db.ClientStatusConfigs
                                 
                              select d;
            ViewBag.ClientStatusConfigId = new SelectList(statusQuery, "ClientStatusConfigId", "Status", selectedStatus);

        }


        private void PopulateStageDropDownList(object selectedStage= null)
        {
         var Stages = db.Stages
         .Select(s => new
         {
             Text = ((double)s.sequenceNumber) + " - " + s.Title,
             Value = s.StageId
         })
         .ToList();

            ViewBag.StagesId = new SelectList(Stages, "Value", "Text",selectedStage);


            }




        public ActionResult SendEmail(long? id)
        {

            return RedirectToAction("EmailCommunicationLogIndex", "EmailCommunicationLog", new { id = id });


        }


        // POST: ClientCase/ClientCaseCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCaseCreate(/*[Bind(Include = "applicationTypeConfigs,client,clientStatusConfigs,CountryConfigs,stage,Id,email")] */ClientCase clientCase)
        {


    /*        if (!ModelState.IsValid)
            {
    ViewBag.ApplicationTypeConfigIdView = new SelectList(db.ApplicationTypeConfigs, "ApplicationTypeConfigId", "ApplicationType", (object)clientCase.applicationTypeConfigId);
    

            PopulateClientStatusDropDownList();
            PopulateCountriesDropDownList();
            PopulateStageDropDownList();
            clientCase.clientId = 3;
            return View(clientCase);
            }
      */

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                db.ClientCases.Add(clientCase);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a ClientCase record");
                return RedirectToAction("ClientCaseIndex",new {id = clientCase.clientId });
            }

            DisplayErrorMessage();
            return View(clientCase);
        }

        // GET: ClientCase/ClientCaseEdit/5
        public ActionResult ClientCaseEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCase clientCase = db.ClientCases.Find(id);

            PopulateCountriesDropDownList(clientCase.countryConfigId);
            //ViewBag.Countries = new SelectList(db.CountryConfigs, "Id", "countryName");
            PopulateClientStatusDropDownList(clientCase.clientStatusConfigId);
            //ViewBag.ClientStatusConfigId = new SelectList(db.ClientStatusConfigs, "ClientStatusConfigId", "Status",clientCase.clientStatusConfigId);

            ViewBag.ApplicationTypeConfigIdView = new SelectList(db.ApplicationTypeConfigs, "ApplicationTypeConfigId", "ApplicationType", (object)clientCase.applicationTypeConfigId);


            PopulateStageDropDownList(clientCase.stageId);
           
            
            
            if (clientCase == null)
            {
                return HttpNotFound();
            }
            return View(clientCase);
        }

        // POST: ClientCaseClientCase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCaseEdit(/*[Bind(Include = "applicationTypeConfigs,client,clientStatusConfigs,CountryConfigs,stage,Id,email")] */ClientCase clientCase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientCase).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a ClientCase record");
                return RedirectToAction("ClientCaseIndex", new {id = clientCase.clientId });
            }
            DisplayErrorMessage();
            return View(clientCase);
        }

        // GET: ClientCase/ClientCaseDelete/5
        public ActionResult ClientCaseDelete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientCase clientCase = db.ClientCases.Find(id);
            if (clientCase == null)
            {
                return HttpNotFound();
            }
            return View(clientCase);
        }

        // POST: ClientCase/ClientCaseDelete/5
        [HttpPost, ActionName("ClientCaseDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ClientCaseDeleteConfirmed(long id)
        {
            long clientIdforIndex;
            ClientCase clientCase = db.ClientCases.Find(id);
            clientIdforIndex = clientCase.clientId;
            db.ClientCases.Remove(clientCase);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a ClientCase record");
            return RedirectToAction("ClientCaseIndex", new { id = clientIdforIndex });
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
