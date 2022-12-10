using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 This class represents the countries for which the company aims to follow immigration/education etc. procedures.
 * 
 
 
 */


namespace IsasWebPortal.Models
{
    public partial class CountryConfig
    {
        [Required]
        public int countryConfigId { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Country Name")]
        public string countryName { get; set; }

        public virtual ICollection<ClientCase> clientCases { get; set; }

       
    }    
}