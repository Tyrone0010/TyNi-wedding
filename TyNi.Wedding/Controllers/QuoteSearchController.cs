using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/quotesearch")]
    public class QuoteSearchController : BaseApiController
    {
        //private readonly IPriceTariffManager _quoteManager;

        //public QuoteSearchController()
        //{
        //    _quoteManager = new QuoteManager();
        //}

        //public QuoteSearchController(IPriceTariffManager quoteManager)
        //{
        //    _quoteManager = quoteManager;
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //public IHttpActionResult Post([FromBody] QuoteSearchModel searchRequest)
        //{
        //    return Ok(_quoteManager.QuoteSearch(searchRequest));
        //}

    }
}
