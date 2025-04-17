using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistance
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;

        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }
        public async Task InitialzeAsync()
        {
            // Create Database if is not exist $$ apply to any Pending Migrations 

            if( _context.Database.GetPendingMigrations().Any() )
            {
               await _context.Database.MigrateAsync();
            }

            // Data Seeding

            try
            {


                // 1.Seeding ProductType
                // 2.Seeding ProductBrand
                // 3.Seeding Product

                // ---------------   Types
                if (!_context.ProductTypes.Any())
                {
                    // 1- Read All Data From JSON Files as String
                    var typesData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\Seeding\types.json");

                    // 2- Transform String (Data) to C# objects[List<ProductType>] -> deserlize
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    // 3- Add List<ProductTypes> To Database

                    if (typesData is not null && typesData.Any())
                    {
                        await _context.AddRangeAsync(types);
                        await _context.SaveChangesAsync();
                    }
                }

                //-----------------  Brands
                if (!_context.ProductBrands.Any())
                {
                    // 1- Read All Data From JSON Files as String
                    var brandsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\Seeding\brands.json");

                    // 2- Transform String (Data) to C# objects[List<ProductBrand>] -> deserlize
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // 3- Add List<ProductTypes> To Database

                    if (brandsData is not null && brandsData.Any())
                    {
                        await _context.AddRangeAsync(brands);
                        await _context.SaveChangesAsync();
                    }


                    //-----------------
                }

                //-----------------  Products
                if (!_context.Products.Any())
                {
                    // 1- Read All Data From JSON Files as String
                    var productsData = await File.ReadAllTextAsync(@"..\Infrastructure\Presistance\Data\Seeding\products.json");

                    // 2- Transform String (Data) to C# objects[List<Product>] -> deserlize
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    // 3- Add List<ProductTypes> To Database

                    if (productsData is not null && productsData.Any())
                    {
                        await _context.AddRangeAsync(products);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }
    }
}
// ..\Infrastructure\Presistance\Data\Seeding\types.json
// C:\Users\Online\source\repos\OnlineStore\Infrastructure\Presistance\Data\Seeding\types.json
