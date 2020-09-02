namespace SocialMediaAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likeUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Post", "Id");
            AddColumn("dbo.Post", "PostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Post", "PostId");

            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        LikerId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: false)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Like", "UserId", "dbo.User");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropIndex("dbo.Like", new[] { "UserId" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Post", "PostId");
            DropTable("dbo.Like");
            AddPrimaryKey("dbo.Post", "Id");
        }
    }
}
