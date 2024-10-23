using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RockPaperScissorsSpockLizard.API.Controllers;
using RockPaperScissorsSpockLizard.API.DTOs;
using RockPaperScissorsSpockLizard.API.Profiles;
using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.Tests.ControllerTests
{
    public class ChoiceControllerTests
    {
        private readonly Mock<IChoiceService> _mockChoiceService;
        private readonly ChoiceController _controller;

        public ChoiceControllerTests()
        {
            _mockChoiceService = new Mock<IChoiceService>();

            MappingProfile myProfile = new();
            MapperConfiguration configuration = new(cfg => cfg.AddProfile(myProfile));
            Mapper mapper = new(configuration);

            _controller = new ChoiceController(_mockChoiceService.Object, mapper);
        }

        [Fact]
        public void GetChoices_ReturnsOkResult_WithMappedChoices()
        {
            Choice[] choices =
            [
                new Choice(GameMove.Rock),
                new Choice(GameMove.Paper),
                new Choice(GameMove.Scissors),
                new Choice(GameMove.Lizard),
                new Choice(GameMove.Rock),
            ];

            _ = _mockChoiceService.Setup(service => service.GetAllChoices()).Returns(choices);

            IActionResult result = _controller.GetChoices();

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            IEnumerable<ChoiceDto> returnChoiceDtos = Assert.IsAssignableFrom<IEnumerable<ChoiceDto>>(okResult.Value);
            Assert.Equal(choices.Length, returnChoiceDtos.Count());
        }

        [Fact]
        public void GetRandomChoice_ReturnsOkResult_WithMappedRandomChoice()
        {
            Choice randomChoice = new(GameMove.Spock);
            _ = _mockChoiceService.Setup(service => service.GetRandomChoice()).Returns(randomChoice);

            IActionResult result = _controller.GetRandomChoice();

            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result);
            ChoiceDto returnChoiceDto = Assert.IsType<ChoiceDto>(okResult.Value);
            Assert.Equal(randomChoice.Move, returnChoiceDto.Move);
            Assert.Equal(randomChoice.Name, returnChoiceDto.Name);
        }
    }
}
