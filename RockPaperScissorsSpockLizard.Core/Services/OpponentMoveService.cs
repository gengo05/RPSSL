using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Core.Interfaces;

namespace RockPaperScissorsSpockLizard.Core.Services
{
    public class OpponentMoveService : IOpponentMoveService
    {
        private readonly Random _random = new();

        public GameMove GetRandomOpponentMove() => (GameMove)Enum.GetValues(typeof(GameMove)).GetValue(_random.Next(Enum.GetValues(typeof(GameMove)).Length))!;
    }
}
