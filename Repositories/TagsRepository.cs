using spa_calendar_backend.Context;
using spa_calendar_backend.Models;

namespace spa_calendar_backend.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private readonly AppDbContext _appDbContext;
        public TagsRepository(AppDbContext appDbContext) { _appDbContext = appDbContext; }
        public void AddTags(Tags tags)
        {
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Tags.Add(tags);
            _appDbContext.SaveChanges();
        }

        public void DeleteTags(int id)
        {
            var tags = _appDbContext.Tags.Find(id);
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Tags.Remove(tags);
            _appDbContext.SaveChanges();
        }

        public List<Tags> GetAllTags()
        {
            return _appDbContext.Tags.ToList();
        }

        public Tags GetTagsById(int id)
        {
            return _appDbContext.Tags.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateTags(Tags tags)
        {
            ArgumentNullException.ThrowIfNull(tags);

            _appDbContext.Update(tags);
            _appDbContext.SaveChanges();
        }
    }
}
