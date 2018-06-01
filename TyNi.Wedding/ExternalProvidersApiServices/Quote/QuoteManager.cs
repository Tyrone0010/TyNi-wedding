using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.Infrastructure;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.ExternalProvidersApiServices.Customer
{
    public class QuoteManager: IQuoteManager
    {
        private readonly ApplicationDbContext _context;

        public QuoteManager() 
        {
            //change when IOC is introduced
            _context = new ApplicationDbContext();
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
    }
}