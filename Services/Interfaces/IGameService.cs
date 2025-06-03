using GameCatalog.Models;

namespace GameCatalog.Services.Interfaces
{
    public interface IGameService
    {
        Task AddGame(Game gra);
        Task DeleteGame(int id);
        Task EditGame(Game gra);
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(int id);
        Task UpdateGame(Game game);
    }
}