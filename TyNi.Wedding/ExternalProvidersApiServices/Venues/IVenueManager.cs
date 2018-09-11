using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Request;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Venues
{
    public interface IVenueManager
    {
        List<VenueVm> GetVenues(int clientId);
        Infrastructure.Models.Venue AddVenue(VenueModel venueModel);
        VenueVm GetVenue(int id);
    }
}