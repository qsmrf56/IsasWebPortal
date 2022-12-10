using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(EmailCommunicationLogMetadata))]
    public partial class EmailCommunicationLog
    {
    }

    public partial class EmailCommunicationLogMetadata
    {
        [Display(Name = "agreementTemplatess")]
        public AgreementTemplates agreementTemplatess { get; set; }

        [Display(Name = "Attachmentss")]
        public Attachments attachmentss { get; set; }

        [Display(Name = "clientCaseConfigs")]
        public ClientCase clientCaseConfigs { get; set; }

        [Display(Name = "emailTemplatess")]
        public EmailTemplates emailTemplatess { get; set; }

        

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "clientCaseId")]
        public int clientCaseId { get; set; }

        [Display(Name = "agreementTemplatesId")]
        public int agreementTemplatesId { get; set; }

        [Display(Name = "emailTemplatesId")]
        public int emailTemplatesId { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "Time-Stamp")]
        public DateTime timeStamp { get; set; }

        [Display(Name = "To Address")]
        public string toAddress { get; set; }

        [Display(Name = "From Address")]
        public string fromAddress { get; set; }

        [Display(Name = "Default Email Address")]
        public string defaultEmailAddress { get; set; }

       

        [Display(Name = "isSent")]
        public bool isSent { get; set; }

        [Display(Name = "isReceived")]
        public bool isReceived { get; set; }

    }
}
