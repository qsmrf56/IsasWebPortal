using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 
 This class represents a single client for the agency.
 
 The attributes represent the basic attributes of a client,
 and would be the most preliminary fields a client will be 
 inquired for.
 
 */


namespace IsasWebPortal.Models
{
    public partial class Payments
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DefaultValue(false)]
        public Boolean isPaid { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Payment Mode Number")]
        [DisplayName("Payment Mode Number")]
        public string paymentModeNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public long Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime invoiceGenerationDateTime { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public long latePaymentFine { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dueDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime paymentDate { get; set; }

        //foreign key from ClientCase Model
        public int clientCaseId { get; set; }

        //foreign key from PaymentMode Model
        public int paymentModeId { get; set; }

        //foreign key from PaymentConfig Model
        public int PaymentConfigId { get; set; }

        public virtual ClientCase clientCases { get; set; }
        public virtual PaymentModes paymentModess { get; set; }
      
        
        public virtual PaymentConfig paymentConfigs { get; set; }
       

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "E-Mail Address")]
        [DisplayName("E-Mail Address")]
        [Column("email")]
        public string email { get; set; }
   
        
    
    }    

}