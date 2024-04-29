using spa_calendar_backend.Context;
using spa_calendar_backend.Models;
using spa_calendar_backend.Repositories.Interfaces;

namespace spa_calendar_backend.Repositories
{
    public class TagsRepository(AppDbContext appDbContext) : ITagsRepository
    {
        private readonly AppDbContext _appDbContext = appDbContext;

        public void AddTags(Tag tags)
        {
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Tags.Add(tags);
            _appDbContext.SaveChanges();
        }

        public void DeleteTags(string title)
        {
            var tags = _appDbContext.Tags.Find(title);
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Tags.Remove(tags);
            _appDbContext.SaveChanges();
        }

        public List<Tag> GetAllTags()
        {
            return _appDbContext.Tags.ToList();
        }

        public Tag GetTagsByTitle(string title)
        {
            return _appDbContext.Tags.FirstOrDefault(x => x.Title.Equals(title));
        }

        public void UpdateTags(Tag tags)
        {
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Update(tags);
            _appDbContext.SaveChanges();
        }
    }
}
