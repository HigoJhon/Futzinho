using backend.Context;
using backend.DTOs;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class TeamChampionshipLinkRepository : ITeamChampionshipLinkRepository
    {
        private readonly BrasContext _context;

        public TeamChampionshipLinkRepository(BrasContext context)
        {
            _context = context;
        }

        public IEnumerable<TeamChampionshipLinkDTO> GetAllTeamChampionshipLinks()
        {
            return _context.TeamChampionshipLinks.Select(tcl => new TeamChampionshipLinkDTO
            {
                TeamName = tcl.Team!.Name,
                ChampionshipName = tcl.Championship!.Name
            }).ToList();
        }

        public TeamChampionshipLinkDTO GetTeamChampionshipLinkByIds(int teamId, int championshipId)
        {
            // return _context.TeamChampionshipLinks.FirstOrDefault(tcl => tcl.TeamId == teamId && tcl.ChampionshipId == championshipId)!;
            var link = _context.TeamChampionshipLinks
            .Include(tcl => tcl.Team)
            .Include(tcl => tcl.Championship)
            .FirstOrDefault(tcl => tcl.TeamId == teamId && tcl.ChampionshipId == championshipId);

            var linkDto = new TeamChampionshipLinkDTO
            {
                TeamName = link!.Team!.Name,
                ChampionshipName = link.Championship!.Name
            };

            return linkDto;
        }

        public TeamChampionshipLink AddTeamChampionshipLink(TeamChampionshipLink link)
        {
            _context.TeamChampionshipLinks.Add(link);
            _context.SaveChanges();
            return link;
        }

        public void DeleteTeamChampionshipLink(int teamId, int championshipId)
        {
            var link = _context.TeamChampionshipLinks.FirstOrDefault(tcl => tcl.TeamId == teamId && tcl.ChampionshipId == championshipId);
            if (link != null)
            {
                _context.TeamChampionshipLinks.Remove(link);
                _context.SaveChanges();
            }
        }
    }
}