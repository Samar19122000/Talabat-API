using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Linq;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.BLL.Interfaces;
using Talabat.BLL.Repositories;
using Talabat.DAL;
namespace Talabat.API.Extentions
{
    public static class ApplicationServicesExtntion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepoitory));
            
            services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                                                         .SelectMany(M => M.Value.Errors)
                                                         .Select(E => E.ErrorMessage);
                    var errorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);

                };

            });

            return services;

        }




    }
}
