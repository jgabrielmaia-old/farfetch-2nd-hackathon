using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("products")]
    public class Product : Document
    {
        public int ProductId { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> ImageLinks { get; set; }
    }
}
