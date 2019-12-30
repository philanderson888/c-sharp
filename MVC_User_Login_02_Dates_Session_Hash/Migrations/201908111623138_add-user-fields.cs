namespace MVC_User_Login.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedBy", c => c.String());
            AddColumn("dbo.Users", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedBy");
            DropColumn("dbo.Users", "ModifiedBy");
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreatedDate");
            DropColumn("dbo.Users", "IsActive");
        }
    }
}
