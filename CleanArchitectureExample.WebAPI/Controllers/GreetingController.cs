using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            var greeting = _greetingService.Greet(name);
            return Ok(greeting);
        }
    }
}