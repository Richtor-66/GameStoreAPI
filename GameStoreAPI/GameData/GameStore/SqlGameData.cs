using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;
using WebAPI.GameData;

namespace GameStoreAPI.GameData
{
    public class SqlGameData : IGameData
    {
        private Context _gameContext { get; set; }
        public SqlGameData(Context gameContext) 
        {
            _gameContext = gameContext;
        }

        public GameStore AddGame(GameStore game)
        {
            game.Guid = Guid.NewGuid();
            _gameContext.Games.Add(game);
            _gameContext.SaveChanges();
            return game;
        }

        public void DeleteGame(GameStore game)
        {
            _gameContext.Games.Remove(game);
            _gameContext.SaveChanges();
        }

        public GameStore EditGame(GameStore game)
        {
            var existinggame = _gameContext.Games.Find(game.Guid);
            if (existinggame != null) 
            {

                    existinggame.Name = game.Name;
                    existinggame.Studio = game.Studio;
                    _gameContext.Update(existinggame);
                    _gameContext.SaveChanges();
            }
            return game;
        }

        public GameStore GetGame(Guid guid)
        {
            var game = _gameContext.Games.Find(guid);
            return game;
        }

        public List<GameStore> GetGames()
        {
            return _gameContext.Games.ToList();
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

           // return _gameContext.Games.Where(x => x.Genre == genre).ToList();
            
        }
    }
}
