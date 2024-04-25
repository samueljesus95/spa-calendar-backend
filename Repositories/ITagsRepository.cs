using spa_calendar_backend.Models;

namespace spa_calendar_backend.Repositories
{
    public interface ITagsRepository
    {
        void AddTags(Tags tags);
        void DeleteTags(int id);
        List<Tags> GetAllTags();
        Tags GetTagsById(int id);
        void UpdateTags(Tags tags);
    }
}
