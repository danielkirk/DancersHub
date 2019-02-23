namespace DanceHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class helpme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dancers", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dancers", "UserId");
        }
    }
}
