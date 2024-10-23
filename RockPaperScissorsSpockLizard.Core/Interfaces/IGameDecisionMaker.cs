using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.Core.Interfaces
{
    public interface IGameDecisionMaker
    {
        GameOutcome DetermineWinner(GameMove playerMove, GameMove opponentMove);
    }
}
