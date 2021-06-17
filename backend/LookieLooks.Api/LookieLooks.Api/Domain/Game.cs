using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("games")]
    public class Game : Document
    {
        public Guid GameId { get; set; }

        public int ProductId { get; set; }

        public string AttributeName { get; set; }

        public bool IsBallotOpen { get; set; }

        public IEnumerable<Vote> Votes { get; set; }

        public Model.Game GetResponse()
        {
            Model.Game gameDto = new Model.Game()
            {
                AttributeId = AttributeName,
                GameId = GameId,
                IsBallotOpen = IsBallotOpen,
                Created = CreatedDate,
                ProductId = ProductId,
                Votes = new List<Model.Vote>()
            };

            foreach(var vote in Votes)
            {
                gameDto.Votes.Append(new Model.Vote()
                {
                    GameId = vote.GameId,
                    SelectedOption = vote.SelectedOption,
                    UserName = vote.UserName
                });
            }
            return gameDto;
        }
    }
}
