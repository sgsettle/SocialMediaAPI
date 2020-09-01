namespace SocialMediaAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hope : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Post", "UserId", "dbo.User");
            DropIndex("dbo.Post", new[] { "UserId" });
            AddColumn("dbo.User", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Title", c => c.String());
            AddColumn("dbo.User", "Text", c => c.String());
            DropTable("dbo.Post");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.User", "Text");
            DropColumn("dbo.User", "Title");
            DropColumn("dbo.User", "Id");
            CreateIndex("dbo.Post", "UserId");
            AddForeignKey("dbo.Post", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
