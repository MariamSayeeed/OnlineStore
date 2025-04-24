using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // endpoint 

        [HttpGet]   // GET   /api/products/GetAllProducts
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecificationParamters specParams)
        {
            var result = await  _serviceManager.ProductService.GetAllProductsAsync(specParams);
            if (result == null) return BadRequest();   // 400
            return Ok(result);    // 200
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            if (product == null) return NotFound();   // 404
            return Ok(product);  // 200
        }

        [HttpGet ("brands")]
        public async Task <IActionResult> GetProductBrands()
        {
            var brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            if (brands == null) return NotFound();
            return Ok(brands);
        }

        [HttpGet ("types")]
        public async Task<IActionResult> GetProductTypes()
        {
            var types = await _serviceManager.ProductService.GetAllTypesAsync();
            if (types == null) return NotFound();
            return Ok(types);
        }

    }
}
