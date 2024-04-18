using brasfut.DTOs;
using brasfut.Models;

namespace brasfut.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<TeamDTO> GetAllTeams();
        Team GetTeamById(int id);
        Team AddTeam(Team team);
        Team UpdateTeam(Team team);
        void DeleteTeam(int id);
    }
}