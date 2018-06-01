using System.Collections.Generic;
using System.Linq;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Venues
{
    public class VenueManager : IVenueManager
    {
        private readonly ApplicationDbContext _context;

        public VenueManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        //Todo: implement a client entity
        public List<VenueVm> GetVenues(int clientId)
        {
            var returnVenues = new List<VenueVm>();
            foreach (var venue in _context.Venues.Select(q => q))
            {
                returnVenues.Add(new VenueVm
                {
                    id = venue.Id,
                    name = venue.Name
                });
            }

            return returnVenues;
        }
    }
}