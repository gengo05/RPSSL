using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Services;

namespace RockPaperScissorsSpockLizard.Tests.ServiceTests
{
    public class ChoiceServiceTests
    {
        private readonly ChoiceService _choiceService;

        public ChoiceServiceTests() => _choiceService = new ChoiceService();

        [Fact]
        public void GetAllChoices_ShouldReturnAllChoices()
        {
            List<Choice> choices = _choiceService.GetAllChoices().ToList();

            Assert.Equal(5, choices.Count);
            Assert.Contains(choices, c => c.Move == GameMove.Rock);
            Assert.Contains(choices, c => c.Move == GameMove.Paper);
            Assert.Contains(choices, c => c.Move == GameMove.Scissors);
            Assert.Contains(choices, c => c.Move == GameMove.Lizard);
            Assert.Contains(choices, c => c.Move == GameMove.Spock);

            Assert.Contains(choices, c => c.Name == GameMove.Rock.ToLowerString());
            Assert.Contains(choices, c => c.Name == GameMove.Paper.ToLowerString());
            Assert.Contains(choices, c => c.Name == GameMove.Scissors.ToLowerString());
            Assert.Contains(choices, c => c.Name == GameMove.Lizard.ToLowerString());
            Assert.Contains(choices, c => c.Name == GameMove.Spock.ToLowerString());
        }

        [Fact]
        public void GetRandomChoice_ShouldReturnAChoice()
        {
            Choice choice = _choiceService.GetRandomChoice();

            Assert.NotNull(choice);
            _ = Assert.IsType<Choice>(choice);
            Assert.True(Enum.IsDefined(typeof(GameMove), choice.Move));
        }

        [Fact]
        public void GetRandomChoice_ShouldReturnChoicesWithinValidRange()
        {
            int choiceCount = 100;

            List<Choice> results = Enumerable.Range(0, choiceCount).Select(_ => _choiceService.GetRandomChoice()).ToList();

            Assert.All(results, choice => Assert.IsType<Choice>(choice));
            Assert.All(results, choice => Assert.True(Enum.IsDefined(typeof(GameMove), choice.Move)));
        }
    }
}