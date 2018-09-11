using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.ExternalProvidersApiServices.Menus;
using TyNi.Wedding.ExternalProvidersApiServices.PriceTariff;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ExternalProvidersApiServices.Venues;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.Infrastructure.Models;
using TyNi.Wedding.ViewModels.Request;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class QuoteManager: IQuoteManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IPriceTariffManager _priceTariffManager;
        private readonly IMenuManager _menuManager;
        private readonly IVenueManager _venueManager;

        public QuoteManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
            _priceTariffManager = new PriceTariffManager(_context);
            _menuManager = new MenuManager(_context);
            _venueManager = new VenueManager(_context);
        }

        public Infrastructure.Models.Quote GetQuote(Guid id)
        {
            return _context.Quotes.FirstOrDefault(q => q.Id == id);
        }

        public IList<Infrastructure.Models.Customer> QuoteSearch(QuoteSearchModel searchModel)
        {
            return _context.Customers.Where(c => 
                c.Firstname.Contains(searchModel.CustomerFirstName) ||
                c.Surname.Contains(searchModel.CustomerLastName) ||
                c.Address.Address1.Contains(searchModel.AddressLine1) ||
                c.Address.Postcode.Contains(searchModel.Postcode)).Include( q => q.Quotes).ToList();

        }

        public QuoteSummaryVm CalculateQuote(CalculateQuoteModel model)
        {
            //Todo: need to have data driven engine here for calculating prices
            //Todo: The menu needs to have a 1 to many relationship with GuestNumberTypes (new table)
            //Todo: which is linked to each menu by venue also and has a calculation factor for price reductions
            //Todo: for now this is being hard coded
            var returnModel = new QuoteSummaryVm();
            var package = _priceTariffManager.GetPackage(model.WeddingDate, model.VenueId);
            //returnModel.VenueName = package.
            returnModel.VenuePrice = package.Price;
            returnModel.VenueName = _venueManager.GetVenue(model.VenueId).name;
            foreach (var sectionId in model.MenuSections)
            {
                var menu = _menuManager.GetMenu(sectionId);
                switch (menu.Id)
                {
                    case 1:
                        menu.Price = CalculateBreakfast(menu.Price, model.AdultNumbers, model.TeenNumbers,
                            model.ChildNumbers);
                        break;
                    case 2:
                        menu.Price = CalculateDrinks(menu.Price, model.AdultNumbers);
                        break;
                    case 3:
                    case 5:
                        menu.Price = CalculateEvening(menu.Price, model.EveningNumbers);
                        break;
                    case 4:
                        menu.Price = CalculateCanape(menu.Price, model.AdultNumbers, model.TeenNumbers);
                        break;
                }
                returnModel.Menus.Add(menu);
            }

            return returnModel;
        }

        private decimal CalculateDrinks(decimal menuPrice, int adultNumbers)
        {
            return (menuPrice * adultNumbers);
        }

        private decimal CalculateBreakfast(decimal menuPrice, int adultNumbers, int teenNumbers, int childNumbers)
        {
            return (menuPrice * adultNumbers) + (menuPrice * (decimal)0.75 * teenNumbers) + (menuPrice * (decimal)0.5 * childNumbers);
        }

        private decimal CalculateEvening(decimal menuPrice, int eveningNumbers)
        {
            return (menuPrice * eveningNumbers);
        }

        private decimal CalculateCanape(decimal menuPrice, int adultNumbers, int teenNumbers)
        {
            return (menuPrice * adultNumbers) + (menuPrice * teenNumbers);
        }

    }
}