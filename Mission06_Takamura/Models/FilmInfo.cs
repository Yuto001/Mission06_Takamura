using System.ComponentModel.DataAnnotations;

namespace Mission06_Takamura.Models
{
    public class FilmInfo
    {
        [Key] // This is a primary key, and required.
        [Required]
        public int MovieId { get; set; }
        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(1888)]
        public int Year { get; set; }
        public string Director { get; set; }

        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string? Lent { get; set; } // adding ? so that it's not required anymore
        [Required]
        public bool CopiedToPlex { get; set; }
        [Range(0,25)] // Adding the character limit
        public string? Notes { get; set; }
    }
}
