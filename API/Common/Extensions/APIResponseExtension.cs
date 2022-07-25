using API.Common.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common.Extensions
{
    public static class APIResponseExtension
    {
        public static IApplicationBuilder UseNormalizeAPIResponse(this IApplicationBuilder builder, string version)
        {
            return builder.UseMiddleware<APIResponseMiddleware>(version);
        }
    }
}
