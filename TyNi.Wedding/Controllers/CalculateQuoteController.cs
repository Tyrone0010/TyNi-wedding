using System;
using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.PriceTariff;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/calculatequote")]
    public class CalculateQuoteController : BaseApiController
    {
        private readonly IQuoteManager _quoteManager;

        public CalculateQuoteController()
        {
            _quoteManager = new QuoteManager();
        }

        public CalculateQuoteController(IQuoteManager quoteManager)
        {
            _quoteManager = quoteManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Post([FromBody]CalculateQuoteModel model)
        {
            return Ok(_quoteManager.CalculateQuote(model));
        }

    }
}
