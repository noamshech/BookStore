namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addLanguague : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Languague", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Languague");
        }
    }
}
