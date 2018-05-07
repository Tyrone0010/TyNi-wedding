using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/calculatepackage")]
    public class CalculatePackageController : BaseApiController
    {
        private readonly IQuoteManager _quoteManager;

        public CalculatePackageController()
        {
            _quoteManager = new QuoteManager();
        }

        public CalculatePackageController(IQuoteManager quoteManager)
        {
            _quoteManager = quoteManager;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IHttpActionResult Get([FromBody] CalculatePackageModel requestData)
        //{
        //    return Ok(_quoteManager.QuoteSearch(searchRequest));
        //}

    }
}
