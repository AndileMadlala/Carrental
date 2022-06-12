namespace carrentalservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterViewModels", "Licenceno", c => c.String(nullable: false, maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterViewModels", "Licenceno", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
