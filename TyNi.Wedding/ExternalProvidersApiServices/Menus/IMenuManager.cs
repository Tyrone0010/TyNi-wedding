using System.Collections.Generic;

namespace TyNi.Wedding.ExternalProvidersApiServices.Quote
{
    public interface IMenuManager
    {
        List<Infrastructure.Models.Menu> GetMenusForVenue(int venueId);
    }
}