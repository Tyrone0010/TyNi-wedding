using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Diagnostics;
using TyNi.Wedding.Infrastructure.Models;

namespace TyNi.Wedding.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<BankHoliday> BankHolidays { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<CustomerContactMethod> CustomerContactMethods { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuSection> MenuSections { get; set; }
        public DbSet<PriceTariff> PriceTariffs { get; set; }
        public DbSet<PriceTariffPeriod> PriceTariffPeriods { get; set; }
        public DbSet<PriceTariffPeriodDay> PriceTariffPeriodDays { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Venue> Venues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.Log = (query) => Debug.Write(query);

            base.OnModelCreating(modelBuilder);
        }
    }
}