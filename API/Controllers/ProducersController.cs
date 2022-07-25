using API.Common.Utilities;
using Application.Common.Utilities;
using Application.Common.ViewModels;
using Application.Producers.Command;
using Application.Producers.Query;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProducersController : BaseController
    {
        // GET: api/<ProducersController>
        [HttpGet]
        public async Task<PaginatedList<Producer>> Get([FromQuery] GetProducersQuery query)
        {
            if (query == null)
                query = new GetProducersQuery();
            return await Mediator.Send(query);
        }

        // GET api/<ProducersController>/5
        [HttpGet("{id}")]
        public async Task<Producer> Get(string id)
        {
            try
            {
                return await Mediator.Send(new GetProducerQuery { Id = id });
            }
            catch(CustomException ex)
            {
                HttpContext.Items.Add(Constants.ErrorMessage, ex.Message);
                HttpContext.Response.StatusCode = ex.StatusCode;
                return null;
            }
        }

        // POST api/<ProducersController>
        [HttpPost]
        public async Task<Producer> Post([FromBody] ProducerViewModel producer)
        {
            return await Mediator.Send(new CreateProducerCommand { producer = producer });
        }

        // PUT api/<ProducersController>/5
        [HttpPut("{id}")]
        public async Task<Producer> Put(string id, [FromBody] ProducerViewModel producer)
        {
            try
            {
                return await Mediator.Send(new UpdateProducerCommand { Id = id, producer = producer });
            }
            catch(CustomException ex)
            {
                HttpContext.Items.Add(Constants.ErrorMessage, ex.Message);
                HttpContext.Response.StatusCode = ex.StatusCode;
                return null;
            }
        }

        // DELETE api/<ProducersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            var res = await Mediator.Send(new DeleteProducerCommand { Id = id });
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
