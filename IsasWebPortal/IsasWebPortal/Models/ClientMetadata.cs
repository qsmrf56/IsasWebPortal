using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(ClientMetadata))]
    public partial class Client
    {
    }

    public partial class ClientMetadata
    {
        [Display(Name = "clientCases")]
        public ClientCase clientCases { get; set; }

        [Required(ErrorMessage = "Please enter : Id")]
        [Display(Name = "Id")]
        public long clientId { get; set; }

        [Required(ErrorMessage = "Please enter : firstName")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Middle Name")]
        public string middleName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter : contactNumber")]
        [Display(Name = "Contact Number")]
        public string contactNumber { get; set; }

    }
}
