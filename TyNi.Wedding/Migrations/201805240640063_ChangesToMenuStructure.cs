namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToMenuStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuQuotes", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuQuotes", "Quote_Id", "dbo.Quotes");
            DropIndex("dbo.MenuQuotes", new[] { "Menu_Id" });
            DropIndex("dbo.MenuQuotes", new[] { "Quote_Id" });
            AddColumn("dbo.Menus", "Quote_Id", c => c.Guid());
            AlterColumn("dbo.MenuSections", "Description", c => c.String());
            CreateIndex("dbo.Menus", "Quote_Id");
            AddForeignKey("dbo.Menus", "Quote_Id", "dbo.Quotes", "Id");
            DropColumn("dbo.Menus", "PricePerHead");
            DropTable("dbo.MenuQuotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuQuotes",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Quote_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Quote_Id });
            
            AddColumn("dbo.Menus", "PricePerHead", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Menus", "Quote_Id", "dbo.Quotes");
            DropIndex("dbo.Menus", new[] { "Quote_Id" });
            AlterColumn("dbo.MenuSections", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Menus", "Quote_Id");
            CreateIndex("dbo.MenuQuotes", "Quote_Id");
            CreateIndex("dbo.MenuQuotes", "Menu_Id");
            AddForeignKey("dbo.MenuQuotes", "Quote_Id", "dbo.Quotes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuQuotes", "Menu_Id", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
