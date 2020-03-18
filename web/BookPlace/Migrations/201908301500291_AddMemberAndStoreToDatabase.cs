namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberAndStoreToDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "BookId", "dbo.Books");
            DropForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "BookId" });
            DropIndex("dbo.Likes", new[] { "User_Id" });
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CoordinateAlt = c.Double(nullable: false),
                        CoordinateLng = c.Double(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StoreBooks",
                c => new
                    {
                        Store_StoreId = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Store_StoreId, t.Book_Id })
                .ForeignKey("dbo.Stores", t => t.Store_StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Store_StoreId)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "NumOfLikes");
            DropTable("dbo.Likes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LikeId);
            
            AddColumn("dbo.Books", "NumOfLikes", c => c.Int(nullable: false));
            DropForeignKey("dbo.StoreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.StoreBooks", "Store_StoreId", "dbo.Stores");
            DropIndex("dbo.StoreBooks", new[] { "Book_Id" });
            DropIndex("dbo.StoreBooks", new[] { "Store_StoreId" });
            DropTable("dbo.StoreBooks");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Stores");
            CreateIndex("dbo.Likes", "User_Id");
            CreateIndex("dbo.Likes", "BookId");
            AddForeignKey("dbo.Likes", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Likes", "BookId", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
