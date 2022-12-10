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
    public partial class ApplicationTypeConfig
    {





         [Required]
        public int applicationTypeConfigId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Application Type")]
        [Column("ApplicationType")]
        public string applicationType { get; set; }

        public virtual ICollection<ClientCase> clientCases { get; set; }

       
    }    
}