using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RockPaperScissorsSpockLizard.API.Controllers;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.API.Profiles;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Infrastructure.Interfaces;

namespace RockPaperScissorsSpockLizard.Tests.ControllerTests
{
    public class GameControllerTests
    {
        private readonly Mock<IGameService> _mockGameService = new();
        private readonly Mock<IOpponentMoveService> _mockOpponentMoveService = new();
        private readonly Mock<IScoreboardRepository> _mockScoreboardRepository = new();
        private readonly Mock<IUserService> _mockUserService = new();
        private readonly GameController _controller;

        public GameControllerTests()
        {
            MappingProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            Mapper mapper = new(configuration);

            _controller = new GameController(_mockGameService.Object, _mockOpponentMoveService.Object, _mockScoreboardRepository.Object, _mockUserService.Object, mapper);
        }

        [Fact]
        public void Play_ValidMove_ShouldReturnOkResultWithGameResult()
        {
            GameMove playerMove = GameMove.Rock;
            string playerId = "test-player-id";
            GameRequestDto playRequest = new() { PlayerMove = playerMove };
            GameResult expectedResult = new() { PlayerMove = playerMove, OpponentMove = GameMove.Scissors, GameOutcome = GameOutcome.PlayerWins };

            _ = _mockUserService.Setup(us => us.GetPlayerId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Returns(playerId);
            _ = _mockOpponentMoveService.Setup(oms => oms.GetRandomOpponentMove()).Returns(GameMove.Scissors);
            _ = _mockGameService.Setup(gs => gs.Play(playerId, playerMove, GameMove.Scissors)).Returns(expectedResult);

            IActionResult result = _controller.Play(playRequest);
            _ = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Play_UnauthorizedAccess_ShouldReturnUnauthorized()
        {
            GameRequestDto playRequest = new() { PlayerMove = GameMove.Rock };
            _ = _mockUserService.Setup(us => us.GetPlayerId(It.IsAny<System.Security.Claims.ClaimsPrincipal>())).Throws(new UnauthorizedAccessException("Unauthorized access"));

            IActionResult result = _controller.Play(playRequest);

            UnauthorizedObjectResult unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal("Unauthorized access", unauthorizedResult.Value);
        }

    }
}
