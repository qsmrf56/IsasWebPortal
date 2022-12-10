using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(FormTemplatesMetadata))]
    public partial class FormTemplates
    {
    }

    public partial class FormTemplatesMetadata
    {
       // [Display(Name = "formData")]
       // public FormData formData { get; set; }

        
        [Display(Name = "formsTypes")]
        public FormTypes formsTypes { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Form Name")]
        public string formName { get; set; }

        [Display(Name = "Attribute1")]
        public string attribute1 { get; set; }

        [Display(Name = "Attribute2")]
        public string attribute2 { get; set; }

        [Display(Name = "Attribute3")]
        public string attribute3 { get; set; }

        [Display(Name = "Attribute4")]
        public string attribute4 { get; set; }

        [Display(Name = "Attribute5")]
        public string attribute5 { get; set; }

        [Display(Name = "Attribute6")]
        public string attribute6 { get; set; }

        [Display(Name = "Attribute7")]
        public string attribute7 { get; set; }

        [Display(Name = "Attribute8")]
        public string attribute8 { get; set; }

        [Display(Name = "Attribute9")]
        public string attribute9 { get; set; }

        [Display(Name = "Attribute10")]
        public string attribute10 { get; set; }

        [Display(Name = "Attribute11")]
        public string attribute11 { get; set; }

        [Display(Name = "Attribute12")]
        public string attribute12 { get; set; }

        [Display(Name = "Attribute13")]
        public string attribute13 { get; set; }

        [Display(Name = "Attribute14")]
        public string attribute14 { get; set; }

        [Display(Name = "Attribute15")]
        public string attribute15 { get; set; }

        [Display(Name = "formTypeId")]
        public int formTypeId { get; set; }

    }
}
