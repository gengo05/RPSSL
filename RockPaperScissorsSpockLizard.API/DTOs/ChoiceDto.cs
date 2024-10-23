using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.API.DTOs
{
    public class ChoiceDto
    {
        public GameMove Move { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
