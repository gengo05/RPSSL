using Microsoft.Extensions.Logging;
using Moq;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Exceptions;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Core.Services;

namespace RockPaperScissorsSpockLizard.Tests.ServiceTests
{
    public class GameServiceTests
    {
        private readonly Mock<ILogger<GameService>> _mockLogger = new();
        private readonly Mock<IGameDecisionMaker> _mockGameDecisionMaker = new();
        private readonly GameService _gameService;

        public GameServiceTests() => _gameService = new GameService(_mockLogger.Object, _mockGameDecisionMaker.Object);

        [Theory]
        [InlineData(GameMove.Rock, GameMove.Scissors, GameOutcome.PlayerWins)]
        [InlineData(GameMove.Paper, GameMove.Rock, GameOutcome.PlayerWins)]
        [InlineData(GameMove.Scissors, GameMove.Paper, GameOutcome.PlayerWins)]
        [InlineData(GameMove.Lizard, GameMove.Spock, GameOutcome.PlayerWins)]
        [InlineData(GameMove.Spock, GameMove.Scissors, GameOutcome.PlayerWins)]
        public void Play_ShouldReturnGameResult_WhenCallValid(GameMove playerMove, GameMove opponentMove, GameOutcome expectedOutcome)
        {
            _ = _mockGameDecisionMaker.Setup(dm => dm.DetermineWinner(playerMove, opponentMove)).Returns(expectedOutcome);
            string player = "Player1";

            GameResult result = _gameService.Play(player, playerMove, opponentMove);

            Assert.Equal(expectedOutcome, result.GameOutcome);
            Assert.Equal(playerMove, result.PlayerMove);
            Assert.Equal(opponentMove, result.OpponentMove);

            _mockLogger.Verify(m => m.Log(LogLevel.Information, It.IsAny<EventId>(), It.Is<It.IsAnyType>((v, _) => v.ToString()!.Contains($"PlayerMove: {playerMove}, OpponentMove: {opponentMove}, Result: {expectedOutcome}")), null, It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);

        }

        [Theory]
        [InlineData((GameMove)999, GameMove.Scissors)]
        [InlineData(GameMove.Scissors, (GameMove)999)]

        public void Playe_ShouldThrowInvalidGameMoveException_WhenInvalidMove(GameMove playerMove, GameMove opponentMove)
        {
            GameMove invalidMove = (GameMove)999;

            InvalidGameMoveException exception = Assert.Throws<InvalidGameMoveException>(() => _gameService.Play("player", playerMove, opponentMove));
            Assert.Equal($"Invalid move: {invalidMove}", exception.Message);

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<InvalidGameMoveException>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
        }

        [Fact]
        public void Playe_ShouldException_WhenErrorOcurres()
        {
            _ = _mockGameDecisionMaker.Setup(x => x.DetermineWinner(It.IsAny<GameMove>(), It.IsAny<GameMove>())).Throws(new Exception("Unsupported exception"));

            Exception exception = Assert.Throws<Exception>(() => _gameService.Play("player", GameMove.Rock, GameMove.Rock));
            Assert.Equal("An error occurred while playing the game.", exception.Message);

            _mockLogger.Verify(x => x.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception?, string>>()), Times.Once);
        }

    }
}
