using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.API.Errors;

namespace Talabat.API.Middlewares
{
    public class ExceptionMiddelwares
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddelwares(RequestDelegate next, ILogger<ExceptionMiddelwares> logger, IHostEnvironment env)
        {
            this.next=next;
            this.logger=logger;
            this.env=env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                await next(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =(int)HttpStatusCode.InternalServerError;
                var response = env.IsDevelopment() ? new ApiExeptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString()) :
                    new ApiExeptionResponse((int)HttpStatusCode.InternalServerError);

                var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response , options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
