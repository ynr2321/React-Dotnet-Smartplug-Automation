using AutomationAPI.DTOs.TemperatureProfile;
using AutomationAPI.Interfaces;
using AutomationAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutomationAPI.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class TemperatureProfilesController : ControllerBase
    {
        private readonly IProfileRepository _profileRepo;

        // ReSharper disable once ConvertToPrimaryConstructor
        /// <summary>
        /// TemperatureProfilesController Constructor
        /// </summary>
        /// <param name="context">DbContext used to access choice of database</param>
        /// <param name="profileRepo">Repository interface that encapsulates database interaction logic - Scoped dependency</param>
        public TemperatureProfilesController(IProfileRepository profileRepo)
        {
            _profileRepo = profileRepo;
        }

        /// <summary>
        /// Returns all profiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
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
            var profile = await _profileRepo.GetByIdAsync(id);

            if (profile == null)
                return NotFound();


            return Ok(profile.ToProfileDto());
        }

        /// <summary>
        /// Creates a new temperature profile.
        /// </summary>
        /// <param name="profileDto">Data transfer object containing profile details.</param>
        /// <returns>Returns the created profile with its ID.</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProfileDto profileDto)
        {
            // If any data validation doesn't pass, return bad request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profileModel = profileDto.ToProfileFromCreateDto();

            await _profileRepo.CreateAsync(profileModel);

            return CreatedAtAction(nameof(GetById), new { id = profileModel.ProfileId }, profileModel.ToProfileDto());
        }


        /// <summary>
        /// Updates an existing temperature profile by ID.
        /// </summary>
        /// <param name="id">ID of the profile to update.</param>
        /// <param name="updateDto">Data transfer object containing updated profile details.</param>
        /// <returns>Returns the updated profile.</returns>
        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProfileRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var profileModel = await _profileRepo.UpdateAsync(id, updateDto);

            if (profileModel == null)
                return NotFound();

            return Ok(profileModel.ToProfileDto());

        }


        /// <summary>
        /// Deletes an existing temperature profile by ID.
        /// </summary>
        /// <param name="id">ID of the profile to delete.</param>
        /// <returns>Returns no content if successful.</returns>
        [Authorize]
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var profileModel = await _profileRepo.DeleteAsync(id);

            if (profileModel == null)
                return NotFound();

            return NoContent();
        }
    }

}