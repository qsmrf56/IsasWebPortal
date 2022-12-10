using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(ConfigurationsMetadata))]
    public partial class Configurations
    {
    }

    public partial class ConfigurationsMetadata
    {
       

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Param 1")]
        public string param1 { get; set; }

        [Display(Name = "Param 2")]
        public string param2 { get; set; }

        [Display(Name = "Param 3")]
        public string param3 { get; set; }

        [Display(Name = "Param 4")]
        public string param4 { get; set; }

        [Display(Name = "Param 5")]
        public string param5 { get; set; }

        [Display(Name = "Param 6")]
        public string param6 { get; set; }


    }
}
