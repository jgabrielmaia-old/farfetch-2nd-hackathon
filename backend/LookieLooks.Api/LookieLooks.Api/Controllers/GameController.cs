using LookieLooks.Api.Interfaces;
using LookieLooks.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LookieLooks.Api.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IVoteService _voteService;
        public GameController(IGameService gameService, IVoteService voteService)
        {
            _gameService = gameService;
            _voteService = voteService;
        }

        #region testes
        [HttpPost]
        public void GetRandomGame(string userName)
        {
            _gameService.GetRandomGameAsync(userName);
        }

        [Route("CreateProducts")]
        [HttpPost]
        public void CreateProducts([FromBody]List<Product> products)
        {
            _gameService.CreateProducts(products);
        }


        #endregion
        //Funções Finais
        [HttpPost]
        public OkObjectResult getNewGameObject(string userName)
        {
            Domain.Game returnedGame = _gameService.GetRandomGameAsync(userName);
            return Ok(returnedGame.GetResponse());

        }

        [HttpPost]
        public async Task<OkObjectResult> SubmitVote(Vote vote)
        {
            string result = await _voteService.ComputeVoteAsync(vote);
            return Ok(result);
        }
    }
}
