using AutomationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutomationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceholderController : ControllerBase
    {
        private static readonly string[] Words = new[]
        {
            "Hob", "Package", "Pension", "Mattress", "Kitchen"
        };

        private readonly ILogger<PlaceholderController> _logger;

        public PlaceholderController()
        {

        }

        [HttpGet(Name = "GetPlaceholder")]
        public Placeholder Get()
        {
            return new Placeholder()
            {
                Message = $"WELL!?, what are you doing? Where's my {Words[Random.Shared.Next(0, Words.Length)]}?"
            };

        }
    }
}