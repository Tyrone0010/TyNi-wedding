using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper.Configuration.Conventions;
using TyNi.Wedding.ExternalProvidersApiServices.PriceTariff;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class PriceTariffManager : IPriceTariffManager
    {
        private readonly ApplicationDbContext _context;

        public PriceTariffManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
        }

        public PackageVm GetPackage(DateTime weddingDate, int venue)
        {
            var dayOfWeek = (int) weddingDate.DayOfWeek;

            var priceTariffPeriods = _context.PriceTariffPeriods
                .Include(ptd => ptd.PriceTariffPeriodDays)
                .Include(pt => pt.PriceTariff)
                .Where(p => p.ActiveFrom <= weddingDate 
                            && p.ActiveTo >= weddingDate 
                            && p.PriceTariff.Venues.Any(x => x.Id.Equals(venue))
                      )
                .ToList();

            foreach (var priceTariffPeriod in priceTariffPeriods)
            {
                var includedDay = priceTariffPeriod.PriceTariffPeriodDays.SingleOrDefault(x => dayOfWeek.Equals((int)x.DayOfWeek));
                if (includedDay != null)
                {
                    return new PackageVm
                    {
                        Blurb = "",
                        Date = weddingDate,
                        ImageUrl = "",
                        Name = priceTariffPeriod.PriceTariff.Name,
                        Price = includedDay.Price,
                        RateDescription = priceTariffPeriod.Name,
                        Day = weddingDate.DayOfWeek.ToString()
                    };
                }
            }

            return null;
        }

    }
}