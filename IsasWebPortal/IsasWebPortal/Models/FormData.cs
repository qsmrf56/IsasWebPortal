using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 
 This class represents a Form Template for the forms used by the agency.
 
 
 */


namespace IsasWebPortal.Models
{
    public partial class FormData
    {
        [Required]
        public int formDataId { get; set; }

       
        
        [DataType(DataType.Text)]
        [Display(Name = "attribute1Data")]
        public string attribute1Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute2Data")]
        public string attribute2Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute3Data")]
        public string attribute3Data { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "attribute4Data")]
        public string attribute4Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute5Data")]
        public string attribute5Data { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "attribute6Data")]
        public string attribute6Data { get; set; }

        

        [DataType(DataType.Text)]
        [Display(Name = "attribute7Data")]
        public string attribute7Data { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "attribute8Data")]
        public string attribute8Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute9Data")]
        public string attribute9Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute10Data")]
        public string attribute10Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute11Data")]
        public string attribute11Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute12Data")]
        public string attribute12Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute13Data")]
        public string attribute13Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute14Data")]
        public string attribute14Data { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute15Data")]
        public string attribute15Data { get; set; }

        //foreign key from FormTemplates Model
        public int formTemplateId { get; set; }

        //foreign key from EmailCommunicationLog Model
        public int emailCommLogId { get; set; }

        //foreign key from ClientCase Model
       // public int clientCaseId { get; set; }

        //public int formlinkId { get; set; }


        //public virtual FormLinks formLink { get; set; }


        public virtual FormTemplates formTemplate { get; set; }
        public virtual EmailCommunicationLog emailCommunicationLogs { get; set; }
       // public virtual ClientCase clientCase { get; set; }
       
    }    
}