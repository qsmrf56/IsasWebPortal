using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(FormDataMetadata))]
    public partial class FormData
    {
    }

    public partial class FormDataMetadata
    {
        //[Required(ErrorMessage = "Please enter : clientCase")]
     //   [Display(Name = "clientCase")]
      //  public ClientCase clientCase { get; set; }

        [Display(Name = "formTemplate")]
        public FormTemplates formTemplate { get; set; }
      
        [Display(Name = "emailCommunicationLog")]
        public FormTemplates emailCommunicationLogs { get; set; }

        
        [Display(Name = "formDataId")]
        public int formDataId { get; set; }

       
        [Display(Name = "Attribute1 Data")]
        public string attribute1Data { get; set; }

       
        [Display(Name = "Attribute2 Data")]
        public string attribute2Data { get; set; }

        
        [Display(Name = "Attribute3 Data")]
        public string attribute3Data { get; set; }

        
        [Display(Name = "Attribute4 Data")]
        public string attribute4Data { get; set; }

        
        [Display(Name = "Attribute5 Data")]
        public string attribute5Data { get; set; }

       
        [Display(Name = "Attribute6 Data")]
        public string attribute6Data { get; set; }

        
        [Display(Name = "Attribute7 Data")]
        public string attribute7Data { get; set; }

      
        [Display(Name = "Attribute8 Data")]
        public string attribute8Data { get; set; }

        
        [Display(Name = "Attribute9 Data")]
        public string attribute9Data { get; set; }

       
        [Display(Name = "Attribute10 Data")]
        public string attribute10Data { get; set; }

       
        [Display(Name = "Attribute11 Data")]
        public string attribute11Data { get; set; }

      
        [Display(Name = "Attribute12 Data")]
        public string attribute12Data { get; set; }

       
        [Display(Name = "Attribute13 Data")]
        public string attribute13Data { get; set; }

       
        [Display(Name = "Attribute14 Data")]
        public string attribute14Data { get; set; }

       
        [Display(Name = "Attribute15 Data")]
        public string attribute15Data { get; set; }

        [Display(Name = "formTemplateId")]
        public int formTemplateId { get; set; }

        [Display(Name = "emailCommLogId")]
        public int emailCommLogId { get; set; }

       // [Display(Name = "clientCaseId")]
        //public int clientCaseId { get; set; }

    }
}
