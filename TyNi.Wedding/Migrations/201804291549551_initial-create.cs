namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankHolidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseNumberOrName = c.String(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Town = c.String(),
                        Postcode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        MiddleNames = c.String(),
                        Surname = c.String(nullable: false),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAddresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.CustomerContactMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Detail = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        IsPrimary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        QuoteDate = c.DateTime(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        Adults = c.Int(nullable: false),
                        Children = c.Int(nullable: false),
                        Teens = c.Int(nullable: false),
                        Evening = c.Int(nullable: false),
                        Package_Id = c.Int(),
                        Quoter_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceTariffs", t => t.Package_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Quoter_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.Quoter_Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        PricePerHead = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuSections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        PricePerHead = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Order = c.Int(nullable: false),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        ShortDescription = c.String(),
                        Image = c.Binary(),
                        Thumb = c.Binary(),
                        Order = c.Int(nullable: false),
                        MenuSection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuSections", t => t.MenuSection_Id)
                .Index(t => t.MenuSection_Id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceTariffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActiveFrom = c.DateTime(nullable: false),
                        ActiveTo = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        BankHolidayInclusive = c.Boolean(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IncludedDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        CostOverride = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Level = c.Byte(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.CustomerContactMethodCustomers",
                c => new
                    {
                        CustomerContactMethod_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerContactMethod_Id, t.Customer_Id })
                .ForeignKey("dbo.CustomerContactMethods", t => t.CustomerContactMethod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.CustomerContactMethod_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.QuoteCustomers",
                c => new
                    {
                        Quote_Id = c.Guid(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Quote_Id, t.Customer_Id })
                .ForeignKey("dbo.Quotes", t => t.Quote_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Quote_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.MenuQuotes",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Quote_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Quote_Id })
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Quotes", t => t.Quote_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id)
                .Index(t => t.Quote_Id);
            
            CreateTable(
                "dbo.VenueMenus",
                c => new
                    {
                        Venue_Id = c.Int(nullable: false),
                        Menu_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Venue_Id, t.Menu_Id })
                .ForeignKey("dbo.Venues", t => t.Venue_Id, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .Index(t => t.Venue_Id)
                .Index(t => t.Menu_Id);
            
            CreateTable(
                "dbo.IncludedDayPriceTariffs",
                c => new
                    {
                        IncludedDay_Id = c.Int(nullable: false),
                        PriceTariff_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IncludedDay_Id, t.PriceTariff_Id })
                .ForeignKey("dbo.IncludedDays", t => t.IncludedDay_Id, cascadeDelete: true)
                .ForeignKey("dbo.PriceTariffs", t => t.PriceTariff_Id, cascadeDelete: true)
                .Index(t => t.IncludedDay_Id)
                .Index(t => t.PriceTariff_Id);
            
            CreateTable(
                "dbo.PriceTariffVenues",
                c => new
                    {
                        PriceTariff_Id = c.Int(nullable: false),
                        Venue_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PriceTariff_Id, t.Venue_Id })
                .ForeignKey("dbo.PriceTariffs", t => t.PriceTariff_Id, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.Venue_Id, cascadeDelete: true)
                .Index(t => t.PriceTariff_Id)
                .Index(t => t.Venue_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Quotes", "Quoter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quotes", "Package_Id", "dbo.PriceTariffs");
            DropForeignKey("dbo.PriceTariffVenues", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.PriceTariffVenues", "PriceTariff_Id", "dbo.PriceTariffs");
            DropForeignKey("dbo.IncludedDayPriceTariffs", "PriceTariff_Id", "dbo.PriceTariffs");
            DropForeignKey("dbo.IncludedDayPriceTariffs", "IncludedDay_Id", "dbo.IncludedDays");
            DropForeignKey("dbo.VenueMenus", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.VenueMenus", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.MenuQuotes", "Quote_Id", "dbo.Quotes");
            DropForeignKey("dbo.MenuQuotes", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "MenuSection_Id", "dbo.MenuSections");
            DropForeignKey("dbo.MenuSections", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.QuoteCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.QuoteCustomers", "Quote_Id", "dbo.Quotes");
            DropForeignKey("dbo.CustomerContactMethodCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerContactMethodCustomers", "CustomerContactMethod_Id", "dbo.CustomerContactMethods");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.CustomerAddresses");
            DropIndex("dbo.PriceTariffVenues", new[] { "Venue_Id" });
            DropIndex("dbo.PriceTariffVenues", new[] { "PriceTariff_Id" });
            DropIndex("dbo.IncludedDayPriceTariffs", new[] { "PriceTariff_Id" });
            DropIndex("dbo.IncludedDayPriceTariffs", new[] { "IncludedDay_Id" });
            DropIndex("dbo.VenueMenus", new[] { "Menu_Id" });
            DropIndex("dbo.VenueMenus", new[] { "Venue_Id" });
            DropIndex("dbo.MenuQuotes", new[] { "Quote_Id" });
            DropIndex("dbo.MenuQuotes", new[] { "Menu_Id" });
            DropIndex("dbo.QuoteCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.QuoteCustomers", new[] { "Quote_Id" });
            DropIndex("dbo.CustomerContactMethodCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerContactMethodCustomers", new[] { "CustomerContactMethod_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.MenuItems", new[] { "MenuSection_Id" });
            DropIndex("dbo.MenuSections", new[] { "Menu_Id" });
            DropIndex("dbo.Quotes", new[] { "Quoter_Id" });
            DropIndex("dbo.Quotes", new[] { "Package_Id" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropTable("dbo.PriceTariffVenues");
            DropTable("dbo.IncludedDayPriceTariffs");
            DropTable("dbo.VenueMenus");
            DropTable("dbo.MenuQuotes");
            DropTable("dbo.QuoteCustomers");
            DropTable("dbo.CustomerContactMethodCustomers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.IncludedDays");
            DropTable("dbo.PriceTariffs");
            DropTable("dbo.Venues");
            DropTable("dbo.MenuItems");
            DropTable("dbo.MenuSections");
            DropTable("dbo.Menus");
            DropTable("dbo.Quotes");
            DropTable("dbo.CustomerContactMethods");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.BankHolidays");
        }
    }
}
