using System.Data.Entity;
using IsasWebPortal.Models;

namespace IsasWebPortal.IsasWebPortal.Models
{
    public class IsasWebPortalDataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<IsasWebPortal.IsasWebPortal.Models.IsasWebPortalDataContext>());

        public IsasWebPortalDataContext()
            : base("name=IsasWebPortal.IsasWebPortal.Models.IsasWebPortalDataContext")
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CountryConfig> CountryConfigs { get; set; }

        public DbSet<ClientCase> ClientCases { get; set; }

        public DbSet<ClientStatusConfig> ClientStatusConfigs { get; set; }

        public DbSet<ApplicationTypeConfig> ApplicationTypeConfigs { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public System.Data.Entity.DbSet<AmountConfig> AmountConfigs { get; set; }

        public System.Data.Entity.DbSet<PaymentConfig> PaymentConfigs { get; set; }

        public DbSet<Payments> Payments { get; set; }

        public DbSet<PaymentModes> PaymentModes { get; set; }

        public DbSet<FormTemplates> FormTemplatess { get; set; }

        public DbSet<FormTypes> FormTypess { get; set; }

        public DbSet<FormData> FormDatas { get; set; }

        public DbSet<EmailTemplates> EmailTemplatess { get; set; }

        public DbSet<AgreementTemplates> AgreementTemplatess { get; set; }

        public DbSet<EmailCommunicationLog> EmailCommunicationLogs { get; set; }

        public DbSet<Configurations> Configurationss { get; set; }

        public DbSet<Attachments> Attachmentss { get; set; }

        public DbSet<EmailVault> emailVaultss { get; set; }

        public DbSet<FormLinks> formLinks { get; set; }


       




    }
}
