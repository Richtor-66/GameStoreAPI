using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace GameStoreAPI.GameData
{
    public class SqlGenreData : IGenreData
    {
        private Context _genreContext { get; set; }

        public SqlGenreData(Context context) 
        {
            _genreContext = context;
        }
        public Genre AddGenre(Genre genre)
        {
            genre.Guid = Guid.NewGuid();
            _genreContext.Genres.Add(genre);
            _genreContext.SaveChanges();
            return genre;
        }

        public void DeleteGenre(Genre genre)
        {
            _genreContext.Genres.Remove(genre);
            _genreContext.SaveChanges();
        }

        public Genre EditGenre(Genre genre)
        {
            var existinggame = _genreContext.Genres.Find(genre.Guid);
            if (existinggame != null)
            {
                existinggame.GenreName = genre.GenreName;
                existinggame.GameStoreGuid = genre.GameStoreGuid;
                _genreContext.Update(existinggame);
                _genreContext.SaveChanges();
            }
            return genre;
        }

        public Genre GetGenre(Guid id)
        {
            var genre = _genreContext.Genres.Find(id);
            return genre;
        }

        public List<Genre> GetGenres()
        {
            return _genreContext.Genres.ToList();
        }
    }
}
