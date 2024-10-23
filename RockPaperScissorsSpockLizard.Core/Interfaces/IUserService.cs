using RockPaperScissorsSpockLizard.Core.Entities;
using System.Security.Claims;

namespace RockPaperScissorsSpockLizard.Core.Interfaces
{
    public interface IUserService
    {
        string GetPlayerId(ClaimsPrincipal user);
        string Login(User user);
    }
}
