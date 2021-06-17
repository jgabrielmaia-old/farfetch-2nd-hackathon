using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LookieLooks.Api.Repositories;

namespace LookieLooks.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IMongoRepository<Domain.Game> _gameRepository;
        private readonly IMongoRepository<Domain.Vote> _voteRepository;
        private readonly IMongoRepository<Domain.User> _userRepository;
        public GameService(IMongoRepository<Domain.Game> gameRepository, IMongoRepository<Domain.Vote> voteRepository, IMongoRepository<Domain.User> userRepository)
        {
            _gameRepository = gameRepository;
            _voteRepository = voteRepository;
            _userRepository = userRepository;
        }
        public Guid CloseGameAsync(Guid gameId)
        {
            Domain.Game selectedGame = _gameRepository.FindById(gameId.ToString());
            selectedGame.IsBallotOpen = false;
            _gameRepository.ReplaceOne(selectedGame);
            ComputeGameScore(gameId);
            return gameId;
        }

        public void CreateGameAsync(int productId, Guid attributeId)
        {
            Domain.Game newGame = new Domain.Game()
            {
                AttributeId = attributeId,
                ProductId = productId,
                GameId = Guid.NewGuid(),
                IsBallotOpen = true
            };

             _gameRepository.InsertOne(newGame);
        }

        public IEnumerable<Domain.Vote> GetCurrentVotesAsync(Guid gameId)
        {
            IEnumerable<Domain.Vote> voteList = _voteRepository.FilterBy(votes => votes.GameId == gameId);
            return voteList;
        }

        public Domain.Game GetRandomGameAsync(Guid userId)
        {
            List<Guid> gameswhereUserIsPresent = _voteRepository.FilterBy(votes => votes.UserId == userId).Select(votesOfUser => votesOfUser.GameId).ToList();
            Domain.Game newGame = _gameRepository.FilterBy(game => !gameswhereUserIsPresent.Contains(game.GameId)).OrderByDescending(game=>game.Votes.Count()).FirstOrDefault();
            
            if (newGame == null)
            {
                //TODO - Access product DB, choose a combo of attribute/product and create a new game
                throw new NotImplementedException();
            } else
            {
                return newGame;
            }
        }

        public IEnumerable<Domain.Game> GetUserGamesAsync(Guid userId)
        {
            IEnumerable<Guid> gameIdList = _voteRepository.FilterBy(votes => votes.UserId == userId).Select(votesOfUser=> votesOfUser.GameId);
            IEnumerable<Domain.Game> gameList = _gameRepository.FilterBy(game => gameIdList.Contains(game.GameId));
            return gameList;
        }

        public int GetUserPointsAsync(Guid userId)
        {
            int userScore = _userRepository.FindById(userId.ToString()).Score;
            return userScore;
        }

        private void ComputeGameScore(Guid gameId)
        {
            List<Guid> userIds = _voteRepository.FilterBy(votes => votes.GameId == gameId)
                .GroupBy(votesOfGame => votesOfGame.SelectedOption)
                .OrderByDescending(votesOfGameByOption => votesOfGameByOption.Count())
                .First()
                .Select(winningVotes => winningVotes.UserId)
                .ToList();

            foreach(Guid id in userIds)
            {
                Domain.User selectedUser =_userRepository.FindById(id.ToString());
                selectedUser.Score += 5;
                _userRepository.ReplaceOne(selectedUser);
            }
        }
    }
}
