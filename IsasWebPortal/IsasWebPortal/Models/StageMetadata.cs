using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(StageMetadata))]
    public partial class Stage
    {
    }

    public partial class StageMetadata
    {
        [Display(Name = "clientCases")]
        public ClientCase clientCases { get; set; }

        [Display(Name = "paymentConfigs")]
        public PaymentConfig paymentConfigs { get; set; }

        [Required(ErrorMessage = "Please enter : StageId")]
        [Display(Name = "StageId")]
        public int StageId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Sequence Number")]
        public int sequenceNumber { get; set; }

    }
}
