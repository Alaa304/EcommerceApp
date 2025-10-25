using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance.Data.DataSeed
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            var PindingMigration =await _dbContext.Database.GetPendingMigrationsAsync();
            if (PindingMigration.Any())
            {
                _dbContext.Database.Migrate();
            }
            #region ProductBrand

            if (!_dbContext.ProductBrands.Any())
            {
                var BrandData = File. OpenRead(@"..\Inferastructure\Presistance\Data\DataSeed\brands.json");
                var Brands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(BrandData);
                if (Brands.Any() && Brands is not null)
                {
                   await _dbContext.ProductBrands.AddRangeAsync(Brands);
                }
            }
            #endregion

            #region ProductType

            if (!_dbContext.ProductTypes.Any())
            {
                var TypesData = File.OpenRead(@"..\Inferastructure\Presistance\Data\DataSeed\types.json");
                var Types =await JsonSerializer.DeserializeAsync<List<ProductType>>(TypesData);
                if (Types.Any() && Types is not null)
                {
                 await  _dbContext.ProductTypes.AddRangeAsync(Types);
                }
            }


            #endregion

            #region Product

            if (!_dbContext.Products.Any())
            {
                var ProductsData = File.OpenRead(@"..\Inferastructure\Presistance\Data\DataSeed\products.json");
                var Products =await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);
                if (Products.Any() && Products is not null)
                {
                   await _dbContext.Products.AddRangeAsync(Products);
                }
            }


            #endregion
            _dbContext.SaveChangesAsync();

        }


    }
}
