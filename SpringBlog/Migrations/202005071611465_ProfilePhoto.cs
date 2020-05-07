namespace SpringBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePhoto", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePhoto");
        }
    }
}
