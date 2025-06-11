using GameCatalog.Models;
using GameCatalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameCatalog.Services
{
    public class GameService : IGameService
    {
        private readonly GameDbContext _db;

        public GameService(GameDbContext db)
        {
            _db = db;
        }

        public async Task<List<Game>> GetAllGames()
        {
            return await _db.Game.ToListAsync();
        }

        public async Task<List<Game>> SearchGamesByNameAsync(string searchTerm)
        {
            return await _db.Game
                .Where(g => g.Name.Contains(searchTerm))
                .ToListAsync();
        }


        public async Task AddGame(Game game)
        {
            _db.Game.Add(game);
            await _db.SaveChangesAsync();
        }

        public async Task EditGame(Game game)
        {
            _db.Game.Update(game);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            var game = await _db.Game.FindAsync(id);
            if (game != null)
            {
                _db.Game.Remove(game);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _db.Game.FindAsync(id);
        }

        public async Task UpdateGame(Game game)
        {
            _db.Game.Update(game);
            await _db.SaveChangesAsync();
        }
        
        public async Task<List<Game>> GetFilteredGamesAsync(string genre, string platform, float? minPrice, float? maxPrice)
        {
            var query = _db.Game.AsQueryable();

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(g => g.Genre == genre);

            if (!string.IsNullOrEmpty(platform))
                query = query.Where(g => g.Platform == platform);

            if (minPrice.HasValue)
                query = query.Where(g => g.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(g => g.Price <= maxPrice.Value);

            return await query.ToListAsync();
        }
        public async Task<List<Game>> SortGamesAsync(string sortBy, bool ascending = true)
        {
            IQueryable<Game> query = _db.Game.AsQueryable();

            switch (sortBy?.ToLower())
            {
                case "name":
                    query = query.OrderBy(g => g.Name);
                    break;
                case "releasedate":
                    query = query.OrderBy(g => g.Release_Date);
                    break;
                case "lowestprice":
                    query = ascending ? query.OrderBy(g => g.Price) : query.OrderByDescending(g => g.Price);
                    break;
                case "highestprice":
                    query = ascending ? query.OrderByDescending(g => g.Price) : query.OrderBy(g => g.Price);
                    break;
                default:
                    query = query.OrderBy(g => g.Name);
                    break;
            }

            return await query.ToListAsync();
        }

    }
}