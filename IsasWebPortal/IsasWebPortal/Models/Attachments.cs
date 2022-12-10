using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsasWebPortal.Models
{
    public partial class Attachments
    {

        [Required]
        public int Id { get; set; }


        public string attachmentPath { get; set; }


        //foreign key from Email Communication Log Model
        public int emailCommunicationLogId { get; set; }

        public virtual EmailCommunicationLog emailCommunicationLogs { get; set; }
      
      
    
    
    
    
    
    }
}