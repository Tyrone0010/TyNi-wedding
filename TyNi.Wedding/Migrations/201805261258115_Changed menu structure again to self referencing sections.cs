namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedmenustructureagaintoselfreferencingsections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuSections", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.MenuSections", "Parent_Id", c => c.Int());
            CreateIndex("dbo.MenuSections", "Parent_Id");
            AddForeignKey("dbo.MenuSections", "Parent_Id", "dbo.MenuSections", "Id");
            DropColumn("dbo.Menus", "Price");
            DropColumn("dbo.MenuSections", "PricePerHead");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuSections", "PricePerHead", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menus", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.MenuSections", "Parent_Id", "dbo.MenuSections");
            DropIndex("dbo.MenuSections", new[] { "Parent_Id" });
            DropColumn("dbo.MenuSections", "Parent_Id");
            DropColumn("dbo.MenuSections", "Price");
        }
    }
}
