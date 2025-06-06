using GameCatalog.Models;
using GameCatalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

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
        
        public async Task<IEnumerable<Game>> GetFilteredGamesAsync(string genre, string platform, float? minPrice, float? maxPrice)
        {
            var query = _db.Game.AsQueryable();

            if (!string.IsNullOrEmpty(genre))
                query = query.Where(g => g.Genre == genre);

            if (!string.IsNullOrEmpty(platform))
                query = query.Where(g => g.Platform == platform);

            if (minPrice.HasValue)
                if (minPrice.HasValue)
                    query = query.Where(g => g.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(g => g.Price <= maxPrice.Value);

            return await query.ToListAsync();
        }
    }
}