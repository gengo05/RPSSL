using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;
using RockPaperScissorsSpockLizard.Infrastructure.Interfaces;

namespace RockPaperScissorsSpockLizard.API.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController(IGameService gameService, IOpponentMoveService opponentMoveService, IScoreboardRepository scoreboardRepository, IUserService userService, IMapper mapper) : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Play([FromBody] GameRequestDto playRequest)
        {
            try
            {
                string playerId = userService.GetPlayerId(User);
                GameResult gameResult = gameService.Play(playerId, playRequest.PlayerMove, opponentMoveService.GetRandomOpponentMove());
                scoreboardRepository.AddResult(gameResult);

                GameResultDto resultDto = mapper.Map<GameResultDto>(gameResult);

                return Ok(resultDto);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
