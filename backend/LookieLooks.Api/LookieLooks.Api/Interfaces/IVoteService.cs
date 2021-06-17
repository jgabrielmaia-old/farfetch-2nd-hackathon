using LookieLooks.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Interfaces
{
    public interface IVoteService
    {
        public async Task<string> ComputeVoteAsync(Vote vote);
    }
}
