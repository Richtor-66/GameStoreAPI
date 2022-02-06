using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace GameStoreAPI.GameData
{
   public interface IGenreData
    {
        List<Genre> GetGenres();
        Genre GetGenre(Guid id);
        Genre AddGenre(Genre genre);
        void DeleteGenre(Genre genre);
        Genre EditGenre(Genre genre);
    }
}
