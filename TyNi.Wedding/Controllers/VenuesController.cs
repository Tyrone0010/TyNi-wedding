﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using TyNi.Wedding.ExternalProvidersApiServices.Customer;
using TyNi.Wedding.ExternalProvidersApiServices.Quote;
using TyNi.Wedding.ExternalProvidersApiServices.Venues;
using TyNi.Wedding.ViewModels.Request;
using TyNi.Wedding.ViewModels.Response;

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
        public IHttpActionResult Get()
        {
            //get the current user so we can use thier id to get the venues
            var results = _venueManager.GetVenues(0);
            return Json(results);
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult Post([FromBody] VenueModel venueModel)
        {
            return Ok(_venueManager.AddVenue(venueModel));
        }

        [AllowAnonymous]
        [HttpPut]
        public IHttpActionResult Put(Guid id)
        {
            //return Ok(_venueManager.GetQuote(id));
            return Ok();
        }


    }
}
