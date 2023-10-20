using API.Core.DbModels;
using API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() => Ok(await _productRepository.GetProductsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProduct(int id) => Ok(await _productRepository.GetProductByIdAsync(id));
    }
}
