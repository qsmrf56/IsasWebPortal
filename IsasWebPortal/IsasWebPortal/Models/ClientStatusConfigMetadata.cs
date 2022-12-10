using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(ClientStatusConfigMetadata))]
    public partial class ClientStatusConfig
    {
    }

    public partial class ClientStatusConfigMetadata
    {
        [Display(Name = "clientCases")]
        public ClientCase clientCases { get; set; }

        [Required(ErrorMessage = "Please enter : ClientStatusConfigId")]
        [Display(Name = "ClientStatusConfigId")]
        public long ClientStatusConfigId { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

    }
}
