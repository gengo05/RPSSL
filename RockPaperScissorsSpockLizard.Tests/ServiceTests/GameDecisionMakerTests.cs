using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Services;

namespace RockPaperScissorsSpockLizard.Tests.ServiceTests
{
    public class GameDecisionMakerTests
    {
        private readonly GameDecisionMaker _decisionMaker = new();

        public static IEnumerable<object[]> GetTestData() =>
        [
            [GameMove.Rock, GameMove.Rock, GameOutcome.Draw],
            [GameMove.Paper, GameMove.Paper, GameOutcome.Draw],
            [GameMove.Scissors, GameMove.Scissors, GameOutcome.Draw],
            [GameMove.Lizard, GameMove.Lizard, GameOutcome.Draw],
            [GameMove.Spock, GameMove.Spock, GameOutcome.Draw],

            [GameMove.Rock, GameMove.Scissors, GameOutcome.PlayerWins],
            [GameMove.Rock, GameMove.Lizard, GameOutcome.PlayerWins],
            [GameMove.Paper, GameMove.Rock, GameOutcome.PlayerWins],
            [GameMove.Paper, GameMove.Spock, GameOutcome.PlayerWins],
            [GameMove.Scissors, GameMove.Paper, GameOutcome.PlayerWins],
            [GameMove.Scissors, GameMove.Lizard, GameOutcome.PlayerWins],
            [GameMove.Lizard, GameMove.Spock, GameOutcome.PlayerWins],
            [GameMove.Lizard, GameMove.Paper, GameOutcome.PlayerWins],
            [GameMove.Spock, GameMove.Scissors, GameOutcome.PlayerWins],
            [GameMove.Spock, GameMove.Rock, GameOutcome.PlayerWins],

            [GameMove.Scissors, GameMove.Rock, GameOutcome.OpponentWins],
            [GameMove.Lizard, GameMove.Rock, GameOutcome.OpponentWins],
            [GameMove.Rock, GameMove.Paper, GameOutcome.OpponentWins],
            [GameMove.Spock, GameMove.Paper, GameOutcome.OpponentWins],
            [GameMove.Paper, GameMove.Scissors, GameOutcome.OpponentWins],
            [GameMove.Lizard, GameMove.Scissors, GameOutcome.OpponentWins],
            [GameMove.Spock, GameMove.Lizard, GameOutcome.OpponentWins],
            [GameMove.Paper, GameMove.Lizard, GameOutcome.OpponentWins],
            [GameMove.Scissors, GameMove.Spock, GameOutcome.OpponentWins],
            [GameMove.Rock, GameMove.Spock, GameOutcome.OpponentWins],
        ];

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void DetermineWinner_VariousCases_ReturnsExpectedOutcome(GameMove playerMove, GameMove opponentMove, GameOutcome expectedOutcome)
        {
            GameOutcome outcome = _decisionMaker.DetermineWinner(playerMove, opponentMove);
            Assert.Equal(expectedOutcome, outcome);
        }
    }
}
