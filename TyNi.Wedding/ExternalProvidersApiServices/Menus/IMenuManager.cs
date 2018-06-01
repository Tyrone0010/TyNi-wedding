using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Menus
{
    public interface IMenuManager
    {
        List<MenuVm> GetMenusForVenue(int venueId);
    }
}