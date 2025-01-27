using AutomationAPI.Data;
using AutomationAPI.DTOs.TemperatureProfile;
using AutomationAPI.Mappers;
using AutomationAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="profileRepo">Repository interface that encapsulates database interaction logic - Scoped dependency</param>
        public TemperatureProfilesController(ApplicationDbContext context, IProfileRepository profileRepo)
        {
            _context = context;
            _profileRepo = profileRepo;
        }

        /// <summary>
        /// Returns all profiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // If any data validation doesn't pass, return bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profiles = await _profileRepo.GetAllAsync();

            // Map profile models to presentable DTOs before returning
            var profileDtos = profiles.Select(p => p.ToProfileDto()).ToList();

            return Ok(profileDtos);
        }

        /// <summary>
        /// Returns first Profile with provided ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            // If any data validation doesn't pass, return bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profile = await _profileRepo.GetByIdAsync(id);

            if (profile == null)
                return NotFound();


            return Ok(profile.ToProfileDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileDto profileDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profileModel = profileDto.ToProfileFromCreateDto();

            await _profileRepo.CreateAsync(profileModel);

            return CreatedAtAction(nameof(GetById), new { id = profileModel.ProfileId }, profileModel.ToProfileDto());
        }
    }
}