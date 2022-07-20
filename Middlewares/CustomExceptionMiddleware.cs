using FitnessWebAPI.APIErrors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FitnessWebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger logger;
        private readonly IHostEnvironment hostEnvironment;

        public CustomExceptionMiddleware(RequestDelegate next, ILogger logger, IHostEnvironment hostEnvironment)
        {
            _next = next;
            this.logger = logger;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                ApiError apiError;
                string message = null;
                int statusCode = (int)HttpStatusCode.InternalServerError;
                var exType = ex.GetType();
               
                if (exType == typeof(UnauthorizedAccessException))
                {
                    message = "You are not authorised";
                    statusCode = (int)HttpStatusCode.Forbidden;
                }
                else
                {
                    message = "We are working in the backend please wait and try after sometime!";
                    statusCode = (int)HttpStatusCode.InternalServerError;
                }
                if (hostEnvironment.IsDevelopment())
                {
                    apiError = new ApiError(statusCode, ex.Message, ex.StackTrace.ToString());
                }
                else
                {
                    apiError = new ApiError(statusCode, message, null);
                }

                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(apiError.ToString());

            }
        }
    }
}
