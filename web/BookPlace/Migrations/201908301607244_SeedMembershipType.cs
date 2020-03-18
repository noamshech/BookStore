namespace BookPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipType : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO [dbo].[MembershipTypes](Name) VALUES ('Member')");
            Sql("INSERT INTO [dbo].[MembershipTypes](Name) VALUES ('Admin')");
        }
        
        public override void Down()
        {
        }
    }
}
