namespace RockPaperScissorsSpockLizard.Core.Entities
{
    public enum GameOutcome
    {
        PlayerWins = 0,
        OpponentWins,
        Draw
    }

    public static class GameOutcomeExtensions
    {
        public static string ToFriendlyString(this GameOutcome outcome) => outcome switch
        {
            GameOutcome.PlayerWins => "Player Wins",
            GameOutcome.OpponentWins => "Opponent Wins",
            GameOutcome.Draw => "It's a Draw",
            _ => "Unknown Outcome"
        };
    }
}
