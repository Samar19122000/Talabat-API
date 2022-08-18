using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.DAL.Entities;

namespace Talabat.DAL
{
    public class StoreContextSeed
    {
        public static async Task InvokeSeed(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.productsType.Any())
                {
                    var TypesData = File.ReadAllText("../Talabat.DAL/Data/SeedData/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
                    foreach (var type in Types)
                        context.productsType.Add(type);

                    await context.SaveChangesAsync();
                }

                if (!context.productBrands.Any())
                {
                    var BrandsData = File.ReadAllText("../Talabat.DAL/Data/SeedData/brands.json");
                    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                    foreach (var brand in Brands)
                        context.productBrands.Add(brand);

                    await context.SaveChangesAsync();
                }

                if (!context.products.Any())
                {
                    var ProductsData = File.ReadAllText("../Talabat.DAL/Data/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    foreach (var product in Products)
                        context.products.Add(product);

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex )
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);

            }

        }


    }
}
