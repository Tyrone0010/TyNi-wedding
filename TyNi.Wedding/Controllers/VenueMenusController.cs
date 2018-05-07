﻿using System.Web.Http;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ViewModels.Request;

namespace TyNi.Wedding.Controllers
{
    [RoutePrefix("api/venuemenus")]
    public class VenueMenusController : BaseApiController
    {
        private readonly IMenuManager _menuManager;

        public VenueMenusController()
        {
            _menuManager = new MenuManager();
        }

        public VenueMenusController(IMenuManager menuManager)
        {
            _menuManager = menuManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var results = _menuManager.GetMenusForVenue(id);
            return Ok(results);
        }

    }
}
