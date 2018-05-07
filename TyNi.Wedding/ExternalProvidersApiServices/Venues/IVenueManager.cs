using System.Collections.Generic;

namespace TyNi.Wedding.ExternalProvidersApiServices.Venues
{
    public interface IVenueManager
    {
        List<Infrastructure.Models.Venue> GetVenues(int clientId);
    }
}