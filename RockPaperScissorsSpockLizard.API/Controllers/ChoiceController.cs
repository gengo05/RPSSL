using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/choice")]
    public class ChoiceController(IChoiceService choiceService, IMapper mapper) : ControllerBase
    {
        [HttpGet("choices")]
        public IActionResult GetChoices()
        {
            IEnumerable<Choice> choices = choiceService.GetAllChoices();
            IEnumerable<ChoiceDto> choiceDtos = mapper.Map<IEnumerable<ChoiceDto>>(choices);

            return Ok(choiceDtos);
        }

        [HttpGet("choice")]
        public IActionResult GetRandomChoice()
        {
            Choice choice = choiceService.GetRandomChoice();
            ChoiceDto choiceDto = mapper.Map<ChoiceDto>(choice);

            return Ok(choiceDto);
        }
    }
}
