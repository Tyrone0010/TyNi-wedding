using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.Infrastructure.Models;
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

        public MenuManager(ApplicationDbContext context)
        {
            //change when IOC is introduced
            _context = context;
        }

        public MenuSummaryVm GetMenu(int id)
        {
            var menuSection = _context.MenuSections.Include(m => m.Menu).SingleOrDefault(x => x.Id == id);
            return new MenuSummaryVm
            {
                Id = menuSection.Menu.Id,
                Price = menuSection.Price,
                MenuName = menuSection.Menu.Title,
                SectionName = menuSection.Title
            };
        }

        public List<MenuVm> GetMenusForVenue(int venueId)
        {

            var menus = _context.Menu
                .Where(m => m.Venue.Id.Equals(venueId)).ToList();

            var returnModel = new List<MenuVm>();

            foreach (var menu in menus)
            {
                returnModel.Add(new MenuVm
                {
                    id = menu.Id,
                    name = menu.Title,
                    menuType = (int)menu.MenuType,
                    isRequired = menu.Required,
                });
            }
            return returnModel;
        }

        public List<MenuSectionVm> GetSectionsForVenue(int venueId)
        {
            var menuSections = new List<MenuSectionVm>();
            var sections = _context.MenuSections
                .Include(m => m.Menu)
                .Where(ms => !ms.Menu.Equals(null) && ms.Menu.Venue.Id.Equals(venueId)).ToList();

            foreach (var menuSection in sections)
            {
                menuSections.AddRange(GetChildSections(menuSection.Id));
                menuSections.Add(new MenuSectionVm()
                {
                    id = menuSection.Id,
                    name = menuSection.Title,
                    price = menuSection.Price,
                    parentId = menuSection.Parent?.Id,
                    menuId = menuSection.Menu?.Id
                });
            }

            return menuSections;
        }

        private List<MenuSectionVm> GetChildSections(int parentId)
        {
            var menuSections = new List<MenuSectionVm>();
            var sections = _context.MenuSections
                .Include(m => m.Menu)
                .Where(ms => ms.Parent.Id.Equals(parentId)).ToList();
            foreach (var menuSection in sections)
            {
                menuSections.AddRange(GetChildSections(menuSection.Id));
                menuSections.Add(new MenuSectionVm()
                {
                    id = menuSection.Id,
                    name = menuSection.Title,
                    price = menuSection.Price,
                    parentId = menuSection.Parent?.Id,
                    menuId = menuSection.Menu?.Id
                });
            }

            return menuSections;
        }

        public List<MenuItemVm> GetMenuItemsForVenue(int venueId)
        {
            var menuItemsVm = new List<MenuItemVm>();
            var menuItems = _context.MenuItems
                .Include(m => m.MenuSection.Menu)
                .Include(m => m.MenuSection.Parent.Menu)
                .Where(mi => 
                    (!mi.MenuSection.Menu.Equals(null) && mi.MenuSection.Menu.Venue.Id.Equals(venueId)) || 
                    (!mi.MenuSection.Parent.Equals(null) && !mi.MenuSection.Parent.Menu.Equals(null) && mi.MenuSection.Parent.Menu.Venue.Id.Equals(venueId))).ToList();

            foreach (var menuItem in menuItems)
            {
                menuItemsVm.Add(new MenuItemVm
                {
                    id = menuItem.Id,
                    shortDescription = menuItem.ShortDescription,
                    title = menuItem.Title,
                    parentId = menuItem.MenuSection.Id
                });
            }

            return menuItemsVm;
        }

        //private List<MenuSectionVm> GetChildSections(int parentId)
        //{
        //    var menuSections = new List<MenuSectionVm>();
        //    var sections = _context.MenuSections
        //        .Include(m => m.Menu)
        //        .Where(ms => ms.Parent.Id.Equals(parentId)).ToList();
        //    foreach (var menuSection in sections)
        //    {
        //        menuSections.AddRange(GetChildSections(menuSection.Id));
        //        menuSections.Add(new MenuSectionVm()
        //        {
        //            id = menuSection.Id,
        //            name = menuSection.Title,
        //            price = menuSection.Price,
        //            parentId = menuSection.Parent?.Id,
        //            menuId = menuSection.Menu?.Id
        //        });
        //    }

        //    return menuSections;
        //}

    }
}