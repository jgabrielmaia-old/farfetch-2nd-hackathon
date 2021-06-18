using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace LookieLooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;
        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [Route("ComputeVote")]
        [HttpPost]
        public void ComputeVoteAsync([FromBody] Vote vote)
        {
            _voteService.ComputeVoteAsync(vote);
        }
    }
}
