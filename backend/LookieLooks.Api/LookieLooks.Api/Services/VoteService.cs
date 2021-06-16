using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using Microsoft.Extensions.Configuration;

namespace LookieLooks.Api.Services
{
    public class VoteService : IVoteService
    {
        private readonly IConfiguration config;

        public VoteService(IConfiguration configuration)
        {
            config = configuration;
        }

        public Task ComputeVoteAsync(Vote vote)
        {
            //TODO - call function from repo to save Vote into db


            int numberOfVotes = 1; //TODO - call function from repo to get number of votes where gameId=vote.gameId
            string NumberofVotesToEndGame = config.GetSection("Settings").GetSection("NumberofVotesToEndGame").Value;
            if (int.TryParse(NumberofVotesToEndGame, out int numbertoEndGame))
            {
                if (numberOfVotes == numbertoEndGame)
                {
                    GameService gameService = new GameService();
                    gameService.CloseGameAsync(vote.GameId);
                }
            }
            else
            {
                throw new Exception("Invalid Appsettings Number to end Game");
            }


            throw new NotImplementedException();
        }
    }
}
