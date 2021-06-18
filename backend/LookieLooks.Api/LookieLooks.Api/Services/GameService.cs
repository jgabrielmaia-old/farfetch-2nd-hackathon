using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LookieLooks.Api.Repositories;
using Microsoft.Extensions.Configuration;

namespace LookieLooks.Api.Services
{
    public class GameService : IGameService
    {
        private readonly IConfiguration config;
        private readonly IMongoRepository<Domain.Game> _gameRepository;
        private readonly IMongoRepository<Domain.Vote> _voteRepository;
        private readonly IMongoRepository<Domain.User> _userRepository;
        private readonly IMongoRepository<Domain.Product> _productsRepository;
        private readonly IMongoRepository<Domain.TypeAttribute> _typeAttributeRepository;
        public GameService(IMongoRepository<Domain.Game> gameRepository, IConfiguration configuration, IMongoRepository<Domain.Vote> voteRepository, IMongoRepository<Domain.User> userRepository,
            IMongoRepository<Domain.Product> productsRepository, IMongoRepository<Domain.TypeAttribute> typeAttributeRepository)
        {
            config = configuration;
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
                    var attributeWithOptions = allTypeAttributes.Where(x => x.Type.ToLower() == product.Type.ToLower()).FirstOrDefault();
                    var attributes = attributeWithOptions.Attributes.Select(x => x.Key).ToList();
                    foreach (var attribute in attributes)
                    {
                        if (!usedCombinations.Any(g => g.Item1 == product.ProductId && g.Item2 == attribute))
                        {
                            attributeWithOptions.Attributes.TryGetValue(attribute, out var options);
                            Domain.Game game = new Domain.Game()
                            {
                                GameId = Guid.NewGuid(),
                                AttributeName = attribute,
                                IsBallotOpen = true,
                                ProductId = product.ProductId,
                                ImageLinks = product.ImageLinks,
                                AttributeOptions = options

                            };
                            _gameRepository.InsertOne(game);
                            return game;
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

            int ammountOfPoints = 0;

            string NumberofVotesToEndGame = config.GetSection("Settings").GetSection("NumberofVotesToEndGame").Value;
            if (int.TryParse(NumberofVotesToEndGame, out int numbertoEndGame))
            {
                if(userIds.Count == numbertoEndGame)
                {
                    ammountOfPoints = 3;
                } else
                {
                    ammountOfPoints = 5;
                }
            }
            else
            {
                ammountOfPoints = 3;
            }

            foreach (string id in userIds)
            {
                Domain.User selectedUser = _userRepository.FindOne(user => user.UserName == id);
                selectedUser.Score += ammountOfPoints;
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
                    ImageLinks = product.ImageLinks,
                    ProductId = product.ProductId
                };
                domainProducts.Add(domainProduct);
            }
            _productsRepository.InsertManyAsync(domainProducts);
        }

        public void CreateTypeAttributes(List<TypeAttribute> typeAttributes)
        {
            var domainTypeAttributes = new List<Domain.TypeAttribute>();
            foreach (var attribute in typeAttributes)
            {
                var domainTypeAttribute = new Domain.TypeAttribute()
                {
                    Type = attribute.Type,
                    Attributes = attribute.Attributes
                };
                domainTypeAttributes.Add(domainTypeAttribute);
            }
            _typeAttributeRepository.InsertManyAsync(domainTypeAttributes);
        }
    }
}
