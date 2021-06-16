using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("vote")]
    public class Vote : Document
    {
        public Guid GameId { get; set; }

        public Guid UserId { get; set; }

        public string SelectedOption { get; set; }
    }
}
