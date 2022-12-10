using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(EmailTemplatesMetadata))]
    public partial class EmailTemplates
    {
    }

    public partial class EmailTemplatesMetadata
    {
        [Display(Name = "emailCommunicationLogs")]
        public EmailCommunicationLog emailCommunicationLogs { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Template Name")]
        public string templateName { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

    }
}
