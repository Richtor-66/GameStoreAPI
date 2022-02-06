using GameStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web_API
{
    public class GameStore
    {
        [Key]
        public Guid Guid { get; set; }

        /// <summary>
        /// �������� ����
        /// </summary>
        [Required]
        [MaxLength(50, ErrorMessage ="Name only 50 character")]
        public string Name { get; set; }
        /// <summary>
        ///  ������ �����������
        /// </summary>
        [Required]
        [MaxLength(100, ErrorMessage = "Name Studio 100 character")]
        public string Studio { get; set; }

       public List<Genre> ListGenre { get; set; }
    }
}
