using System.ComponentModel.DataAnnotations;

namespace Mission06_Takamura.Models
{
    public class FilmInfo
    {
        [Key] // This is a primary key, and required.
        [Required]
        public int FilmID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        
        public bool Edited { get; set; }
        public string? Lent { get; set; } // adding ? so that it's not required anymore
        [Range(0,25)] // Adding the character limit
        public string? Notes { get; set; }
    }
}
