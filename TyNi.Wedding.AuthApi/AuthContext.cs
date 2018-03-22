using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using TyNi.Wedding.AuthApi.DomainModels.Quote;

namespace TyNi.Wedding.AuthApi
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemType> MenuItemTypes { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageSeason> PackageSeasons { get; set; }
        public DbSet<PackageSeasonDay> PackageSeasonDays { get; set; }

        public AuthContext() : base("AuthContext")
        {
        }

    }
}