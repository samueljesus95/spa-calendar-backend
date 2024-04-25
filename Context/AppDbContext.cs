using Microsoft.EntityFrameworkCore;
using spa_calendar_backend.Models;

namespace spa_calendar_backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Tags> Tags { get; set; }
    }
}
