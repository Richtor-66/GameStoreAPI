using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace WebAPI.GameData
{
   public interface IGameData
    {
        List<GameStore> GetGames();
        IQueryable<string> GetGamesFromGenre(string genre);
        GameStore GetGame(Guid id);
        GameStore AddGame(GameStore game);
        void DeleteGame(GameStore game);
        GameStore EditGame(GameStore game);
    }
}
