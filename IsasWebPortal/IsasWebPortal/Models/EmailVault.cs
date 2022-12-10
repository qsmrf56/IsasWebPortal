using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class EmailVault
    {
        [Required]
        public int id { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string email { get; set; }
        

        public virtual ICollection<EmailCommunicationLog> emailcommlogs { get; set; }
       
    }    
}