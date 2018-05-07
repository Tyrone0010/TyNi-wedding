using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.ViewModels.Request;

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
        public List<Infrastructure.Models.Venue> GetVenues(int clientId)
        {
            return _context.Venues.Select(q => q).ToList();
        }
    }
}