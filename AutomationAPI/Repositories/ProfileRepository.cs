using AutomationAPI.Data;

namespace AutomationAPI.Repositories
{
    /// <summary>
    /// Encapsulates logic for interacting with profiles in the selected database
    /// </summary>
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
