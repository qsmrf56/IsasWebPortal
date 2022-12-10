using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsasWebPortal.Models
{
    public class PaymentModes
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Payment Mode")]
        public string paymentModeTitle { get; set; }

        public virtual ICollection<Payments> payments { get; set; }

    }
}