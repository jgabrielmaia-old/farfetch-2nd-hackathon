using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("closedGames")]
    public class ClosedGame : Document
    {
        public int ProductId { get; set; }

        public IDictionary<string, string> ClosedAttributes { get; set; }

        public bool isClosed { get; set; }
    }
}
