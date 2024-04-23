using backend.DTOs;
using backend.Models;

namespace backend.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<TeamDTO> GetAllTeams();
        TeamDTO GetTeamById(int id);
        Team AddTeam(Team team);
        Team UpdateTeam(Team team);
        void DeleteTeam(int id);
    }
}