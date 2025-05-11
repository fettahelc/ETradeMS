using APP.Users.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Seed()
        {
            var productsDbFactory = new UsersDbFactory();
            productsDbFactory.Seed();
            return Ok("Database seed successful.");
        }
    }
}
