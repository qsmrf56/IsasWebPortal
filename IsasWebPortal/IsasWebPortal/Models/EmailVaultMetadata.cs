using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(EmailVaultMetadata))]
    public partial class EmailVault
    {
    }

    public partial class EmailVaultMetadata
    {
        [Display(Name = "emailcommlogs")]
        public EmailCommunicationLog emailcommlogs { get; set; }

        [Required(ErrorMessage = "Please enter : id")]
        [Display(Name = "id")]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter : password")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please enter : email")]
        [Display(Name = "Email Address")]
        public string email { get; set; }

    }
}
