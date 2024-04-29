using spa_calendar_backend.Models;
using spa_calendar_backend.Models.DTOs;

namespace spa_calendar_backend.Services.Interfaces
{
    public interface IAssignmentService
    {
        void AddAssignment(AssignmentDTO assignmentDTO);
        void DeleteAssignment(int id);
        List<Assignment> GetAllAssignments();
        Assignment GetAssignmentById(int id);
        void UpdateAssignment(Assignment assignment);
    }
}
