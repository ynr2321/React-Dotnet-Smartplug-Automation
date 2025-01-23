using AutomationAPI.Data;
using AutomationAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AutomationAPI.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class TemperatureProfilesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IProfileRepository _profileRepo;

        // ReSharper disable once ConvertToPrimaryConstructor
        /// <summary>
        /// TemperatureProfilesController Constructor
        /// </summary>
        /// <param name="context">DbContext used to access choice of database</param>
        /// <param name="stockRepo">Repository interface that encapsulates database interaction logic - Scoped dependency</param>
        public TemperatureProfilesController(ApplicationDbContext context, IProfileRepository stockRepo)
        {
            _context = context;
            _profileRepo = stockRepo;
        }

        public async Task<IActionResult> GetAll()
        {
            // TODO implement

            return Ok();
        }
    }
}
