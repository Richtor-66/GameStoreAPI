using GameStoreAPI.GameData;
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
    public class GenreController : GameController
    {

        private IGenreData _genredata;

        public GenreController(IGenreData genredata, IGameData gameData)
            :base(gameData)
        {
            _genredata = genredata;
        }

        [HttpGet]
        [Route("api1/[controller]")]
        public IActionResult GetGenres() 
        {
            return Ok(_genredata.GetGenres());
        }

        [HttpGet]
        [Route("api1/[controller]/{id}")]
        public IActionResult GetGenre(Guid id)
        {
            var game = _genredata.GetGenre(id);
            if (game != null) 
            {
                return Ok(game);
            }
            return NotFound($"Game with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api1/[controller]")]
        public IActionResult GetGenre(Genre genre)
        {
                var existingGame = _gamedata.GetGame(genre.GameStoreGuid);
            if ( existingGame != null)
            {
                _genredata.AddGenre(genre);
                return Ok();
            }
            
            return NotFound($"Game {genre.GameStoreGuid} not found");
        }

        [HttpDelete]
        [Route("api1/[controller]/{id}")]
        public IActionResult DeleteGenre(Guid id)
        {
            var game = _genredata.GetGenre(id);
            if (game != null) 
            {
                _genredata.DeleteGenre(game);
                return Ok();
            }
            return NotFound($"Game with Id: {id} was not found");

        }

        [HttpPatch]
        [Route("api1/[controller]/{guid}")]
        public IActionResult EditGenre(Guid guid, Genre genre)
        {
            var existingGenre = _genredata.GetGenre(guid);
            if (existingGenre != null) 
            {
                genre.Guid = existingGenre.Guid;
                _genredata.EditGenre(genre);
            }
            return Ok();
        }

    }
}
