using AutoMapper;
using DomainLayer.Models;
using Microsoft.Extensions.Configuration;
using Shared.DTOS;
using System.Threading.Tasks;

namespace Service
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
           if(string.IsNullOrEmpty(source.PictureURL))
            {
                return string.Empty;
            }
            else
            {
                return $"{configuration.GetSection("URLS")["BaseURL"]}{source.PictureURL}";



            }
        }
    }
}
