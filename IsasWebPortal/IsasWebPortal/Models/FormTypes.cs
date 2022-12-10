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
    public partial class FormTypes
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Form Type")]
        public string formType { get; set; }

        [Required]
        [Display(Name = "Number of Attributes")]
        public int numberOfAttributes { get; set; }

        public virtual ICollection<FormTemplates> formTemplates { get; set; }
       
    }    
}