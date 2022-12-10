using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(AttachmentsMetadata))]
    public partial class Attachments
    {
    }

    public partial class AttachmentsMetadata
    {
        [Display(Name = "emailCommunicationLogs")]
        public EmailCommunicationLog emailCommunicationLogs { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Attachment Path")]
        public string attachmentPath { get; set; }

        [Display(Name = "emailCommunicationLogId")]
        public int emailCommunicationLogId { get; set; }

    }
}
