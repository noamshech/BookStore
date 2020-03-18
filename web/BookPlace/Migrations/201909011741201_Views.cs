namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Views : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Book_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Book_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Views", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Views", "Book_Id", "dbo.Books");
            DropIndex("dbo.Views", new[] { "User_Id" });
            DropIndex("dbo.Views", new[] { "Book_Id" });
            DropTable("dbo.Views");
        }
    }
}
