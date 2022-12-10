using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(CountryConfigMetadata))]
    public partial class CountryConfig
    {
    }

    public partial class CountryConfigMetadata
    {
        [Display(Name = "clientCases")]
        public ClientCase clientCases { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "countryConfigId")]
        public int countryConfigId { get; set; }

        [Required(ErrorMessage = "Please enter : countryName")]
        [Display(Name = "Country Name")]
        public string countryName { get; set; }

    }
}
