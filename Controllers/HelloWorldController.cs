using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService HelloWorldService;
        private readonly ILogger<HelloWorldController> _logger;
        public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
        {
            HelloWorldService = helloWorld;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogDebug("Implementacion de Loggin, consulta hello world");
            return Ok(this.HelloWorldService.GetHelloWorld());
        }
    }
}