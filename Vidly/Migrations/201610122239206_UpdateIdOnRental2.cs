namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIdOnRental2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
        }
    }
}
