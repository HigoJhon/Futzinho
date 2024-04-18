using brasfut.Context;
using brasfut.DTOs;
using brasfut.Models;

namespace brasfut.Repositories
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

        public TeamChampionshipLink GetTeamChampionshipLinkByIds(int teamId, int championshipId)
        {
            return _context.TeamChampionshipLinks.FirstOrDefault(tcl => tcl.TeamId == teamId && tcl.ChampionshipId == championshipId)!;
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