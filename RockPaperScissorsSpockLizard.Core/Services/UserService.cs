using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Core.Utilities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RockPaperScissorsSpockLizard.Core.Services
{
    public class UserService(IConfiguration configuration) : IUserService
    {
        private readonly List<User> _users =
        [
            new() { UserName = "Admin", Password = "Password" },
            new() { UserName = "User1", Password = "Password" },
            new() { UserName = "User2", Password = "Password" },
            new() { UserName = "User3", Password = "Password" },
            new() { UserName = "User4", Password = "Password" },
        ];

        public string GetPlayerId(ClaimsPrincipal user) => Guard.AgainstNullOrEmpty(user.Identity!.Name);

        public string Login(User user)
        {
            User LoginUser = Guard.AgainstNull(_users.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password));

            byte[] key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]!);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity([new(ClaimTypes.Name, user.UserName)]),
                Expires = DateTime.UtcNow.AddYears(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityTokenHandler().CreateToken(tokenDescriptor));
        }
    }
}
