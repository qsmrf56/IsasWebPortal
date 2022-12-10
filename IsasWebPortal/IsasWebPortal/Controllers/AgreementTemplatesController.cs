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
using System.IO;

namespace IsasWebPortal.Controllers
{
    public class AgreementTemplatesController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();
       // private string agreementFilePath;

        // GET: AgreementTemplates/AgreementTemplatesIndex
        public ActionResult AgreementTemplatesIndex()
        {

            ///var config = db.Configurationss.Single();

          //  agreementFilePath = config.AgreementImagesPath;

            var agreementTemplates = db.AgreementTemplatess.Include(a => a.configs).ToList();


            return View(agreementTemplates);
        }

        /*
        // GET: AgreementTemplates/AgreementTemplatesDetails/5
        public ActionResult AgreementTemplatesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementTemplates agreementTemplates = db.AgreementTemplatess.Find(id);
            if (agreementTemplates == null)
            {
                return HttpNotFound();
            }
            return View(agreementTemplates);
        }
        */

        // GET: AgreementTemplates/AgreementTemplatesCreate
        public ActionResult AgreementTemplatesCreate()
        {
            return View();
        }


        //Copy selected images to AgreementImages folder(source path,destination path,destinationNameofFile)
        //Also renames the file
        private bool copyImagetoFolder(string sourcePath, string destinationPath, string destinationfileName)
        {

            //sourcePath = "@" + sourcePath;
           // destinationPath = "@" + destinationPath;

            string destFile = System.IO.Path.Combine(destinationPath, destinationfileName + Path.GetExtension(sourcePath));

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(destinationPath))
            {
                System.IO.Directory.CreateDirectory(destinationPath);
            }
            
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            try
            {
                System.IO.File.Copy(sourcePath, destFile, true);
            }
            catch (Exception e)
            {
                return false;
            }



            return true;
        }


        // POST: AgreementTemplates/AgreementTemplatesCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgreementTemplatesCreate([Bind(Include = "emailCommunicationLogs,Id,templateName,headerGraphicTL,headerGraphicM,headerGraphicTR,Body,signature")] AgreementTemplates agreementTemplates)
        {
           
                   
            if (ModelState.IsValid)
            {

                agreementTemplates.configs = db.Configurationss.Where(a=>a.param1=="AgreementsImagesPath").Single();
                var destinationPath = agreementTemplates.configs.param2;


                if (agreementTemplates.headerGraphicM != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicM, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "M");

                    //setting new path of image:
                    agreementTemplates.headerGraphicM = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "M" + Path.GetExtension(agreementTemplates.headerGraphicM));
                }

                if (agreementTemplates.headerGraphicTL != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicTL, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TL");

                    //setting new path of image:
                    agreementTemplates.headerGraphicTL = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TL" + Path.GetExtension(agreementTemplates.headerGraphicTL));
                }

                if (agreementTemplates.headerGraphicTR != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicTR, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TR");

                    //setting new path of image:
                    agreementTemplates.headerGraphicTR = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TR" + Path.GetExtension(agreementTemplates.headerGraphicTR));
                }

                if (agreementTemplates.signature != null)
                {
                    copyImagetoFolder(agreementTemplates.signature, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "Sig");

                    //setting new path of image:
                    agreementTemplates.signature = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "Sig" + Path.GetExtension(agreementTemplates.signature));
                }
               


                db.AgreementTemplatess.Add(agreementTemplates);
                db.SaveChanges();
                DisplaySuccessMessage("Has append a AgreementTemplates record");
                return RedirectToAction("AgreementTemplatesIndex");
            }

            DisplayErrorMessage();
            return View(agreementTemplates);
        }

        // GET: AgreementTemplates/AgreementTemplatesEdit/5
        public ActionResult AgreementTemplatesEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementTemplates agreementTemplates = db.AgreementTemplatess.Find(id);
            if (agreementTemplates == null)
            {
                return HttpNotFound();
            }
            return View(agreementTemplates);
        }

        // POST: AgreementTemplatesAgreementTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgreementTemplatesEdit(/*[Bind(Include = "emailCommunicationLogs,Id,templateName,headerGraphicTL,headerGraphicM,headerGraphicTR,Body,signature")]*/ AgreementTemplates agreementTemplates)
        {
            if (ModelState.IsValid)
            {

                agreementTemplates.configs = db.Configurationss.Single();
                var destinationPath = agreementTemplates.configs.param2;


                if (agreementTemplates.headerGraphicM != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicM, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "M");

                    //setting new path of image:
                    agreementTemplates.headerGraphicM = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "M" + Path.GetExtension(agreementTemplates.headerGraphicM));
                }

                if (agreementTemplates.headerGraphicTL != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicTL, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TL");

                    //setting new path of image:
                    agreementTemplates.headerGraphicTL = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TL" + Path.GetExtension(agreementTemplates.headerGraphicTL));
                }

                if (agreementTemplates.headerGraphicTR != null)
                {
                    copyImagetoFolder(agreementTemplates.headerGraphicTR, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TR");

                    //setting new path of image:
                    agreementTemplates.headerGraphicTR = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "TR" + Path.GetExtension(agreementTemplates.headerGraphicTR));
                }

                if (agreementTemplates.signature != null)
                {
                    copyImagetoFolder(agreementTemplates.signature, destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "Sig");

                    //setting new path of image:
                    agreementTemplates.signature = System.IO.Path.Combine(destinationPath, agreementTemplates.templateName + "-" + agreementTemplates.Id + "-" + "Sig" + Path.GetExtension(agreementTemplates.signature));
                }
               

                
                
                
                db.Entry(agreementTemplates).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a AgreementTemplates record");
                return RedirectToAction("AgreementTemplatesIndex");
            }
            DisplayErrorMessage();
            return View(agreementTemplates);
        }

        // GET: AgreementTemplates/AgreementTemplatesDelete/5
        public ActionResult AgreementTemplatesDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgreementTemplates agreementTemplates = db.AgreementTemplatess.Find(id);
            if (agreementTemplates == null)
            {
                return HttpNotFound();
            }
            return View(agreementTemplates);
        }

        // POST: AgreementTemplates/AgreementTemplatesDelete/5
        [HttpPost, ActionName("AgreementTemplatesDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AgreementTemplatesDeleteConfirmed(int id)
        {
            AgreementTemplates agreementTemplates = db.AgreementTemplatess.Find(id);
            db.AgreementTemplatess.Remove(agreementTemplates);
            db.SaveChanges();
            DisplaySuccessMessage("Has delete a AgreementTemplates record");
            return RedirectToAction("AgreementTemplatesIndex");
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
