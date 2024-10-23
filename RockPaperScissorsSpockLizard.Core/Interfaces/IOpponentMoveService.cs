using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.Core.Interfaces
{
    public interface IOpponentMoveService
    {
        GameMove GetRandomOpponentMove();
    }
}
