using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Domain
{
    public abstract class Document : IDocument
    {
        public virtual ObjectId Id { get; set; }

        public DateTime CreatedDate => Id.CreationTime;
    }
}
