using Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get-by-id")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id == 0)
                throw new AppException("Value cannot be zero");

            _logger.LogError(id.ToString());

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
