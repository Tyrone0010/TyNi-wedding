using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Menus;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/menuSection")]
    public class VenueSectionsController : BaseApiController
    {
        private readonly IMenuManager _menuManager;

        public VenueSectionsController()
        {
            _menuManager = new MenuManager();
        }

        public VenueSectionsController(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        /// <summary>
        /// gets all menus for a specific venue.
        /// </summary>
        /// <param name="id">the id represents the identifier for the venue</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = _menuManager.GetSectionsForVenue(id);
            return Ok(results);
        }

    }
}
