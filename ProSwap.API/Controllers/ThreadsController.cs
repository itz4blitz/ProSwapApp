using Microsoft.AspNet.Identity;
using ProSwap.Models;
using ProSwap.Models.Threads;
using ProSwap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProSwap.API.Controllers
{
    public class ThreadsController : ApiController
    {
        [Authorize]
        public class ThreadController : ApiController
        {
            private ThreadService CreateThreadService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var threadService = new ThreadService(userId);
                return threadService;
            }

            public IHttpActionResult Get()
            {
                ThreadService threadService = CreateThreadService();
                var threads = threadService.GetAllOffers();
                return Ok(threads);
            }

            public IHttpActionResult Post(ThreadCreate thread)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateThreadService();

                if (!service.CreateThread(thread))
                    return InternalServerError();

                return Ok();
            }

            //GET /Thread/{id}
            public IHttpActionResult Get(int id)
            {
                ThreadService threadService = CreateThreadService();
                var thread = threadService.GetOfferById(id);
                return Ok(thread);
            }

            public IHttpActionResult Put(ThreadEdit thread)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreateThreadService();

                if (!service.UpdateOffer(thread))
                    return InternalServerError();

                return Ok();
            }

            public IHttpActionResult Delete(int id)
            {
                var service = CreateThreadService();

                if (!service.DeleteOffer(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}
