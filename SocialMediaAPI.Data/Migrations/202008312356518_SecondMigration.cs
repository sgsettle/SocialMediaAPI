namespace SocialMediaAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Post", name: "Author", newName: "UserId");
            RenameIndex(table: "dbo.Post", name: "IX_Author", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Post", name: "IX_UserId", newName: "IX_Author");
            RenameColumn(table: "dbo.Post", name: "UserId", newName: "Author");
        }
    }
}
