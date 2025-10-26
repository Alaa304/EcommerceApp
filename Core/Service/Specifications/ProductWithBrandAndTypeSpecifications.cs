using DomainLayer.Models;
using Shared;
using Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    public class ProductWithBrandAndTypeSpecifications: BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductQueryParams queryParams) : 
            base(P=>(!queryParams.BrandId.HasValue||P.BrandId == queryParams.BrandId) &&
            (!queryParams.TypeId.HasValue||P.TypeId== queryParams.TypeId)&&
            (string.IsNullOrWhiteSpace(queryParams.SearchValue)||P.Name.Contains(queryParams.SearchValue.ToLower())))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            switch(queryParams.sortingOptions)
            {
                case ProdutSortingOptions.NameAsc:
                    AddOrderBy(n => n.Name);
                    break;
                    case ProdutSortingOptions.NameDesc:
                        AddOrderByDescending(n => n.Name);
                    break;
                case ProdutSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProdutSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }
        }
        public ProductWithBrandAndTypeSpecifications(int id) : base(P=>P.Id==id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}
