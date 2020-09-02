namespace SocialMediaAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class replyMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "ReplyComment", c => c.String());
            AddColumn("dbo.Comment", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "Discriminator");
            DropColumn("dbo.Comment", "ReplyComment");
        }
    }
}
