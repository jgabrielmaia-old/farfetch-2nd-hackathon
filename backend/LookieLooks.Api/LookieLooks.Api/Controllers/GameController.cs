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
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

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

    }
}
