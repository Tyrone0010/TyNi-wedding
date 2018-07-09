using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Menus
{
    public interface IMenuManager
    {
        List<MenuVm> GetMenusForVenue(int venueId);
        List<MenuSectionVm> GetSectionsForVenue(int venueId);
        List<MenuItemVm> GetMenuItemsForVenue(int venueId);
    }
}