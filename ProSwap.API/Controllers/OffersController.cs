using Microsoft.AspNet.Identity;
using ProSwap.Data;
using ProSwap.Models;
using ProSwap.Models.Offer;
using ProSwap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProSwap.API.Controllers
{
    public class OffersController : ApiController
    {
        [Authorize]
        public class OfferController : ApiController
        {
            private OfferService CreateOfferService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var offerService = new OfferService(userId);
                return offerService;
            }

            public IHttpActionResult Get()
            {
                OfferService offerService = CreateOfferService();
                var offers = offerService.GetAllOffers();
                return Ok(offers);
            }

            public IHttpActionResult Post(OfferCreate offer)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateOfferService();

                if (!service.CreateOffer(offer))
                    return InternalServerError();

                return Ok();
            }

            //GET /Thread/{id}
            public IHttpActionResult Get(int id)
            {
                OfferService offerService = CreateOfferService();
                var offer = offerService.GetOfferById(id);
                return Ok(offer);
            }

            public IHttpActionResult Put(OfferEdit offer)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateOfferService();

                if (!service.UpdateOffer(offer))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateOfferService();

                if (!service.DeleteOffer(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}
