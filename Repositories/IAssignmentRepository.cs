using spa_calendar_backend.Models;

namespace spa_calendar_backend.Repositories
{
    public interface IAssignmentRepository
    {
        void AddAssignment(Assignment assignment);
        void DeleteAssignment(int id);
        List<Assignment> GetAllAssignments();
        Assignment GetAssignmentById(int id);
        void UpdateAssignment(Assignment assignment);
    }
}
