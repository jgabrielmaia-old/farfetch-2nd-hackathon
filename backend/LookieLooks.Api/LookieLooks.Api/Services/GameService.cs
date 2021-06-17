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
        private readonly IMongoRepository<Domain.Product> _productsRepository;
        private readonly IMongoRepository<Domain.TypeAttribute> _typeAttributeRepository;
        public GameService(IMongoRepository<Domain.Game> gameRepository, IMongoRepository<Domain.Vote> voteRepository, IMongoRepository<Domain.User> userRepository,
            IMongoRepository<Domain.Product> productsRepository, IMongoRepository<Domain.TypeAttribute> typeAttributeRepository)
        {
            _gameRepository = gameRepository;
            _voteRepository = voteRepository;
            _userRepository = userRepository;
            _productsRepository = productsRepository;
            _typeAttributeRepository = typeAttributeRepository;
        }
        public Guid CloseGameAsync(Guid gameId)
        {
            Domain.Game selectedGame = _gameRepository.FindOne(x=> x.GameId == gameId);
            selectedGame.IsBallotOpen = false;
            _gameRepository.ReplaceOne(selectedGame);
            ComputeGameScore(gameId);
            return gameId;
        }

        public void CreateGameAsync(int productId, string attributeName)
        {
            Domain.Game newGame = new Domain.Game()
            {
                AttributeName = attributeName,
                ProductId = productId,
                IsBallotOpen = true,
                GameId = Guid.NewGuid()
            };

            _gameRepository.InsertOne(newGame);
        }

        public IEnumerable<Domain.Vote> GetCurrentVotesAsync(Guid gameId)
        {
            IEnumerable<Domain.Vote> voteList = _voteRepository.FilterBy(votes => votes.GameId == gameId);
            return voteList;
        }

        public Domain.Game GetRandomGameAsync(string userName)
        {
            var gameswhereUserIsPresent = _voteRepository.FilterBy(votes => votes.UserName == userName).Select(x => x.GameId).ToList();
            Domain.Game newUserGame = _gameRepository.FilterBy(game => !gameswhereUserIsPresent.Contains(game.GameId)).OrderByDescending(game => game.Votes.Count()).FirstOrDefault();

            if (newUserGame == null)
            {
                var newGame = new Domain.Game();
                var allGames = _gameRepository.FilterBy(x => true).ToList();
                var allProducts = _productsRepository.FilterBy(x => true).ToList();
                var allTypeAttributes = _typeAttributeRepository.FilterBy(x => true).ToList();

                List<Tuple<int, string>> usedCombinations = _gameRepository.FilterBy(x => true)
                    .Select(g => new Tuple<int, string>(g.ProductId, g.AttributeName))
                    .ToList();

                foreach (var product in allProducts)
                {
                    var attributes = allTypeAttributes.Where(x => x.Type == product.Type).SelectMany(x => x.Attributes.Keys).ToList();
                    foreach (var attribute in attributes)
                    {
                        if (!usedCombinations.Any(g => g.Item1 == product.ProductId && g.Item2 == attribute))
                        {
                            Domain.Game game = new Domain.Game()
                            {
                                AttributeName = attribute,
                                IsBallotOpen = true,
                                ProductId = product.ProductId
                            };
                            _gameRepository.InsertOne(game);
                            newGame = game;
                        }
                    }
                }
                return newGame;
            }
            else
            {
                return newUserGame;
            }
        }

        public IEnumerable<Domain.Game> GetUserGamesAsync(string userName)
        {
            IEnumerable<Guid> gameIdList = _voteRepository.FilterBy(votes => votes.UserName == userName).Select(votesOfUser => votesOfUser.GameId);
            IEnumerable<Domain.Game> gameList = _gameRepository.FilterBy(game => gameIdList.Contains(game.GameId));
            return gameList;
        }

        public int GetUserPointsAsync(string userName)
        {
            int userScore = _userRepository.FindOne(x => x.UserName == userName).Score;
            return userScore;
        }

        private void ComputeGameScore(Guid gameId)
        {
            List<string> userIds = _voteRepository.FilterBy(votes => votes.GameId == gameId)
                .GroupBy(votesOfGame => votesOfGame.SelectedOption)
                .OrderByDescending(votesOfGameByOption => votesOfGameByOption.Count())
                .First()
                .Select(winningVotes => winningVotes.UserName)
                .ToList();

            foreach (string id in userIds)
            {
                Domain.User selectedUser = _userRepository.FindOne(user => user.UserName == id);
                selectedUser.Score += 5;
                _userRepository.ReplaceOne(selectedUser);
            }
        }

        public void CreateProducts(List<Product> products)
        {
            var domainProducts = new List<Domain.Product>();
            foreach(var product in products)
            {
                var domainProduct = new Domain.Product()
                {
                    Type = product.Type,
                    ImagesLink = product.ImagesLink,
                    ProductId = product.ProductId
                };
                domainProducts.Add(domainProduct);
            }
            _productsRepository.InsertManyAsync(domainProducts);
        }
    }
}
