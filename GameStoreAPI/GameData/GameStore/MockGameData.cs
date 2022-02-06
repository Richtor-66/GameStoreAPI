using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace WebAPI.GameData
{
    public class MockGameData : IGameData
    {
        private List<GameStore> games = new List<GameStore>()
        {
            new GameStore()
            {
                Guid = Guid.NewGuid(),
                Name = "1",
                Studio = "aaa"
            },
            new GameStore()
            {
                Guid = Guid.NewGuid(),
                Name = "2",
                Studio = "bbb"
            },
        };
        private Context _gameContext { get; set; }
        public GameStore AddGame(GameStore game)
        {
            game.Guid = Guid.NewGuid();
            games.Add(game);
            return game;
        }

        public void DeleteGame(GameStore game)
        {
            games.Remove(game);
        }

        public GameStore EditGame(GameStore game)
        {
            var existingGame = GetGame(game.Guid);
            existingGame.Name = game.Name;
            existingGame.Studio = game.Studio;
            return existingGame;
        }

        public GameStore GetGame(Guid id)
        {
            return games.SingleOrDefault(x => x.Guid == id);
        }

        public List<GameStore> GetGames()
        {
            return games;
        }

        public IQueryable<string> GetGamesFromGenre(string genre) 
        {
            var result = from gamestore in _gameContext.Games
                         join listgenre in _gameContext.Genres on gamestore.Guid equals listgenre.GameStoreGuid
                         where listgenre.GenreName == genre
                         select new
                         {
                             gamestore.Name
                         }.ToString();
            return result;
        }
    }
}
