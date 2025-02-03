using AutomationAPI.Interfaces;
using AutomationAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AutomationAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config; 
        private readonly SymmetricSecurityKey _key;  

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the token is being generated.</param>
        /// <returns>A string representation of the generated JWT token.</returns>
        public string CreateToken(AppUser user)
        {
            // Create a list of claims to describe user in token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email), 
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)  
            };

            // Create signing credentials (ensure key phrase meets bytes length requirement of algo)
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            // Set up blueprint for JWT tokens
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), 
                Expires = DateTime.Now.AddDays(7), 
                SigningCredentials = creds,  
                Issuer = _config["JWT:Issuer"],  
                Audience = _config["JWT:Audience"]  
            };

            // Use token handler to create token from blueprint - return as string
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
