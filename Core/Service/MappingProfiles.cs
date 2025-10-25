using AutoMapper;
using DomainLayer.Models;
using Shared.DTOS;
namespace Service
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() { 
        
       CreateMap<Product, ProductDto>().ForMember(dist=>dist.BrandName,options=>options.MapFrom(src=>src.ProductBrand.Name)).
                ForMember(dist=>dist.TypeName,option=>option.MapFrom(src=>src.ProductType.Name)).
                ForMember(dist=>dist.PictureURL,options=>options.MapFrom<PictureUrlResolver>());
       CreateMap<ProductBrand,BrandDto>();
       CreateMap<ProductType,TypeDto>();
        }
    }
}
