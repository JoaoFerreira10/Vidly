namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRental : DbMigration
    {
        public override void Up()
        {
            Sql("Drop table Rentals");
        }
        
        public override void Down()
        {
        }
    }
}
