namespace TyNi.Wedding.AuthApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdquotestructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Thumbnail = c.Binary(),
                        MenuItemType_Id = c.Int(),
                        Menu_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItemTypes", t => t.MenuItemType_Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.MenuItemType_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.MenuItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.Binary(),
                        Menuype_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuTypes", t => t.Menuype_Id)
                .Index(t => t.Menuype_Id);
            
            CreateTable(
                "dbo.MenuTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageSeasons",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Package_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.Package_Id);
            
            CreateTable(
                "dbo.PackageSeasonDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.Short(nullable: false),
                        PackageSeason_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageSeasons", t => t.PackageSeason_Id)
                .Index(t => t.PackageSeason_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackageSeasonDays", "PackageSeason_Id", "dbo.PackageSeasons");
            DropForeignKey("dbo.PackageSeasons", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Menus", "Menuype_Id", "dbo.MenuTypes");
            DropForeignKey("dbo.MenuItems", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "MenuItemType_Id", "dbo.MenuItemTypes");
            DropIndex("dbo.PackageSeasonDays", new[] { "PackageSeason_Id" });
            DropIndex("dbo.PackageSeasons", new[] { "Package_Id" });
            DropIndex("dbo.Menus", new[] { "Menuype_Id" });
            DropIndex("dbo.MenuItems", new[] { "Menu_Id" });
            DropIndex("dbo.MenuItems", new[] { "MenuItemType_Id" });
            DropTable("dbo.PackageSeasonDays");
            DropTable("dbo.PackageSeasons");
            DropTable("dbo.Packages");
            DropTable("dbo.MenuTypes");
            DropTable("dbo.Menus");
            DropTable("dbo.MenuItemTypes");
            DropTable("dbo.MenuItems");
        }
    }
}
