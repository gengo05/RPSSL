using RockPaperScissorsSpockLizard.Core.Entities;
using RockPaperScissorsSpockLizard.Infrastructure.Interfaces;

namespace RockPaperScissorsSpockLizard.Infrastructure.Services
{
    public class ScoreboardRepository : IScoreboardRepository
    {
        private static readonly Queue<GameResult> _recentResults = new();
        private const int MaxResults = 10;

        public IEnumerable<GameResult> GetRecentResults() => _recentResults;

        public void AddResult(GameResult result)
        {
            if (_recentResults.Count == MaxResults)
                _ = _recentResults.Dequeue();

            _recentResults.Enqueue(result);
        }

        public void ResetScoreboard() => _recentResults.Clear();
    }
}
