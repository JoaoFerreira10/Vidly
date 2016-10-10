namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAvailableInMovie : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET Available = NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
