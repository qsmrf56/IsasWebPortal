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
using System.Web.UI.WebControls;
using System.Net.Mail;
using IsasWebPortal.Utilities;
using HtmlAgilityPack;
using System.Linq.Expressions;
using System.IO;
using OpenPop.Pop3;
using MailKit.Net.Imap;
using MailKit;
using MailKit.Search;
using MailKit.Security;
using ActiveUp.Net.Mail;


namespace IsasWebPortal.Controllers
{

    

    public class EmailCommunicationLogController : Controller
    {
        private IsasWebPortalDataContext db = new IsasWebPortalDataContext();
        

        // GET: EmailCommunicationLog/EmailCommunicationLogIndex
        public ActionResult EmailCommunicationLogIndex(int id)
        {
            ViewBag.storedClientCaseId = id;

            var emailCommunicationLog = db.EmailCommunicationLogs.Include(e => e.agreementTemplatess).Include(e => e.clientCaseConfigs).Include(e => e.emailTemplatess).Where(d=>d.clientCaseId==id).OrderByDescending(e => e.timeStamp);

            //var emailCommunicationLog = from n in db.EmailCommunicationLogs
            //                            orderby n.timeStamp descending
            //                            select n
            //                            ;

           
           
            
            return View(emailCommunicationLog.ToList());
        }




        public ActionResult BrowseAttachment()
        {

            return PartialView();
        }

       


        /*
        // GET: EmailCommunicationLog/EmailCommunicationLogDetails/5
        public ActionResult EmailCommunicationLogDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCommunicationLog emailCommunicationLog = db.EmailCommunicationLogs.Find(id);
            if (emailCommunicationLog == null)
            {
                return HttpNotFound();
            }
            return View(emailCommunicationLog);
        }
        */

        // GET: EmailCommunicationLog/EmailCommunicationLogCreate
        public ActionResult EmailCommunicationLogCreate(int id)
        {
            ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName");
            //ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email");
            ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName");

            EmailCommunicationLog emailCommLog = new EmailCommunicationLog();
           
            try
            {
                var emailvault = db.emailVaultss.Single();
                emailCommLog.fromAddress = emailvault.email;
                emailCommLog.emailvaultid = emailvault.id;
            }
            catch (Exception e)
            { 
            
            }
            
           
            emailCommLog.clientCaseId = id;
           
            ViewBag.EmailcommlogId = emailCommLog.Id;
            ViewBag.DefaultEmailforClientCase = db.ClientCases.Find(id).email;
            emailCommLog.defaultEmailAddress = db.ClientCases.Find(emailCommLog.clientCaseId).email;
            //Attachments attachment = new Attachments();



            return View(emailCommLog);
        }


        //Send Email
        [HttpPost]
        public bool SendEmail( EmailCommunicationLog emailCommunicationLog ,ref string error, FormLinks[] filepaths/*HttpPostedFileBase fileUploader*/)
        {
            //if (ModelState.IsValid)
           // {

            var emailvault = db.emailVaultss.Single();

            string from = emailCommunicationLog.fromAddress;
                using (MailMessage mail = new MailMessage(from, emailCommunicationLog.toAddress))
                {
                    mail.Subject = "ISAS Consultants";
                    mail.Body = emailCommunicationLog.Body == null ? emailCommunicationLog.emailTemplatess.Body : emailCommunicationLog.Body;
                    //if (fileUploader != null)
                    //{

                    for (int i = 0; i < filepaths.Count();i++)
                    {
                        string fileName = Path.GetFileName(filepaths[i].formLink);//fileUploader.FileName);


                        /////////////////////
                        byte[] file;
                        var stream = new FileStream(filepaths[i].formLink, FileMode.Open, FileAccess.Read);

                        ////////////////////



                        mail.Attachments.Add(new System.Net.Mail.Attachment(stream, fileName));
                    }
                    //}
                    mail.IsBodyHtml = false;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential networkCredential;
                    try
                    {
                         networkCredential = new NetworkCredential(from, Utilities.Crypto.DecryptStringAES(emailvault.password, "TheSecretIsThatThereIsNoSecret"));
                    }
                    catch (Exception e)
                    {

                        error = "Please verify your Email credentials. Email has not been sent";
                        
                        return false;
                    }
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCredential;
                    smtp.Port = 587;
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception e)
                    {

                        error = "Email has not been sent. Please check your internet connectivity and try at a later time";
                        return false;
                    }
                    ViewBag.Message = "Sent";

                    
                    //return View("Index", objModelMail);
                }
         //   }
          //  else
          //  {
          //      return View();
          //  }

                return true;
        }
    


        public JsonResult preliminaryBeforeSendingEmail(int emailcommunicationlogid, string error)
        {

           

            EmailCommunicationLog emailCommunicationLog = db.EmailCommunicationLogs.Find(emailcommunicationlogid);

            //adding links to email body.

            //getting form links
            FormLinks[] formlinks = db.formLinks.Where(d => d.emailCommunicationLogId == emailcommunicationlogid).Where(d=>d.isPath.Equals(false)).ToArray();


            //getting file paths
            FormLinks[] filepaths = db.formLinks.Where(x => x.emailCommunicationLogId == emailcommunicationlogid).Where(x => x.isPath.Equals(true)).ToArray();


            int c = formlinks.Count();
            var body = "";

            for (int i = 0; i < c; i++)
            {

                body += '\n';


                body += formlinks.ElementAt(i).formLink;
            
            }


            emailCommunicationLog.Body += body;
                // string error = "";

            if (!SendEmail(emailCommunicationLog, ref error, filepaths))
                {
                    ViewBag.MyErrorIndication = "EmailError";
                    // ViewBag.MyErrorMessage = error;
                    //ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName", emailCommunicationLog.agreementTemplatesId);
                    //ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email", emailCommunicationLog.clientCaseId);
                    //ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName", emailCommunicationLog.emailTemplatesId);
                    //return RedirectToAction("EmailCommunicationLogCreate", new { id = emailCommunicationLog.clientCaseId }); //so that page actually reloads and alert is shown
                    TempData["msg"] = "<script>alert('" + error + "');</script>";
                    ViewBag.MyErrorIndication = "EmailError";

                    return Json("Failed");
                }

            return Json("Success");
        
        }


        public ActionResult ReceivedEmailsViaIMAP(int id)
        {

         Imap4Client imap = new Imap4Client();
         imap.ConnectSsl("imap.gmail.com", 993);
         imap.Login("adnan.samad@gmail.com", "bazooka4966655092014adnan");
         imap.Command("capability");

         Mailbox inbox = imap.SelectMailbox("INBOX");
         int[] ids = inbox.Search("ALL");

           

         List<Message> ISASList = new List<Message>();

            DateTime dt = new DateTime(2016, 1, 1);

            bool escape = false;

            int count = 0;


         if (ids.Length > 0)
         {

             for (int i = (ids.Length - 1); i > 0 && escape==false; i--)
             {

                 try
                 {
                     Message msg_first = inbox.Fetch.MessageObject(ids[i]);
                     count++;

                     if (msg_first.Date > dt)
                     {
                         

                         if (msg_first.Subject == "ISAS Consultants")
                         {
                             ISASList.Add(msg_first);
                         }
                        

                     }
                     else
                     { escape = true; }
                 }
                 catch (Exception e)
                 { 
                 //do absolutely nothing
                 
                 }

             }
         }   
           
            

           
            //ImapClient ic = new ImapClient();
            //ic.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);
            //ic.Authenticate("adnan.samad@gmail.com", "bazooka4966655092014adnan");

            //bool isconnected = ic.IsConnected;
            //bool isAuthenticated = ic.IsAuthenticated;

            //ic.Inbox.Open(FolderAccess.ReadOnly);

            //var uids = ic.Inbox.Search(SearchQuery.All);


            //List<MimeKit.MimeMessage> msglist = new List<MimeKit.MimeMessage>();


           

            //foreach (var uid in uids)
            //{
            //    var message = ic.Inbox.GetMessage(uid);

            //    if (message.Headers.Contains("ISAS Consultants"))
            //    {
            //        msglist.Add(message);
            //    }
            //    // write the message to a file
               
            //}


            //int l = 1;

            //for (int i = 0; i < msglist.Count(); i++)
            //{

            //   var s = msglist[i];
            
            //}




            //    ic.Disconnect(true);


            return View();
        
        }



        public ActionResult ReceivedEmails(int id)
        {

            OpenPop.Pop3.Pop3Client PopClient = new OpenPop.Pop3.Pop3Client();
            PopClient.Connect("pop.gmail.com", 995, true); //pop.secureserver.net //

            PopClient.Authenticate("recent:adnan.samad@gmail.com", "bazooka4966655092014adnan", AuthenticationMethod.UsernameAndPassword);


            Int32 messageCount = PopClient.GetMessageCount();


            //List<OpenPop.Mime.MessageInfo> mi = PopClient..GetMessageInfos();
            


            List <OpenPop.Mime.Message> wantedList = new List<OpenPop.Mime.Message>();
            
            
            for (int i = messageCount; i > messageCount - 20; i--)
            {

                OpenPop.Mime.Message s = PopClient.GetMessage(i);

                if (s.Headers.DateSent.Year == 2016)
                { wantedList.Add(s); }
                //s.Headers.DateSent.Year
               

               // Messa body = s.
            
            }



            for (int i = 0; i < wantedList.Count(); i++)
            {
                OpenPop.Mime.Message s = wantedList[i];
                string messageheader = s.Headers.Subject;
                            
            }



                return View();
        
        }


        // POST: EmailCommunicationLog/EmailCommunicationLogCreate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult EmailCommunicationLogCreate(/*[Bind(Include = "agreementTemplatess,attachmentss,clientCaseConfigs,emailTemplatess,formDatas,Id,clientCaseId,agreementTemplatesId,emailTemplatesId,Body,timeStamp,toAddress,fromAddress,formLink,isSent,isReceived,defaultEmailAddress,emailvaultid")]*/ EmailCommunicationLog emailCommunicationLog)
        {

            
            var errors = ModelState.Values.SelectMany(v => v.Errors);



            if (ModelState.IsValid)
            {
                

                //If no body has been provided for the email
                //template emailBody is used, it should replace the body of email sent.
                emailCommunicationLog.Body = emailCommunicationLog.Body == null ? db.EmailTemplatess.Find(emailCommunicationLog.emailTemplatesId).Body : emailCommunicationLog.Body;
                emailCommunicationLog.isSent = true;

                //string error = "";

                //if (!SendEmail(emailCommunicationLog, ref error))
                //{
                //   ViewBag.MyErrorIndication = "EmailError";
                //   // ViewBag.MyErrorMessage = error;
                //   //ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName", emailCommunicationLog.agreementTemplatesId);
                //   //ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email", emailCommunicationLog.clientCaseId);
                //   //ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName", emailCommunicationLog.emailTemplatesId);
                //   //return RedirectToAction("EmailCommunicationLogCreate", new { id = emailCommunicationLog.clientCaseId }); //so that page actually reloads and alert is shown
                //    TempData["msg"] = "<script>alert('" + error +"');</script>";
                //    ViewBag.MyErrorIndication = "EmailError";

                //}
                //else
                //{

                    db.EmailCommunicationLogs.Add(emailCommunicationLog);
                    db.SaveChanges();
                    DisplaySuccessMessage("Has append a EmailCommunicationLog record");
                    TempData["msg"] = "<script>alert('Email Sent Successfully!');</script>";
               // }

                  //return RedirectToAction("EmailCommunicationLogIndex", new { id = emailCommunicationLog.clientCaseId });
               // return Json(new { success = true, responseText = "Your message successfuly sent!" }, JsonRequestBehavior.AllowGet);
                return Json("Success, EmailCommunicationLogId:" + emailCommunicationLog.Id);
            }

            ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName", emailCommunicationLog.agreementTemplatesId);
            ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email", emailCommunicationLog.clientCaseId);
            ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName", emailCommunicationLog.emailTemplatesId);
            ViewBag.formTemplatesId = new SelectList(db.FormTemplatess, "Id", "formName");

            DisplayErrorMessage();
           return Json("Failed");
           // return View(emailCommunicationLog);
           // return Json(new { success = false, responseText = "Email was not sent" }, JsonRequestBehavior.AllowGet);
        }

        // GET: EmailCommunicationLog/EmailCommunicationLogEdit/5
        public ActionResult EmailCommunicationLogEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCommunicationLog emailCommunicationLog = db.EmailCommunicationLogs.Find(id);
            if (emailCommunicationLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName", emailCommunicationLog.agreementTemplatesId);
            ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email", emailCommunicationLog.clientCaseId);
            ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName", emailCommunicationLog.emailTemplatesId);
            return View(emailCommunicationLog);
        }

        // POST: EmailCommunicationLogEmailCommunicationLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailCommunicationLogEdit([Bind(Include = "agreementTemplatess,attachmentss,clientCaseConfigs,emailTemplatess,formDatas,Id,clientCaseId,agreementTemplatesId,emailTemplatesId,Body,timeStamp,toAddress,fromAddress,formLink,isSent,isReceived")] EmailCommunicationLog emailCommunicationLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emailCommunicationLog).State = EntityState.Modified;
                db.SaveChanges();
                DisplaySuccessMessage("Has update a EmailCommunicationLog record");
                return RedirectToAction("EmailCommunicationLogIndex");
            }
            ViewBag.agreementTemplatesId = new SelectList(db.AgreementTemplatess, "Id", "templateName", emailCommunicationLog.agreementTemplatesId);
            ViewBag.clientCaseId = new SelectList(db.ClientCases, "Id", "email", emailCommunicationLog.clientCaseId);
            ViewBag.emailTemplatesId = new SelectList(db.EmailTemplatess, "Id", "templateName", emailCommunicationLog.emailTemplatesId);
            DisplayErrorMessage();
            return View(emailCommunicationLog);
        }

        // GET: EmailCommunicationLog/EmailCommunicationLogDelete/5
        public ActionResult EmailCommunicationLogDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmailCommunicationLog emailCommunicationLog = db.EmailCommunicationLogs.Find(id);
            if (emailCommunicationLog == null)
            {
                return HttpNotFound();
            }
            return View(emailCommunicationLog);
        }

        // POST: EmailCommunicationLog/EmailCommunicationLogDelete/5
        [HttpPost, ActionName("EmailCommunicationLogDelete")]
       // [ValidateAntiForgeryToken]
        public JsonResult EmailCommunicationLogDeleteConfirmed(int id)
        {
            EmailCommunicationLog emailCommunicationLog = db.EmailCommunicationLogs.Find(id);
            db.EmailCommunicationLogs.Remove(emailCommunicationLog);
            db.SaveChanges();
            return Json("Success");
           // DisplaySuccessMessage("Has delete a EmailCommunicationLog record");
          //  return RedirectToAction("EmailCommunicationLogIndex");
        }



        public ActionResult ViewSentEmail(int id)
        {

            EmailCommunicationLog ecl = db.EmailCommunicationLogs.Find(id);

            FormLinks[] fl = db.formLinks.Where(x => x.emailCommunicationLogId == id).Where(x=>x.isPath.Equals(false)).ToArray();

            var body = "";
           // body += "<p>";

            for (int i = 0; i < fl.Count(); i++)
            { body += "\n";
              body += fl[i].formLink;
            }

         //   body += "</p>";

            FormLinks[] filenames = db.formLinks.Where(x => x.emailCommunicationLogId == id).Where(x => x.isPath.Equals(true)).ToArray();



            for (int i = 0; i < filenames.Count(); i++)
            {
                body += "\n";
                body += Path.GetFileName(filenames[i].formLink);
                
            }




            ecl.Body += body;





                return View(ecl);
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
