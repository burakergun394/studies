using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Middlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id == 0)
                throw new AppException("Value cannot be zero");

            return Ok($"response - {id}");
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] int id)
        {
            if (id == 0)
                throw new AppException("Value cannot be zero");

            return Ok($"response - {id}");
        }
    }
}
