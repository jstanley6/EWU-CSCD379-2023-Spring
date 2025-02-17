﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class LeaderboardController : ControllerBase
    {
        private readonly LeaderboardService _leaderboardService;
     public LeaderboardController(LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }
        [HttpGet("GetTopTenScores")]
        public async Task<IEnumerable<Player>> GetTopTenScores()
        {
            return await _leaderboardService.GetTopTenScores();
        }

        [HttpGet("GetPlayerStats")]
        public async Task<Player> GetPlayerStats(string playerName)
        {
            return await _leaderboardService.GetPlayerStats(playerName);
        }
        [HttpPost("AddNewPlayer")]
   
        public async Task<Player> AddNewPlayer(string? playerName, double totalAttempts, int totalTime)
        {
            return await _leaderboardService.AddPlayer(playerName,totalAttempts,totalTime);
        }

    }
}
