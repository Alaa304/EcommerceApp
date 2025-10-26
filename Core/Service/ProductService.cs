using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
using Shared;
using Shared.DTOS;
using Shared.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {

            var brands= await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
           return  _mapper.Map<IEnumerable<ProductBrand>,IEnumerable<BrandDto>>(brands);
          
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
         {
            var Specification=new ProductWithBrandAndTypeSpecifications(queryParams);
            var brands=await _unitOfWork.GetRepository<Product,int>().GetAllAsync(Specification);
            return _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(brands);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
           var  Types=await _unitOfWork.GetRepository<ProductType,int>().GetAllAsync();
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var Specification = new ProductWithBrandAndTypeSpecifications(id);

            var productID = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Specification);
            return _mapper.Map<Product, ProductDto>(productID);
        }
    }
}
