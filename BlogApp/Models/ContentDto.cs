using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class ContentDto
    {
        [Required]
        public string Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Summary { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
