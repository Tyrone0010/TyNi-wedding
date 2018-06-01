using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.PriceTariff;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/calculatepackage")]
    public class CalculatePackageController : BaseApiController
    {
        private readonly IPriceTariffManager _priceTariffManager;

        public CalculatePackageController()
        {
            _priceTariffManager = new PriceTariffManager();
        }

        public CalculatePackageController(IPriceTariffManager quoteManager)
        {
            _priceTariffManager = quoteManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get([FromUri] CalculatePackageModel requestData)
        {
            return Json(_priceTariffManager.GetPackage(requestData.WeddingDate, requestData.Venue));
        }

    }
}
