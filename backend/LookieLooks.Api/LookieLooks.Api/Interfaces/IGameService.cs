using LookieLooks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Interfaces
{
    public interface IGameService
    {
        public void CreateGameAsync(int productId, Guid attributeId);

        public Task<Guid> CloseGameAsync(Guid gameId);

        public Task<IEnumerable<Vote>> GetCurrentVotesAsync(Guid gameId);

        public Task<Game> GetRandomGameAsync(Guid userId);

        public Task<IEnumerable<Game>> GetUserGamesAsync(Guid userId);

        public Task<int> GetUserPointsAsync(Guid userId);
    }
}
