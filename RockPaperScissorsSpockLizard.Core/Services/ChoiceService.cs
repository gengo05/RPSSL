using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.Core.Services
{
    public class ChoiceService : IChoiceService
    {
        private readonly Random _random = new();

        public IEnumerable<Choice> GetAllChoices() =>
            Enum.GetValues(typeof(GameMove))
                .Cast<GameMove>()
                .Select(x => new Choice(x));

        public Choice GetRandomChoice()
        {
            List<GameMove> choices = Enum.GetValues(typeof(GameMove)).Cast<GameMove>().ToList();
            GameMove randomChoice = choices[_random.Next(choices.Count)];

            return new Choice(randomChoice);
        }
    }
}
