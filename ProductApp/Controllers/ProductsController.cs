using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product()  {Id=1,ProductName="Computer"},
                new Product()  {Id=1,ProductName="Keyboard"},
                new Product()  {Id=1,ProductName="Mouse"}
            };
            this.logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
           
           
        }
    
        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {

            this.logger.LogWarning("Product has been created.");
            return StatusCode(201);

        }
    }
}
