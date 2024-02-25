using Infrastructure.Kafka.Producer;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController(ILogger<TestsController> logger, IMessagePublisher messagePublisher) : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get(string input)
        {
            await messagePublisher.PublishAsync(input);
            return input;
        }
    }
}
