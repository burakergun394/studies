using Application.Products.Commands;
using Application.Products.Dtos.Request;
using Application.Products.Dtos.Response;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        #endregion

        #region Constructor
        public ProductsController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("get-all-products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _mediator.Send(new GetAllProductsQuery());

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            var result = await _mediator.Send(new CreateProductCommand(request));

            _memoryCache.Remove("get-all-products");

            return Ok(result);
        }

        [HttpPost]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            var result = await _mediator.Send(new UpdateProductCommand(request));

            return Ok(result);
        }

        [HttpPost()]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));

            return Ok(result);
        }

        #endregion

    }
}
