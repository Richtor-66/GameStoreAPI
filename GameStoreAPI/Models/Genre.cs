using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_API;

namespace GameStoreAPI.Models
{
    public class Genre
    {
        [Key]
        public Guid Guid { get; set; }
        /// <summary>
        /// Название жанра
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage = "GenreName only 50 character")]
        public string GenreName { get; set; }
        /// <summary>
        /// Guid игры
        /// </summary>
        [Required]
        public Guid GameStoreGuid { get; set; }
        /// <summary>
        /// Ссылка на игру
        /// </summary>
        public GameStore gameStore { get; set; }
    }
}
