using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 
This class handles email communications.

 
 */


namespace IsasWebPortal.Models
{
    public partial class EmailCommunicationLog
    {
        [Required]
        public int Id { get; set; }


        //foreign key from ClientCase Model
        public int clientCaseId { get; set; }

       
        
        //foreign key from FormData Model
       // public int formDataId { get; set; }

        //foreign key from FormTemplates Model
       // public int formTemplatesId { get; set; }


        //foreign key from FormTemplates Model
        public int agreementTemplatesId { get; set; }

        //foreign key from EmailTemplates Model
        public int emailTemplatesId { get; set; }

       



        public virtual ClientCase clientCaseConfigs { get; set; }
        
       


       // public virtual FormTemplates formTemplatess { get; set; }
        public virtual EmailTemplates emailTemplatess { get; set; }
        public virtual AgreementTemplates agreementTemplatess { get; set; }




        [DataType(DataType.MultilineText)]
        [Display(Name = "Body")]
        [DisplayName("Body")]
        [Column("Body")]
        public string Body { get; set; }


        [DataType(DataType.DateTime)]
        [Required]
        public DateTime timeStamp { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string toAddress {get; set;}

        [DataType(DataType.EmailAddress)]
        [Required]
        public string fromAddress { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required]
        public string defaultEmailAddress { get; set; }


       

        
        public Boolean isSent {get; set;}
        
        public Boolean isReceived { get; set; }

        public int emailvaultid { get; set; }


        public virtual EmailVault emailVault { get; set; }

        public virtual ICollection<FormLinks> formlinkss { get; set; }
       
        public virtual ICollection<Attachments> attachmentss { get; set; }

        public virtual ICollection<FormData> formDatass { get; set; }


    }

}