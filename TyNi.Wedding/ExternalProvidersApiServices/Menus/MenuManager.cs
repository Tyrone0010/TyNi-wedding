using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.Infrastructure;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class MenuManager : IMenuManager
    {
        private readonly ApplicationDbContext _context;

        public MenuManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        public List<Infrastructure.Models.Menu> GetMenusForVenue(int venueId)
        {
            return _context.Menu
                .Where(m => m.Venues.Select(v => v.Id)
                .Contains(venueId))
                //.Include(m => m.MenuSections)
                .ToList();
        }

    }
}