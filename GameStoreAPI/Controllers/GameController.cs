using GameStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;
using WebAPI.GameData;

namespace WebAPI.Controllers
{
    [ApiController]
    public class GameController : ControllerBase
    {

        protected IGameData _gamedata;

        public GameController(IGameData gameData)
        {
            _gamedata = gameData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetGames() 
        {
            return Ok(_gamedata.GetGames());
        }

        [HttpGet]
        [Route("api/[controller]/genre={genre}")]
        public IActionResult GetGamesFromGenre(string genre)
        {
            return Ok(_gamedata.GetGamesFromGenre(genre));
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetGame(Guid id)
        {
            var game = _gamedata.GetGame(id);
            if (game != null) 
            {
                return Ok(game);
            }
            return NotFound($"Game with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetGame(GameStore game)
        {
            _gamedata.AddGame(game);
            return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}/{game.Guid}", 
                game);

        }



        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteGame(Guid id)
        {
            var game = _gamedata.GetGame(id);
            if (game != null) 
            {
                _gamedata.DeleteGame(game);
                return Ok();
            }
            return NotFound($"Game with Id: {id} was not found");

        }

        [HttpPatch]
        [Route("api/[controller]/{guid}")]
        public IActionResult EditGame(Guid guid, GameStore game)
        {
            var existingGame = _gamedata.GetGame(guid);
            if (existingGame != null) 
            {
                game.Guid = existingGame.Guid;
                _gamedata.EditGame(game);
            }
            return Ok();
        }

    }
}
