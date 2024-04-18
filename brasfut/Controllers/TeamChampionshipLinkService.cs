using brasfut.Models;
using Microsoft.AspNetCore.Mvc;

namespace brasfut.Repositories
{
    [ApiController]
    [Route("[controller]")]

    public class TeamChampionshipLinkController : Controller
    {
        private readonly ITeamChampionshipLinkRepository _teamChampionshipLinkRepository;

        public TeamChampionshipLinkController(ITeamChampionshipLinkRepository teamChampionshipLinkService)
        {
            _teamChampionshipLinkRepository = teamChampionshipLinkService;
        }

        [HttpGet]
        public IActionResult GetAllTeamChampionshipLinks()
        {
            var links = _teamChampionshipLinkRepository.GetAllTeamChampionshipLinks();
            return Ok(links);
        }

        [HttpGet("{teamId}/{championshipId}")]
        public IActionResult GetTeamChampionshipLink(int teamId, int championshipId)
        {
            var link = _teamChampionshipLinkRepository.GetTeamChampionshipLinkByIds(teamId, championshipId);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        [HttpPost]
        public IActionResult CreateTeamChampionshipLink(TeamChampionshipLink link)
        {
            var createdLink = _teamChampionshipLinkRepository.AddTeamChampionshipLink(link);
            return CreatedAtAction(nameof(GetTeamChampionshipLink), new { teamId = createdLink.TeamId, championshipId = createdLink.ChampionshipId }, createdLink);
        }

        [HttpDelete("{teamId}/{championshipId}")]
        public IActionResult DeleteTeamChampionshipLink(int teamId, int championshipId)
        {
            _teamChampionshipLinkRepository.DeleteTeamChampionshipLink(teamId, championshipId);
            return NotFound();
        }        
    }
}