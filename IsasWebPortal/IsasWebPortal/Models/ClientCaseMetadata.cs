using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(ClientCaseMetadata))]
    public partial class ClientCase
    {
    }

    public partial class ClientCaseMetadata
    {
        [Display(Name = "applicationTypeConfigs")]
        public ApplicationTypeConfig applicationTypeConfigs { get; set; }

        [Display(Name = "client")]
        public Client client { get; set; }

        [Display(Name = "clientStatusConfigs")]
        public ClientStatusConfig clientStatusConfigs { get; set; }

        [Display(Name = "CountryConfigs")]
        public CountryConfig CountryConfigs { get; set; }

        [Display(Name = "Stage")]
        public Stage stage { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public long Id { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

    }
}
