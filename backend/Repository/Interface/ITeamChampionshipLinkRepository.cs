using backend.DTOs;
using backend.Models;

namespace backend.Repositories
{
    public interface ITeamChampionshipLinkRepository
    {
        IEnumerable<TeamChampionshipLinkDTO> GetAllTeamChampionshipLinks();
        TeamChampionshipLinkDTO GetTeamChampionshipLinkByIds(int teamId, int championshipId);
        TeamChampionshipLink AddTeamChampionshipLink(TeamChampionshipLink link);
        void DeleteTeamChampionshipLink(int teamId, int championshipId);
    }
}