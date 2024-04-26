using System.ComponentModel.DataAnnotations;

namespace spa_calendar_backend.Models
{
    public class Tags
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Assignment>? Assignment { get; set; }
    }
}
