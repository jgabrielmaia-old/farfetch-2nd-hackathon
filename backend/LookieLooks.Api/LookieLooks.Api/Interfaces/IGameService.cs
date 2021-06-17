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

        public Guid CloseGameAsync(Guid gameId);

        public IEnumerable<Domain.Vote> GetCurrentVotesAsync(Guid gameId);

        public Domain.Game GetRandomGameAsync(Guid userId);

        public IEnumerable<Domain.Game> GetUserGamesAsync(Guid userId);

        public int GetUserPointsAsync(Guid userId);
    }
}
