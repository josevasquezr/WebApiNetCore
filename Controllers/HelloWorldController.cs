using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService HelloWorldService;
        public HelloWorldController(IHelloWorldService helloWorld)
        {
            HelloWorldService = helloWorld;
        }

        public IActionResult Get()
        {
            return Ok(this.HelloWorldService.GetHelloWorld());
        }
    }
}