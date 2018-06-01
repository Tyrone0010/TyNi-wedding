namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmenuwithrequiredfieldwhichcanbeusedforvalidation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Required", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Required");
        }
    }
}
