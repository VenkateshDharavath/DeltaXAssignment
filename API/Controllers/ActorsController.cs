using API.Common.Filters;
using API.Common.Utilities;
using Application.Actors.Command;
using Application.Actors.Query;
using Application.Common.Utilities;
using Application.Common.ViewModels;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator Mediator;

        public ActorsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        // GET: api/<ActorsController>
        [HttpGet]
        public async Task<PaginatedList<Actor>> Get([FromQuery] GetActorsQuery query)
        {
            if (query == null)
                query = new GetActorsQuery();
            return await Mediator.Send(query);
        }

        // GET api/<ActorsController>/5
        [HttpGet("{id}")]
        public async Task<Actor> Get(string id)
        {
            return await Mediator.Send(new GetActorQuery { Id = id});
        }

        // POST api/<ActorsController>
        //[ServiceFilter(typeof(ModelErrorsFeatureFilter))]
        [HttpPost]
        public async Task<Actor> Post([FromBody] ActorViewModel actor)
        {
            var res = await Mediator.Send(new CreateActorCommand { actor = actor });
            HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
            return res;
        }

        // PUT api/<ActorsController>/5
        [HttpPut("{id}")]
        public async Task<Actor> Put(string id, [FromBody] ActorViewModel actor)
        {
            var res = await Mediator.Send(new UpdateActorCommand { Id = id, actor = actor });
            if (res == null)
                HttpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
            return res;
        }

        // DELETE api/<ActorsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var res = await Mediator.Send(new DeleteActorCommand { Id = id });
            if (res == 0)
            {
                HttpContext.Items.Add(Constants.ErrorMessage, "No record found with provided Id");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;

        }
    }
}
