using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("user")]
    public class User : Document
    {
        public Guid UserId { get; set; }

        public string AvatarImageUrl { get; set; }

        public int Score { get; set; }
    }
}
