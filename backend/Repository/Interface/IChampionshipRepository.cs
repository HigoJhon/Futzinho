using backend.DTOs;
using backend.Models;

namespace backend.Repositories
{
public interface IChampionshipRepository
    {
        IEnumerable<ChampionshipDTO> GetAllChampionships();
        ChampionshipDTO GetChampionshipById(int id);
        Championship AddChampionship(Championship championship);
        Championship UpdateChampionship(Championship championship);
        void DeleteChampionship(int id);
    }
}