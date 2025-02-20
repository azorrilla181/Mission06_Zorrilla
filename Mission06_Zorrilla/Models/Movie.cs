using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Zorrilla.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Nice try but movies weren't invented until later")]
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "Please select if the movie is copied to Plex")]
        public bool CopiedToPlex { get; set; }
        
        [MaxLength(25)]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


    }
}


