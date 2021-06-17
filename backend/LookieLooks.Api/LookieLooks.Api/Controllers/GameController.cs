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
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IVoteService _voteService;
        private readonly IUserService _userService;
        public GameController(IGameService gameService, IVoteService voteService, IUserService userService)
        {
            _gameService = gameService;
            _voteService = voteService;
            _userService = userService;
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

        [Route("CreateTypeAttributes")]
        [HttpPost]
        public void CreateTypeAttribute([FromBody] List<TypeAttribute> products)
        {
            _gameService.CreateTypeAttributes(products);
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

        [HttpGet]
        public async Task<OkObjectResult> getLeaderboard()
        {
            var result = _userService.getTopUsers();
            return Ok(result);
        }
    }
}
