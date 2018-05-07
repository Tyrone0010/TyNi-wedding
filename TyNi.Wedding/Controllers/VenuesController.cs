using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ExternalProvidersApiServices.Venues;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/venues")]
    public class VenuesController : BaseApiController
    {
        private readonly IVenueManager _venueManager;

        public VenuesController()
        {
            _venueManager = new VenueManager();
        }

        public VenuesController(IVenueManager venueManager)
        {
            _venueManager = venueManager;
        }

        [AllowAnonymous]
        [HttpGet]
        //Todo: implement client entity
        public IHttpActionResult Get(int id)
        {
            var results = _venueManager.GetVenues(id);
            return Ok(results);
        }

    }
}
