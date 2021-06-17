using LookieLooks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Interfaces
{
    public interface IGameService
    {
        public void CreateGameAsync(int productId, string attributeName);

        public Guid CloseGameAsync(Guid gameId);

        public IEnumerable<Domain.Vote> GetCurrentVotesAsync(Guid gameId);

        public Domain.Game GetRandomGameAsync(string userName);

        public IEnumerable<Domain.Game> GetUserGamesAsync(string userName);

        public int GetUserPointsAsync(string userName);

        public void CreateProducts(List<Product> products);
    }
}
