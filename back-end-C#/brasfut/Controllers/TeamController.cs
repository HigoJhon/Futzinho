using brasfut.Models;
using brasfut.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace brasfut.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamService)
        {
            _teamRepository = teamService;
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            return Ok(_teamRepository.GetAllTeams());
        }

        [HttpGet("{id}")]
        public IActionResult GetTeamById(int id)
        {
            return Ok(_teamRepository.GetTeamById(id));
        }

        [HttpPost]
        public IActionResult AddTeam([FromBody] Team team)
        {
            return Ok(_teamRepository.AddTeam(team));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeam(int id, [FromBody] Team team)
        {
             if (id != team.TeamId)
            {
                return BadRequest();
            }

            var updatedTeam = _teamRepository.UpdateTeam(team);

            return Ok(updatedTeam);
        }   

        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(int id)
        {
            _teamRepository.DeleteTeam(id);
            return Ok();
        }             
    }
}