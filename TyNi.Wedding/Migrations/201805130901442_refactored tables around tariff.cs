namespace TyNi.Wedding.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoredtablesaroundtariff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncludedDayPriceTariffs", "IncludedDay_Id", "dbo.IncludedDays");
            DropForeignKey("dbo.IncludedDayPriceTariffs", "PriceTariff_Id", "dbo.PriceTariffs");
            DropIndex("dbo.IncludedDayPriceTariffs", new[] { "IncludedDay_Id" });
            DropIndex("dbo.IncludedDayPriceTariffs", new[] { "PriceTariff_Id" });
            CreateTable(
                "dbo.PriceTariffPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ActiveFrom = c.DateTime(nullable: false),
                        ActiveTo = c.DateTime(nullable: false),
                        PriceTariff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PriceTariffs", t => t.PriceTariff_Id)
                .Index(t => t.PriceTariff_Id);
            
            CreateTable(
                "dbo.PriceTariffPeriodDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceTariffPeriodDayPriceTariffPeriods",
                c => new
                    {
                        PriceTariffPeriodDay_Id = c.Int(nullable: false),
                        PriceTariffPeriod_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PriceTariffPeriodDay_Id, t.PriceTariffPeriod_Id })
                .ForeignKey("dbo.PriceTariffPeriodDays", t => t.PriceTariffPeriodDay_Id, cascadeDelete: true)
                .ForeignKey("dbo.PriceTariffPeriods", t => t.PriceTariffPeriod_Id, cascadeDelete: true)
                .Index(t => t.PriceTariffPeriodDay_Id)
                .Index(t => t.PriceTariffPeriod_Id);
            
            DropColumn("dbo.PriceTariffs", "ActiveFrom");
            DropColumn("dbo.PriceTariffs", "ActiveTo");
            DropColumn("dbo.PriceTariffs", "BankHolidayInclusive");
            DropColumn("dbo.PriceTariffs", "Cost");
            DropTable("dbo.IncludedDays");
            DropTable("dbo.IncludedDayPriceTariffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IncludedDayPriceTariffs",
                c => new
                    {
                        IncludedDay_Id = c.Int(nullable: false),
                        PriceTariff_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IncludedDay_Id, t.PriceTariff_Id });
            
            CreateTable(
                "dbo.IncludedDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.Int(nullable: false),
                        CostOverride = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PriceTariffs", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.PriceTariffs", "BankHolidayInclusive", c => c.Boolean(nullable: false));
            AddColumn("dbo.PriceTariffs", "ActiveTo", c => c.DateTime(nullable: false));
            AddColumn("dbo.PriceTariffs", "ActiveFrom", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.PriceTariffPeriodDayPriceTariffPeriods", "PriceTariffPeriod_Id", "dbo.PriceTariffPeriods");
            DropForeignKey("dbo.PriceTariffPeriodDayPriceTariffPeriods", "PriceTariffPeriodDay_Id", "dbo.PriceTariffPeriodDays");
            DropForeignKey("dbo.PriceTariffPeriods", "PriceTariff_Id", "dbo.PriceTariffs");
            DropIndex("dbo.PriceTariffPeriodDayPriceTariffPeriods", new[] { "PriceTariffPeriod_Id" });
            DropIndex("dbo.PriceTariffPeriodDayPriceTariffPeriods", new[] { "PriceTariffPeriodDay_Id" });
            DropIndex("dbo.PriceTariffPeriods", new[] { "PriceTariff_Id" });
            DropTable("dbo.PriceTariffPeriodDayPriceTariffPeriods");
            DropTable("dbo.PriceTariffPeriodDays");
            DropTable("dbo.PriceTariffPeriods");
            CreateIndex("dbo.IncludedDayPriceTariffs", "PriceTariff_Id");
            CreateIndex("dbo.IncludedDayPriceTariffs", "IncludedDay_Id");
            AddForeignKey("dbo.IncludedDayPriceTariffs", "PriceTariff_Id", "dbo.PriceTariffs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IncludedDayPriceTariffs", "IncludedDay_Id", "dbo.IncludedDays", "Id", cascadeDelete: true);
        }
    }
}
