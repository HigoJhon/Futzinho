using backend.Context;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly BrasContext _context;

        public TeamRepository(BrasContext context)
        {
            _context = context;
        }

        public IEnumerable<TeamDTO> GetAllTeams()
        {
            var teams = _context.Teams.Include(t => t.TeamChampionshipLinks)
                .Select(t => new TeamDTO
                {
                    TeamId = t.TeamId,
                    Name = t.Name,
                    City = t.City,
                    Attack = t.Attack,
                    Midfield = t.Midfield,
                    Defense = t.Defense,
                    Championships = t.TeamChampionshipLinks!.Select(tcl => tcl.Championship!.Name!).ToList()
                }).ToList();
            return teams!;
        }

        public TeamDTO GetTeamById(int id)
        {
            var team = _context.Teams
            .Include(t => t.TeamChampionshipLinks)!
            .ThenInclude(tcl => tcl.Championship)
            .FirstOrDefault(t => t.TeamId == id);

            if (team == null)
            {
                return null!;
            }

            var teamDto = new TeamDTO
            {
                TeamId = team.TeamId,
                Name = team.Name,
                City = team.City,
                Attack = team.Attack,
                Midfield = team.Midfield,
                Defense = team.Defense,
                Championships = team.TeamChampionshipLinks!.Select(tcl => tcl.Championship!.Name!).ToList()
            };

            return teamDto;
        }

        public Team AddTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return team;
        }

        public Team UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
            return team;
        }

        public void DeleteTeam(int id)
        {
            var team = _context.Teams.Find(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
                _context.SaveChanges();
            }
        }
    }
    
}