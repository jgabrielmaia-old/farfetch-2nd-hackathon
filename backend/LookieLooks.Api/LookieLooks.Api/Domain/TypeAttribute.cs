using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    [BsonCollection("type_attributes")]
    public class TypeAttribute
    {
        public string Type { get; set; }

        public IDictionary<string, List<string>> Attributes { get; set; }
    }
}
