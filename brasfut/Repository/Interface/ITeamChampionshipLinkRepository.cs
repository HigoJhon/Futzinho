using brasfut.DTOs;
using brasfut.Models;

namespace brasfut.Repositories
{
    public interface ITeamChampionshipLinkRepository
    {
        IEnumerable<TeamChampionshipLinkDTO> GetAllTeamChampionshipLinks();
        TeamChampionshipLink GetTeamChampionshipLinkByIds(int teamId, int championshipId);
        TeamChampionshipLink AddTeamChampionshipLink(TeamChampionshipLink link);
        void DeleteTeamChampionshipLink(int teamId, int championshipId);
    }
}