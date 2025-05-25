using System.Data;
using Microsoft.EntityFrameworkCore;
namespace GameCatalog.Models
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options) { }
        public DbSet<Game> Game { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "The Witcher 3: Wild Hunt", Genre = "RPG", Platform = "PC", Release_Date = new DateTime(2015, 5, 19) },
                new Game { Id = 2, Name = "Cyberpunk 2077", Genre = "Action RPG", Platform = "PC", Release_Date = new DateTime(2020, 12, 10) },
                new Game { Id = 3, Name = "Dying Light", Genre = "Survival Horror", Platform = "PC", Release_Date = new DateTime(2015, 1, 27) }
            );
        }
    }
}
