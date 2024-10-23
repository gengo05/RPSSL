using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.Core.Services
{
    public class GameDecisionMaker : IGameDecisionMaker
    {
        private readonly Dictionary<GameMove, List<GameMove>> _winningMoves = new()
        {
            { GameMove.Rock, new List<GameMove> { GameMove.Scissors, GameMove.Lizard } },
            { GameMove.Paper, new List<GameMove> { GameMove.Rock, GameMove.Spock } },
            { GameMove.Scissors, new List<GameMove> { GameMove.Paper, GameMove.Lizard } },
            { GameMove.Spock, new List<GameMove> { GameMove.Scissors, GameMove.Rock } },
            { GameMove.Lizard, new List<GameMove> { GameMove.Spock, GameMove.Paper } }
        };

        public GameOutcome DetermineWinner(GameMove playerMove, GameMove opponentMove) => playerMove == opponentMove
            ? GameOutcome.Draw : _winningMoves[playerMove].Contains(opponentMove)
            ? GameOutcome.PlayerWins : GameOutcome.OpponentWins;
    }
}
