using System.Globalization;

namespace RockPaperScissorsSpockLizard.Core.Entities
{
    public enum GameMove
    {
        Rock = 0,
        Paper,
        Scissors,
        Spock,
        Lizard
    }

    public static class GameMoveExtensions
    {
        public static bool IsValid(GameMove move) => Enum.IsDefined(typeof(GameMove), move);
        public static string GetAllMovesAsString() => string.Join(", ", Enum.GetNames(typeof(GameMove)));
        public static string ToLowerString(this GameMove gameMove) => gameMove.ToString().ToLower(CultureInfo.InvariantCulture);
    }
}
