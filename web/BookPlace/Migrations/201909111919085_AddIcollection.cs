namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIcollection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "User_Id");
            AddForeignKey("dbo.Books", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropColumn("dbo.Books", "User_Id");
        }
    }
}
