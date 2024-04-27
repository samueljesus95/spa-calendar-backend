namespace spa_calendar_backend.Models.DTOs
{
    public class AssignmentDTO
    {
        public int Id { get; set; }

        public String Title { get; set; }

        public String? Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public ICollection<String>? Tags { get; set; }
    }
}
