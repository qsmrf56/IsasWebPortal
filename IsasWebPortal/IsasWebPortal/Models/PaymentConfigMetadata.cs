using System;
using System.ComponentModel.DataAnnotations;

namespace IsasWebPortal.Models
{
    [MetadataType(typeof(PaymentConfigMetadata))]
    public partial class PaymentConfig
    {
    }

    public partial class PaymentConfigMetadata
    {
        [Display(Name = "amountConfig")]
        public AmountConfig amountConfig { get; set; }

        [Display(Name = "Stage")]
        public Stage stage { get; set; }

        [Required(ErrorMessage = "Please enter : PaymentConfigId")]
        [Display(Name = "PaymentConfigId")]
        public long PaymentConfigId { get; set; }

        [Display(Name = "Plan Title")]
        public string planTitle { get; set; }

        [Display(Name = "Payment Sequence No.")]
        public long paymentSeqNum { get; set; }

        [Display(Name = "Percentage")]
        public decimal Percentage { get; set; }

        [Display(Name = "Flat Amount")]
        public decimal flatAmount { get; set; }

    }
}
