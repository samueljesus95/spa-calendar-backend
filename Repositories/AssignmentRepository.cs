using spa_calendar_backend.Context;
using spa_calendar_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace spa_calendar_backend.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _appDbContext;
        public AssignmentRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public void AddAssignment(Assignment assignment)
        {
            if(assignment == null)
                throw new ArgumentNullException(nameof(assignment));
            
            _appDbContext.Assignments.Add(assignment);
            _appDbContext.SaveChanges();
        }

        public void DeleteAssignment(int id)
        {
            var assignment = _appDbContext.Assignments.Find(id);
            if (assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            _appDbContext.Assignments.Remove(assignment);
            _appDbContext.SaveChanges();
        }

        public List<Assignment> GetAllAssignments()
        {
            return _appDbContext.Assignments.ToList();
        }

        public Assignment GetAssignmentById(int id)
        {
            return _appDbContext.Assignments.FirstOrDefault(a => a.Id == id);
        }

        public void UpdateAssignment(Assignment assignment)
        {
            if(assignment == null)
                throw new ArgumentNullException(nameof(assignment));

            _appDbContext.Entry(assignment).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
