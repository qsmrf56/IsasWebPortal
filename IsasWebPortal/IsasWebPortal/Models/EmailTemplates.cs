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
    public partial class EmailTemplates
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string templateName { get; set; }

   


        [DataType(DataType.MultilineText)]
        [Display(Name = "Body")]
        [DisplayName("Body")]
        [Column("Body")]
        public string Body { get; set; }


          public virtual ICollection<EmailCommunicationLog> emailCommunicationLogs { get; set; }
      


    }

}