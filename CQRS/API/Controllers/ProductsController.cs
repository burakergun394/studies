using Application.Products.Commands;
using Application.Products.Dtos.Request;
using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Fields

        private readonly IMediator _mediator;

        #endregion

        #region Constructor
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
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

            return Ok(result);
        }

        #endregion

    }
}
