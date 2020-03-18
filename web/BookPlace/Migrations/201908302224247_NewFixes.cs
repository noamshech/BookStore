namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Disable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Disable");
        }
    }
}
