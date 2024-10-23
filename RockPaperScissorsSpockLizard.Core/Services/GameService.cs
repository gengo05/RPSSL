using Microsoft.Extensions.Logging;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Exceptions;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.Core.Services
{
    public class GameService(ILogger<GameService> loggingService, IGameDecisionMaker decisionMaker) : IGameService
    {
        public GameResult Play(string player, GameMove playerMove, GameMove opponentMove)
        {
            try
            {
                if (!GameMoveExtensions.IsValid(playerMove)) throw new InvalidGameMoveException($"Invalid move: {playerMove}");
                if (!GameMoveExtensions.IsValid(opponentMove)) throw new InvalidGameMoveException($"Invalid move: {opponentMove}");

                GameOutcome gameOutcome = decisionMaker.DetermineWinner(playerMove, opponentMove);

                GameResult gameResult = new()
                {
                    Player = player,
                    PlayerMove = playerMove,
                    OpponentMove = opponentMove,
                    GameOutcome = gameOutcome
                };

                loggingService.LogInformation("PlayerMove: {playerMove}, OpponentMove: {opponentMove}, Result: {gameOutcome}", playerMove, opponentMove, gameOutcome);

                return gameResult;
            }
            catch (InvalidGameMoveException ex)
            {
                loggingService.LogError(ex, "Invalid move detected");
                throw;
            }
            catch (Exception ex)
            {
                loggingService.LogError(ex, "An error occurred while playing the game.");
                throw new Exception("An error occurred while playing the game.", ex);
            }
        }
    }
}
