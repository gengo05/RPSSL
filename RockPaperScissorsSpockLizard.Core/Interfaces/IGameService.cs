using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.Core.Interfaces
{
    public interface IGameService
    {
        GameResult Play(string player, GameMove playerMove, GameMove opponentMove);
    }
}
