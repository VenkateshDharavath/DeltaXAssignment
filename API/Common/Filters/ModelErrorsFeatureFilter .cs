using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Common.Filters
{
    public class ModelErrorsFeatureFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var errors = context.ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
            if (errors != null && errors.Count > 0)
            {
                //context.HttpContext.Response.Clear();
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            context.HttpContext.Features.Set<ModelErrorsFeature>(new ModelErrorsFeature(errors));

            await next();

            // After Action execution
            //if(context.HttpContext.Response.StatusCode == (int)HttpStatusCode.BadRequest)
            //{
            //    context.HttpContext.Response.Body = new MemoryStream();
            //}
        }
    }
}
