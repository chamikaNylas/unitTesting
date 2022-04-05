using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entities
{
    /// <summary>
    /// The Movie model class
    /// </summary>
    public class Movie : IEntity
    {
        /// <summary>
        /// The Primary Key of the Movie record
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The Title of the Movie
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }

        /// <summary>
        /// The Genre of the Movie
        /// </summary>
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        /// <summary>
        /// The Release Date of the Movie
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Who Posted the Movie
        /// </summary>
        [Required]
        public String PostedBy { get; set; }
    }
}
