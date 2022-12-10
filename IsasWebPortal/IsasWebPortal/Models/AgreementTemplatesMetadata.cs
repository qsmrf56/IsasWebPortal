using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(AgreementTemplatesMetadata))]
    public partial class AgreementTemplates
    {
    }

    public partial class AgreementTemplatesMetadata
    {
        [Display(Name = "emailCommunicationLogs")]
        public EmailCommunicationLog emailCommunicationLogs { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Template Name")]
        public string templateName { get; set; }

        [Display(Name = "Header Graphic Top-Left")]
        public string headerGraphicTL { get; set; }

        [Display(Name = "Header Graphic Middle")]
        public string headerGraphicM { get; set; }

        [Display(Name = "Header Graphic Top-Right")]
        public string headerGraphicTR { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        [Display(Name = "Signature")]
        public string signature { get; set; }

    }
}
