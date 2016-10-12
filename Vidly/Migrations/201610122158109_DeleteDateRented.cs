namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDateRented : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rentals", "DateReturned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "DateReturned", c => c.DateTime());
        }
    }
}
