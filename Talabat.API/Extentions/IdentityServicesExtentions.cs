using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Talabat.DAL.Entities.Identity;
using Talabat.DAL.Identity;

namespace Talabat.API.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityervices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
             {

             }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication();

            return services;
        }



    }
}
