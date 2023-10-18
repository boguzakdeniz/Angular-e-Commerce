using API.Data.DataContext;
using API.Data.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        public ProductsController(StoreContext storeContext)
        {
                _storeContext = storeContext;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts() => _storeContext.Products.ToList();

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id) => _storeContext.Products.Find(id);
    }
}
