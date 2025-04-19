using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
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

        [HttpGet]   // GET   /api/products
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await  _serviceManager.ProductService.GetAllProductsAsync();
            if (result == null) return BadRequest();   // 400
            return Ok(result);    // 200
        }








    }
}
