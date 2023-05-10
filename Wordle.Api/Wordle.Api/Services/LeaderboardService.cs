using Microsoft.EntityFrameworkCore;
using Wordle.Api.Data;

namespace Wordle.Api.Services
{
    public class LeaderboardService
    {
        private readonly AppDbContext _db;

        public LeaderboardService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetTopTenScores()
        {
            var highScore = await _db.Players.Take(10)
                                .OrderByDescending(player => player.AverageTimeInSeconds)
                                .ToListAsync();
            return highScore;
        }
    }
}
