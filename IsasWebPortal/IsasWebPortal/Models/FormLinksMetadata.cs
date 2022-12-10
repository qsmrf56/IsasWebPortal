using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(FormLinksMetadata))]
    public partial class FormLinks
    {
    }

    public partial class FormLinksMetadata
    {
        [Display(Name = "emailcommlogs")]
        public EmailCommunicationLog emailcommlogs { get; set; }

        [Display(Name = "formTemplatess")]
        public FormTemplates formTemplatess { get; set; }

        //[Display(Name = "formDatas")]
        //public FormData formDatas { get; set; }
        [Display(Name = "isPath")]
        public bool isPath { get; set; }

        
        [Display(Name = "id")]
        public int id { get; set; }

        [Display(Name = "Form Link")]
        public string formLink { get; set; }

        [Display(Name = "emailCommunicationLogId")]
        public int emailCommunicationLogId { get; set; }

        //[Display(Name = "formDataId")]
        //public int formDataId { get; set; }

        [Display(Name = "formTemplatesId")]
        public int formTemplatesId { get; set; }

    }
}
