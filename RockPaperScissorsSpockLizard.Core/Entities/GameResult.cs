namespace RockPaperScissorsSpockLizard.Core.Entities
{
    public class GameResult
    {
        public string Player { get; set; } = string.Empty;
        public GameMove PlayerMove { get; set; }
        public GameMove OpponentMove { get; set; }
        public GameOutcome GameOutcome { get; set; }
    }
}
