using Microsoft.AspNet.Identity;
using ProSwap.Data;
using ProSwap.Models.Game;
using ProSwap.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProSwap.API.Controllers
{
    [Authorize]
    public class GameController : ApiController
    {
        Game[] game = new Game[]
        {
            new Game { GameId= 1, Name = "World of Warcraft EU", CurrencyName = "gold"},
            new Game { GameId= 2, Name = "WoW Classic", CurrencyName = "gold"},
            new Game { GameId= 3, Name = "OSRS", CurrencyName = "gold"},
            new Game { GameId= 4, Name = "RuneScape", CurrencyName = "gold"},
            new Game { GameId= 5, Name = "FFXIV", CurrencyName = "gil"},
            new Game { GameId= 6, Name = "EverQuest", CurrencyName = "platinum"},
            new Game { GameId= 7, Name = "MapleStory 2", CurrencyName = "mesos"},
            new Game { GameId= 8, Name = "World of Warcraft US", CurrencyName = "gold"}

        };
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(userId);
            return gameService;
        }

        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }

        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            GameService gameService = CreateGameService();
            var game = gameService.GetGameById(id);
            return Ok(game);
        }

        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.UpdateGame(game))
                return InternalServerError();

            return Ok();
        }
    }
}
