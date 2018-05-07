using System;
using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/quote")]
    public class QuoteController : BaseApiController
    {
        private readonly IQuoteManager _quoteManager;

        public QuoteController()
        {
            _quoteManager = new QuoteManager();
        }

        public QuoteController(IQuoteManager quoteManager)
        {
            _quoteManager = quoteManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(Guid id)
        {
            return Ok(_quoteManager.GetQuote(id));
        }

    }
}
