using azureproductapp.Interfaces;
using azureproductapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace azureproductapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Product>>> getProducts()
        {
            return Ok(await _productService.GetAllProducts()); 
        }
    }
}
