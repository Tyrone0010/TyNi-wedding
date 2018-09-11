using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.Infrastructure.Models;
using TyNi.Wedding.ViewModels.Request;
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

        public VenueManager(ApplicationDbContext context)
        {
            //change when IOC is introduced
            _context = context;
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

        public Venue AddVenue(VenueModel venueModel)
        {
            var venue = new Venue
            {
                Description = venueModel.Descrition,
                Name = venueModel.Name
            };
            _context.Venues.Add(venue);
            if (_context.SaveChanges() == 1)
            {
                return venue;
            }
            throw new DataException("The venue could not be created");
        }

        public VenueVm GetVenue(int id)
        {
            var venue = _context.Venues.SingleOrDefault(q => q.Id == id);
            if (venue == null)
            {
                throw new NullReferenceException($"The venue for id {id} does not exist");
            }
            return new VenueVm{id = venue.Id, name = venue.Name};
        }
    }
}