namespace RockPaperScissorsSpockLizard.Core.Entities
{
    public class Choice(GameMove move)
    {
        public GameMove Move { get; } = move;

        public string Name => Move.ToString().ToLower();
    }
}
