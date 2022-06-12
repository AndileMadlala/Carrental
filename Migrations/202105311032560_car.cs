namespace carrentalservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class car : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterViewModels", "Idno", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.RegisterViewModels", "Licenceno", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.RegisterViewModels", "cellphoneno", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterViewModels", "cellphoneno", c => c.Int(nullable: false));
            AlterColumn("dbo.RegisterViewModels", "Licenceno", c => c.Int(nullable: false));
            AlterColumn("dbo.RegisterViewModels", "Idno", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
