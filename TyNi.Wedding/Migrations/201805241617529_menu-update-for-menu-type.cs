namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuupdateformenutype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menus", "MenuType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "MenuType");
            DropColumn("dbo.Menus", "Price");
        }
    }
}
