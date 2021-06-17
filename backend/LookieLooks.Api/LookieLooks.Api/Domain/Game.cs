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

        public Guid AttributeId { get; set; }

        public bool IsBallotOpen { get; set; }

        public IEnumerable<Vote> Votes { get; set; }
    }
}
