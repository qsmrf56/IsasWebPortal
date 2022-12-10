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
    public partial class ClientCase
    {
        [Required]
        public int Id { get; set; }


        //foreign key from ClientStatusConfig Model
        public int clientStatusConfigId { get; set; }

        //foreign key from ApplicationTypeConfig Model
        public int applicationTypeConfigId { get; set; }

        //foreign key from CountryConfig Model

        public int countryConfigId { get; set; }

        //foreign key from Client Model
        public int clientId { get; set; }

        //foreign key from Stage Model
        public int stageId { get; set; }

        public virtual ClientStatusConfig clientStatusConfigs { get; set; }
        public virtual ApplicationTypeConfig applicationTypeConfigs { get; set; }
      
        
        public virtual CountryConfig CountryConfigs { get; set; }
        public virtual Client client { get; set; }
        public virtual Stage stage { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "E-Mail Address")]
        [DisplayName("E-Mail Address")]
        [Column("email")]
        public string email { get; set; }

        public virtual ICollection<Payments> payments { get; set; }
       // public virtual ICollection<FormData> formData { get; set; }
    
    
    }    

}