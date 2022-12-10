namespace IsasWebPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsasWebPortalIsasWebPortalModelsIsasWebPortalDataContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FormLinks", "isPath", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FormLinks", "isPath");
        }
    }
}
