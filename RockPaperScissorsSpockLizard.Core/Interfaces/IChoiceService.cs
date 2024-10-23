using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.Core.Interfaces
{
    public interface IChoiceService
    {
        IEnumerable<Choice> GetAllChoices();
        Choice GetRandomChoice();
    }
}
