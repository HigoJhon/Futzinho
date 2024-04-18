using brasfut.DTOs;
using brasfut.Models;

namespace brasfut.Repositories
{
public interface IChampionshipRepository
    {
        IEnumerable<ChampionshipDTO> GetAllChampionships();
        Championship GetChampionshipById(int id);
        Championship AddChampionship(Championship championship);
        Championship UpdateChampionship(Championship championship);
        void DeleteChampionship(int id);
    }
}