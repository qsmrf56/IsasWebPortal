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
    public partial class Configurations
    {
        [Required]
        public int Id { get; set; }


        
        [DataType(DataType.Text)]
        public string param1 { get; set; }

        [DataType(DataType.Text)]
        public string param2 { get; set; }

        [DataType(DataType.Text)]
        public string param3 { get; set; }

        [DataType(DataType.Text)]
        public string param4 { get; set; }

        [DataType(DataType.Text)]
        public string param5 { get; set; }

        [DataType(DataType.Text)]
        public string param6 { get; set; }

       

        public virtual ICollection<AgreementTemplates> agreementTemplatess { get; set; }

       
    }    
}