using APP.Products.Features.Products;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var request = new ProductQueryRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new ProductQueryRequest { Id = id };
            var response = await _mediator.Send(request);
            var product = response.FirstOrDefault();
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateRequest request)
        {
            request.Id = id;
            var response = await _mediator.Send(request);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new ProductDeleteRequest { Id = id };
            var response = await _mediator.Send(request);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
} 