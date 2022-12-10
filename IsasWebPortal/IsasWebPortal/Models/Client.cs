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
    public partial class Client
    {
        [Required]
        public int clientId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="First Name")]
        public string firstName { get; set; }

        
        [DataType(DataType.Text)]
        [Display(Name = "Middle Name")]
        //[StringLength(maximumLength: 200, MinimumLength = 5)]
        public string middleName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Permanent Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpressionAttribute("^[0-9]+$")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact Number")]
        public string contactNumber { get; set; }

        public virtual ICollection<ClientCase> clientCases { get; set; }
       
    }    
}