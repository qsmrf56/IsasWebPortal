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
    public partial class Stage
    {
        [Required]
        public int StageId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        //consider DATATYPE
        [Display(Name = "SequenceNumber")]
        [Column("SequenceNumber")]
        public int sequenceNumber { get; set; }

        public virtual ICollection<PaymentConfig> paymentConfigs { get; set; }
        public virtual ICollection<ClientCase> clientCases { get; set; }
       
    }    
}