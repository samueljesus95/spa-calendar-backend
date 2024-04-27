using System.ComponentModel.DataAnnotations;

namespace spa_calendar_backend.Models
{
    public class Tag
    {
        public int Id { get; set; }
        
        [Key]
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
