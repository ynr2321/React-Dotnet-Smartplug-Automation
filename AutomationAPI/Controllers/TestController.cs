using AutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Words = new[]
        {
            "Hob", "Package", "Pension", "Mattress", "Kitchen"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTest")]
        public Test Get()
        {
            return new Test()
            {
                Message = $"WELL?, what are you doing? Where's my {Words[Random.Shared.Next(0, Words.Length)]}?"
            };

        }
    }
}
