using AutomationAPI.Models;

namespace AutomationAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
