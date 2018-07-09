using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Menus;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/venuemenuitems")]
    public class VenueMenuItemsController : BaseApiController
    {
        private readonly IMenuManager _menuManager;

        public VenueMenuItemsController()
        {
            _menuManager = new MenuManager();
        }

        public VenueMenuItemsController(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        /// <summary>
        /// gets all menu items for a specific venue.
        /// </summary>
        /// <param name="id">the id represents the identifier for the venue</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = _menuManager.GetMenuItemsForVenue(id);
            return Ok(results);
        }

    }
}
