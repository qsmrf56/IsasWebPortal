using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(ApplicationTypeConfigMetadata))]
    public partial class ApplicationTypeConfig
    {
    }

    public partial class ApplicationTypeConfigMetadata
    {
        [Display(Name = "clientCases")]
        public ClientCase clientCases { get; set; }

       
        [Required]
        [Display(Name = "applicationTypeConfigId")]
        public int applicationTypeConfigId { get; set; }

        [Display(Name = "Application Type")]
        public string applicationType { get; set; }

    }
}
