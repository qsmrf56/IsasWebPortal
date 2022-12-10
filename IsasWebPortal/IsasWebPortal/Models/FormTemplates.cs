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
    public partial class FormTemplates
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Form Name")]
        public string formName { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "attribute1")]
        public string attribute1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute2")]
        public string attribute2 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute3")]
        public string attribute3 { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "attribute4")]
        public string attribute4 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute5")]
        public string attribute5 { get; set; }


      

        [DataType(DataType.Text)]
        [Display(Name = "attribute6")]
        public string attribute6 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute7")]
        public string attribute7 { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "attribute8")]
        public string attribute8 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute9")]
        public string attribute9 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute10")]
        public string attribute10 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute11")]
        public string attribute11 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute12")]
        public string attribute12 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute13")]
        public string attribute13 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute14")]
        public string attribute14 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "attribute15")]
        public string attribute15 { get; set; }

        //foreign key from FormTypes Model
        public int formTypeId { get; set; }


        public virtual FormTypes formsTypes { get; set; }
        public virtual ICollection<FormLinks> formLinkss { get; set; }
        public virtual ICollection<FormData> formDatass { get; set; }
       
    }    
}