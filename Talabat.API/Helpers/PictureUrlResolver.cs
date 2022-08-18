using AutoMapper;
using Microsoft.Extensions.Configuration;
using Talabat.API.DTOs;
using Talabat.DAL.Entities;

namespace Talabat.API.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductToReturnDtos, string>
    {
        private readonly IConfiguration configuration;

        public PictureUrlResolver(IConfiguration configuration)
        {
            this.configuration=configuration;
        }

        public string Resolve(Product source, ProductToReturnDtos destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(destMember))
                return $"{configuration["ApiUrl"]} {source.PictureUrl}";
            return null;
               
        }
    }
}
