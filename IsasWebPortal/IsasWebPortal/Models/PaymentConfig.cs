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
    public partial class PaymentConfig
    {
        [Required]
        public int PaymentConfigId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Plan Title")]
        [Column("PlanTitle")]
        public string planTitle { get; set; }


        [Required]
       // [DataType(DataType.Text)]
        [Display(Name = "Payment Sequence Number")]
        [Column("PaymentSeqNum")]
        public Int64 paymentSeqNum { get; set; }

        [Required]
        // [DataType(DataType.Text)]
        [Display(Name = "Percentage")]
        [Column("Percentage")]
        public decimal Percentage { get; set; }


        [Required]
        // [DataType(DataType.Text)]
        [DataType(DataType.Currency)]
        [Display(Name = "Flat Amount")]
        [Column("FlatAmount")]
        public decimal flatAmount { get; set; }


        //foreign key from Stage Model
       
        public long StageId;
        
        //foreign key from AmountConfig Model
       
        public string AmountConfigId;

        public virtual Stage stage{ get; set; }
        public virtual AmountConfig amountConfig{ get; set; }

        public virtual ICollection<Payments> payments { get; set; }
     

       
    }    
}