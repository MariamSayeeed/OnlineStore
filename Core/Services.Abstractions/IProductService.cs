using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        // GetAll Products
        //Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? brandId, int? typeId , string? sort ,int pageIndex = 1, int pageSize = 5);
        Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecificationParamters specParams);

        // GetProduct By Id
        Task <ProductDto> GetProductByIdAsync(int id);

        // Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();


        // Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();


    }
}
