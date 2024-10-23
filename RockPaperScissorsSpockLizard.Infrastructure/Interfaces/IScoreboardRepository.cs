using RockPaperScissorsSpockLizard.Core.Entities;

namespace RockPaperScissorsSpockLizard.Infrastructure.Interfaces
{
    public interface IScoreboardRepository
    {
        public IEnumerable<GameResult> GetRecentResults();
        public void AddResult(GameResult result);
        public void ResetScoreboard();
    }
}
