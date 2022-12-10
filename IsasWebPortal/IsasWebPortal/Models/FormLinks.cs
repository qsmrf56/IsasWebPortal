using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IsasWebPortal.Models
{
    public partial class FormLinks
    {
        
        public int id { get; set; }


        
      //  [DataType(DataType.Url)]
        public string formLink { get; set; }


        public bool isPath { get; set; }


        //foreign key for emailcommlog
        public int emailCommunicationLogId { get; set; }

        //public int formDataId { get; set; }

        public int formTemplatesId { get; set; }

        public virtual EmailCommunicationLog emailcommlogs { get; set; }

        //public virtual FormData formDatas { get; set; }

        public virtual FormTemplates formTemplatess { get; set; }

    
    
    }
}