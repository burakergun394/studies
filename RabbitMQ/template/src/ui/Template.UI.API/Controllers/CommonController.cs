using Microsoft.AspNetCore.Mvc;
using Template.RabbitMq.Publisher;

namespace Template.UI.API.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IRabbitMqPublisher _rabbitMqPublisher;

        public CommonController(IRabbitMqPublisher rabbitMqPublisher)
        {
            _rabbitMqPublisher = rabbitMqPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string message)
        {
            _rabbitMqPublisher.Publish(message);

            return Ok();
        }
    }
}