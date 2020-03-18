namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookChangeAddLikes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumOfLikes", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "ISBN");
            DropColumn("dbo.Books", "DataAdded");
            DropColumn("dbo.Books", "ProductDimensions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "ProductDimensions", c => c.String(nullable: false));
            AddColumn("dbo.Books", "DataAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            DropColumn("dbo.Books", "NumOfLikes");
        }
    }
}
