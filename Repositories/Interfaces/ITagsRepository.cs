using spa_calendar_backend.Models;

namespace spa_calendar_backend.Repositories.Interfaces
{
    public interface ITagsRepository
    {
        void AddTags(Tag tags);
        void DeleteTags(string title);
        List<Tag> GetAllTags();
        Tag GetTagsByTitle(string title);
        void UpdateTags(Tag tags);
    }
}
