namespace carrentalservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.driverQuotes",
                c => new
                    {
                        DriveID = c.Int(nullable: false, identity: true),
                        droploc = c.String(),
                        pickuploc = c.String(),
                        DriverID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriveID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.driverQuotes");
        }
    }
}
