namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAvailableToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Available", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Available");
        }
    }
}
