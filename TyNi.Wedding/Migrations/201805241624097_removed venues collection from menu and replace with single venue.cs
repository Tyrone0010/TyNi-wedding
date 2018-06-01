namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedvenuescollectionfrommenuandreplacewithsinglevenue : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueMenus", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.VenueMenus", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.VenueMenus", new[] { "Venue_Id" });
            DropIndex("dbo.VenueMenus", new[] { "Menu_Id" });
            AddColumn("dbo.Menus", "Venue_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Venue_Id");
            AddForeignKey("dbo.Menus", "Venue_Id", "dbo.Venues", "Id");
            DropTable("dbo.VenueMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VenueMenus",
                c => new
                    {
                        Venue_Id = c.Int(nullable: false),
                        Menu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venue_Id, t.Menu_Id });
            
            DropForeignKey("dbo.Menus", "Venue_Id", "dbo.Venues");
            DropIndex("dbo.Menus", new[] { "Venue_Id" });
            DropColumn("dbo.Menus", "Venue_Id");
            CreateIndex("dbo.VenueMenus", "Menu_Id");
            CreateIndex("dbo.VenueMenus", "Venue_Id");
            AddForeignKey("dbo.VenueMenus", "Menu_Id", "dbo.Menus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VenueMenus", "Venue_Id", "dbo.Venues", "Id", cascadeDelete: true);
        }
    }
}
