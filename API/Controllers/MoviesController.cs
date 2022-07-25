using API.Common.Utilities;
using Application.Common.Utilities;
using Application.Common.ViewModels;
using Application.Movies.Command;
using Application.Movies.Query;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MoviesController : BaseController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public MoviesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<PaginatedList<Movie>> Get([FromQuery] GetMoviesQuery query)
        {
            if (query == null)
                query = new GetMoviesQuery();
            return await Mediator.Send(query);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<Movie> Get(string id)
        {
            return await Mediator.Send(new GetMovieQuery { Id = id });
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<Movie> Post([FromBody] MovieViewModel movie)
        {
            try
            {
                var res = await Mediator.Send(new CreateMovieCommand { movie = movie });
                return res;
            }
            catch (CustomException ex)
            {
                HttpContext.Response.StatusCode = ex.StatusCode;
                HttpContext.Items.Add(Constants.ErrorMessage, ex.Message);
                return null;
            }
        }

        [HttpPost("UploadPoster")]
        public async Task<string> UploadPoster(IFormFile file)
        {
            var split = file.FileName.Split(".");
            var ext = split[split.Length-1];
            var newFilename = Guid.NewGuid().ToString() + "." + ext;
            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "StaticFiles", "Images", newFilename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/StaticFiles/Images/{newFilename}";
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public async Task<Movie> Put(string id, [FromBody] MovieViewModel movie)
        {
            try
            {
                var res = await Mediator.Send(new UpdateMovieCommand { Id = id, movie = movie });
                return res;
            }
            catch(CustomException ex)
            {
                HttpContext.Response.StatusCode = ex.StatusCode;
                HttpContext.Items.Add(Constants.ErrorMessage, ex.Message);
                return null;
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            try
            {
                await Mediator.Send(new DeleteMovieCommand { Id = id });
            }
            catch(CustomException ex)
            {
                HttpContext.Response.StatusCode = ex.StatusCode;
                HttpContext.Items.Add(Constants.ErrorMessage, ex.Message);
            }
        }
    }
}
