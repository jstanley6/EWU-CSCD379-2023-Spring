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

        public async Task<Player> GetPlayerStats(string playerName)
        {
            var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerName == playerName);

            if (player == null)
            {
                throw new ArgumentException("Player not found");
            }

            return player;
        }
        public async Task<Player> AddPlayer(string? playerName, double totalAttempts, int totalTimeInSecs) 
        {
            var name = "";
            

            if (playerName is null)
            {
                throw new ArgumentException("Player name is a must!");
            }
            
            else
            {
                name = playerName; ;
            }
            var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerName == name);
            if(player is not null)
            {
                player = await UpdatePlayer(name, totalAttempts, totalTimeInSecs);

            }
            else
            {
                player = new()
                {
                    PlayerName = name,
                    GameCount = 1,
                    TotalAttempts = totalAttempts,
                    TotalTimeInSeconds = totalTimeInSecs,
                    AverageAttempts = totalAttempts,
                    AverageTimeInSeconds = totalTimeInSecs,
                };
                _db.Players.Add(player);
            }
            await _db.SaveChangesAsync();
            return player;

        }


            public async Task<Player> UpdatePlayer(string? name, double totalAttempts, int totalTimeInSecs)
            {
                var player = await _db.Players.FirstOrDefaultAsync(p => p.PlayerName == name);

         
            player!.GameCount++;
            player.AverageAttempts = player.TotalAttempts / player.GameCount;
            player.AverageTimeInSeconds = player.AverageTimeInSeconds / player.GameCount;
            player.TotalTimeInSeconds += totalTimeInSecs;
            player.TotalAttempts += player.TotalAttempts;

            return player;

        }
    }
}
