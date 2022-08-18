using AutoMapper;
using Talabat.API.DTOs;
using Talabat.DAL.Entities;

namespace Talabat.API.Helpers
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDtos>().
                ForMember(D => D.ProductType, O => O.MapFrom(S => S.ProductType.Name)).
                ForMember(D => D.ProductBrand, O => O.MapFrom(S => S.ProductBrand.Name)).
                ForMember(D => D.PictureUrl , O => O.MapFrom<PictureUrlResolver>());
                
        }

    }
}
