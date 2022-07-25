using API.Common.Extensions;
using API.Common.Filters;
using API.Common.Utilities;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.Middleware
{
    public class APIResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _version;

        public APIResponseMiddleware(RequestDelegate next, string version)
        {
            _next = next;
            _version = version;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/StaticFiles")) // IsSwagger(context)
            {
                await _next(context);
            }
            else
            {
                var originalBodyStream = context.Response.Body;
                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;
                    try
                    {
                        await _next.Invoke(context);
                        var success = new List<int> { 200, 201 };
                        if (success.Contains(context.Response.StatusCode))
                        {
                            var body = await FormatResponse(context.Response);
                            await HandleSuccessRequestAsync(context, body, context.Response.StatusCode);
                        }
                        else
                        {
                            var modelErrors = context.Features.Get<ModelErrorsFeature>()?.Errors;
                            await HandleUnSuccessfulReqeustAsync(context, modelErrors, context.Response.StatusCode);
                        }
                    }
                    catch(Exception ex)
                    {
                        await HandleExceptionReqeustAsync(context, ex);
                    }
                    finally
                    {
                        responseBody.Seek(0, SeekOrigin.Begin);

                        //if (context.Response.StatusCode == (int)HttpStatusCode.BadRequest)
                        //    originalBodyStream = new MemoryStream();
                        //await context.Response.Body.WriteAsync(responseBody.ToArray(), 0, (int)responseBody.Length);
                        await responseBody.CopyToAsync(originalBodyStream, (int)responseBody.Length);
                    }
                }
            }
        }

        private Task HandleSuccessRequestAsync(HttpContext context, string body, int code)
        {
            context.Response.ContentType = "application/json";
            string jsonString, bodyText = string.Empty;

            if (!body.ToString().IsValidJson())
                bodyText = JsonConvert.SerializeObject(body);
            else
                bodyText = body.ToString();

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);

            var apiResponse = new APIResponse();
            apiResponse.Version = _version;
            apiResponse.StatusCode = code;
            apiResponse.Result = bodyContent;

            jsonString = JsonConvert.SerializeObject(apiResponse);
            return context.Response.WriteAsync(jsonString);
        }

        private Task HandleUnSuccessfulReqeustAsync(HttpContext context, List<ModelErrorCollection> errors, int code)
        {
            context.Response.ContentType = "application/json";

            APIResponse apiResponse = new APIResponse();
            apiResponse.Version = _version;

            if (code == (int)HttpStatusCode.NotFound && context.Items.ContainsKey(Constants.ErrorMessage))
            {
                apiResponse.Message = context.Items[Constants.ErrorMessage].ToString();
            }
            else if (code == (int)HttpStatusCode.NotFound)
                apiResponse.Message = "The specified URI does not exist. Please verify and try again.";
                //apiResponse.Errors = new List<string>() { "The specified URI does not exist. Please verify and try again." };
            else if (code == (int)HttpStatusCode.BadRequest && errors != null && errors.Count > 0)
            {
                apiResponse.Message = "ModelState invalid, Please check the data posted";
                context.Response.Body.SetLength(0);
            }
            else
            {
                if (context.Items.ContainsKey(Constants.ErrorMessage))
                    apiResponse.Message = context.Items[Constants.ErrorMessage].ToString();
                else
                    apiResponse.Message = "Your request cannot be processed. Please contact a support.";
            }

            apiResponse.StatusCode = code;
            context.Response.StatusCode = code;

            if(errors != null)
                apiResponse.Errors = ParseModelErrors.Parse(errors);

            if (context.Items.ContainsKey(Constants.ErrorMessage))
            {
                apiResponse.Message = context.Items[Constants.ErrorMessage].ToString();
            }

            var json = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(json);
        }

        private Task HandleExceptionReqeustAsync(HttpContext context, Exception exception)
        {
            APIResponse apiResponse = new APIResponse();
            apiResponse.Version = _version;
            if (exception is UnauthorizedAccessException)
            {
                apiResponse.Errors = new List<string> { "Unauthorized Access" };
                var code = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusCode = code;
                apiResponse.StatusCode = code;
            }
            else
            {
                apiResponse.Errors = new List<string> { exception.Message };
                apiResponse.Message = "Unhandled exception occured";
                apiResponse.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.StatusCode = StatusCodes.Status500InternalServerError; ;
            }
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(apiResponse);
            return context.Response.WriteAsync(json);
        }

        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }
    }
}
