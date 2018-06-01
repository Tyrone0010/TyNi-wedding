using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Menus
{
    public class MenuManager : IMenuManager
    {
        private readonly ApplicationDbContext _context;
        //private IQueryable<MenuSection> _menuSections;

        public MenuManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        public List<MenuVm> GetMenusForVenue(int venueId)
        {

            var menus = _context.Menu
                .Include(m => m.MenuSections)
                .Where(m => m.Venue.Id.Equals(venueId)).ToList();

            //foreach (var menu in menus)
            //{
            //    foreach (var menuMenuSection in menu.MenuSections)
            //    {
            //        _context.MenuSections
            //            .SelectMany(x => x.Children)
            //            .Where(x => x.Parent.Id.Equals(menuMenuSection.Id))
            //            .ToList();
            //    }
            //}

            var returnModel = new List<MenuVm>();

            foreach (var menu in menus)
            {
                returnModel.Add(new MenuVm
                {
                    Id = menu.Id,
                    Name = menu.Title,
                    MenuType = (int)menu.MenuType,
                    IsRequired = menu.Required,
                    TopMenuSections = menu.MenuSections.Select(menuMenuSection => new TopMenuSectionVm
                    {
                        Id = menuMenuSection.Id,
                        Name = menuMenuSection.Title,
                        Price = menuMenuSection.Price
                    }).ToList()
                });
            }
            return returnModel;
        }
    }
}