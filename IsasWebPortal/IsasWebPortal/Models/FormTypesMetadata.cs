using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(FormTypesMetadata))]
    public partial class FormTypes
    {
    }

    public partial class FormTypesMetadata
    {
        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Form Type")]
        public int formType { get; set; }

        [Display(Name = "Number Of Attributes")]
        public int numberOfAttributes { get; set; }

    }
}
