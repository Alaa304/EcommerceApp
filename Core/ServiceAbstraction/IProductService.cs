using Shared;
using Shared.DTOS;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //get all products
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams);
        //get product by id
        Task<ProductDto?> GetProductByIdAsync(int id);
        //get all brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        //get all types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}
