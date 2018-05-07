using System;
using System.Linq;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.Infrastructure;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class PriceTariffManager : IPackageManager
    {
        private readonly ApplicationDbContext _context;

        public PriceTariffManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        public Infrastructure.Models.PriceTariff GetPackage(DateTime weddingDate, int venue)
        {
            var priceTariffs = _context.PriceTariffs.Where(p => p.ActiveFrom>=weddingDate && p.ActiveTo <= weddingDate && p.Venues.Select(v => v.Id).Contains(venue));
            foreach (var priceTariff in priceTariffs)
            {
                var includedDays = priceTariff.IncludedDays.Select(x => x.DayOfWeek).ToArray().Cast<int>();
                if (includedDays.Contains(weddingDate.Day))
                {
                    return priceTariff;
                }
            }

            return null;
        }

    }
}