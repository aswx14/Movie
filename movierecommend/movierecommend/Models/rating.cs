using System.ComponentModel.DataAnnotations;

namespace movierecommend.Models
{
    public class rating
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)] 
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(1, 5, ErrorMessage = "Rating should be from 1 to 5.")]
        public int Rating { get; set; }
    }
}
