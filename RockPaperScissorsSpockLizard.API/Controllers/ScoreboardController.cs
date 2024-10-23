using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Infrastructure.Interfaces;

namespace RockPaperScissorsSpockLizard.API.Controllers
{
    [ApiController]
    [Route("api/scoreboard")]
    public class ScoreboardController(IScoreboardRepository scoreboardRepository, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Scoreboard()
        {
            IEnumerable<GameResult> result = scoreboardRepository.GetRecentResults();
            IEnumerable<GameResultDto> resultDtos = mapper.Map<IEnumerable<GameResultDto>>(result);

            return base.Ok(resultDtos);
        }

        [HttpPost("reset")]
        [Authorize]
        public IActionResult ResetScoreboard()
        {
            scoreboardRepository.ResetScoreboard();
            return NoContent();
        }
    }
}
