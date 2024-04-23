using backend.Models;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ChampionshipController : Controller
    {
        private readonly IChampionshipRepository _championshipRepository;

        public ChampionshipController(IChampionshipRepository championshipService)
        {
            _championshipRepository = championshipService;
        }

        [HttpGet]
        public IActionResult GetAllChampionships()
        {
            return Ok(_championshipRepository.GetAllChampionships());
        }

        [HttpGet("{id}")]
        public IActionResult GetChampionshipById(int id)
        {
            return Ok(_championshipRepository.GetChampionshipById(id));
        }

        [HttpPost]
        public IActionResult AddChampionship([FromBody] Championship championship)
        {
            return Ok(_championshipRepository.AddChampionship(championship));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChampionship(int id, [FromBody] Championship championship)
        {
            if (id != championship.ChampionshipId)
            {
                return BadRequest();
            }

            var updatedChampionship = _championshipRepository.UpdateChampionship(championship);

            return Ok(updatedChampionship);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChampionship(int id)
        {
            _championshipRepository.DeleteChampionship(id);
            return Ok();
        }
    }
}