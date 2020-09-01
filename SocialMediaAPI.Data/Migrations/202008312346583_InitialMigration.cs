namespace SocialMediaAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Author = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.Author, cascadeDelete: true)
                .Index(t => t.Author);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Author", "dbo.User");
            DropIndex("dbo.Post", new[] { "Author" });
            DropTable("dbo.Post");
        }
    }
}
