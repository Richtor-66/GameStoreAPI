using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_API;

namespace GameStoreAPI.GameData
{
    public class MoskGenreData : IGenreData
    {
        private List<Genre> genres = new List<Genre>()
        {
            new Genre()
            {
                Guid = Guid.NewGuid(),
                GenreName = "1",
            },
            new Genre()
            {
                Guid = Guid.NewGuid(),
                GenreName = "1",
            },
        };
        public Genre AddGenre(Genre genre)
        {
            genre.Guid = Guid.NewGuid();
            genres.Add(genre);
            return genre;
        }

        public Genre AddGame(Genre genre) 
        {
            return genre;
        }

        public void DeleteGenre(Genre genre)
        {
            genres.Remove(genre);
        }

        public Genre EditGenre(Genre genre)
        {
            var existingGenre = GetGenre(genre.Guid);
            existingGenre.GenreName = genre.GenreName;
            existingGenre.GameStoreGuid = genre.GameStoreGuid;
            return existingGenre;
        }

        public Genre GetGenre(Guid id)
        {
            return genres.SingleOrDefault(x => x.Guid == id);
        }

        public List<Genre> GetGenres()
        {
            return genres;
        }
    }
}
