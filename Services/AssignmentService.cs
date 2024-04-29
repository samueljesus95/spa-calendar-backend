using spa_calendar_backend.Models;
using spa_calendar_backend.Models.DTOs;
using spa_calendar_backend.Repositories.Interfaces;
using spa_calendar_backend.Services.Interfaces;

namespace spa_calendar_backend.Services
{
    public class AssignmentService(IAssignmentRepository assignmentRepository) : IAssignmentService
    {
        public void AddAssignment(AssignmentDTO assignmentDTO)
        {
            var tags = new List<Tag>();
            foreach (string tag in assignmentDTO.Tags) { tags.Add(new Tag { Title = tag }); }

            var assignment = new Assignment
            {
                Title = assignmentDTO.Title,
                Description = assignmentDTO.Description,
                StartDate = assignmentDTO.Start,
                EndDate = assignmentDTO.End,
                Tags = tags
            };

            assignmentRepository.AddAssignment(assignment);
        }

        public void DeleteAssignment(int id)
        {
            assignmentRepository.DeleteAssignment(id);
        }

        public List<Assignment> GetAllAssignments()
        {
            return assignmentRepository.GetAllAssignments();
        }

        public Assignment GetAssignmentById(int id)
        {
            return assignmentRepository.GetAssignmentById(id);
        }

        public void UpdateAssignment(Assignment assignment)
        {
            assignmentRepository.UpdateAssignment(assignment);
        }
    }
}
