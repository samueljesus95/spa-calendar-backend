﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spa_calendar_backend.Models
{
    [Table("Assignment")]
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public String Title { get; set; }
        
        [StringLength(256)]
        public String? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public ICollection<Tag>? Tags { get; set; }

    }
}
