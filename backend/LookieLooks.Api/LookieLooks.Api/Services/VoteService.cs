using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using LookieLooks.Api.Repositories;
using Microsoft.Extensions.Configuration;

namespace LookieLooks.Api.Services
{
    public class VoteService : IVoteService
    {
        private readonly IConfiguration config;
        private readonly IGameService _gameService;
        private readonly IMongoRepository<Domain.Vote> _voteRepository;

        public VoteService(IConfiguration configuration, IGameService gameService, IMongoRepository<Domain.Vote> voteRepository)
        {
            config = configuration;
            _gameService = gameService;
            _voteRepository = voteRepository;
        }

        public async Task<string> ComputeVoteAsync(Vote vote)
        {
            Domain.Vote voteToAdd = new Domain.Vote()
            {
                GameId = vote.GameId,
                SelectedOption = vote.SelectedOption,
                UserId = vote.UserId
            };
            await _voteRepository.InsertOneAsync(voteToAdd);

            int numberOfVotes = _voteRepository.FilterBy(votes => votes.GameId == vote.GameId).Count();
            string NumberofVotesToEndGame = config.GetSection("Settings").GetSection("NumberofVotesToEndGame").Value;
            if (int.TryParse(NumberofVotesToEndGame, out int numbertoEndGame))
            {
                if (numberOfVotes == numbertoEndGame)
                {
                    _gameService.CloseGameAsync(vote.GameId);
                }
            }
            else
            {
                return "Invalid Appsettings Number to end Game";
            }


            return null;
        }
    }
}
