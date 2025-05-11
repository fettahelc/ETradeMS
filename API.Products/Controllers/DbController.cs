using APP.Products.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Seed()
        {
            var productsDbFactory = new ProductsDbFactory();
            productsDbFactory.Seed();
            return Ok("Database seed successful.");
        }
    }
}
