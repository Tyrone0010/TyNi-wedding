using System;
using System.Collections.Generic;
using TyNi.Wedding.ViewModels.Request;
using TyNi.Wedding.ViewModels.Response;

namespace TyNi.Wedding.ExternalProvidersApiServices.Quote
{
    public interface IQuoteManager
    {
        Wedding.Infrastructure.Models.Quote GetQuote(Guid id);
        IList<Infrastructure.Models.Customer> QuoteSearch(QuoteSearchModel searchModel);
        QuoteSummaryVm CalculateQuote(CalculateQuoteModel model);
    }
}