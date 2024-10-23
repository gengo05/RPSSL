namespace RockPaperScissorsSpockLizard.Core.Utilities
{
    public static class Guard
    {
        public static string AgainstNullOrEmpty(string? argument) => string.IsNullOrEmpty(argument)
            ? throw new ArgumentException($"'{nameof(argument)}' cannot be null or empty.", nameof(argument))
            : argument;

        public static T AgainstNull<T>(T? argument) where T : class =>
            argument ?? throw new ArgumentNullException(nameof(argument), $"'{nameof(argument)}' cannot be null.");
    }
}
