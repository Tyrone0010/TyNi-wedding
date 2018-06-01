using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Venues
{
    public interface IVenueManager
    {
        List<VenueVm> GetVenues(int clientId);
    }
}