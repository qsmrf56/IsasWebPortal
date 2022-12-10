using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 This class represents the countries for which the company aims to follow immigration/education etc. procedures.
 * 
 
 
 */


namespace IsasWebPortal.Models
{
    public partial class AmountConfig
    {

        [Required]
        public int AmountConfigId { get; set; }


        [Required]
        //[DataType(DataType.Text)]

        //AMOUNT TAG MUST BE UNIQUE
        public string AmountTag { get; set; }


        [Required]
        //RECONSIDER DATATYPE
        [DataType(DataType.Currency)]
        [Display(Name = "Amount")]
        [Column("Amount")]
        public decimal Amount { get; set; }


        public virtual ICollection<PaymentConfig> paymentConfigs { get; set; }



    }
}