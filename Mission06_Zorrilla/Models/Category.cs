using System.ComponentModel.DataAnnotations;

namespace Mission06_Zorrilla.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
