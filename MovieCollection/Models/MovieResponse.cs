using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required (ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required (ErrorMessage = "Enter a valid year")]
        public int Year { get; set; }
        [Required (ErrorMessage = "Please enter a Director name")]
        public string Director { get; set; }
        [Required (ErrorMessage = "Please enter a rating for the movie")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent_To { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }


        // build foreign key
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
