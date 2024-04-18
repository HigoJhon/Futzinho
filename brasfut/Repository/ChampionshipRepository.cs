using brasfut.Context;
using brasfut.DTOs;
using brasfut.Models;
using Microsoft.EntityFrameworkCore;

namespace brasfut.Repositories
{
    public class ChampionshipRepository : IChampionshipRepository
    {
        private readonly BrasContext _context;

        public ChampionshipRepository(BrasContext context)
        {
            _context = context;
        }

         public IEnumerable<ChampionshipDTO> GetAllChampionships()
        {
            return _context.Championships.Include(c => c.TeamChampionshipLinks)
                .Select(c => new ChampionshipDTO
                {
                    ChampionshipId = c.ChampionshipId,
                    Name = c.Name,
                    Prize = c.Prize,
                    QuantityTeams = c.QunaityTeams,
                    Teams = c.TeamChampionshipLinks!.Select(tcl => tcl.Team!.Name!).ToList()
            
            }).ToList();
        }

        public ChampionshipDTO GetChampionshipById(int id)
        {
            var championship = _context.Championships
            .Include(c => c.TeamChampionshipLinks)!
            .ThenInclude(tcl => tcl.Team)
            .FirstOrDefault(c => c.ChampionshipId == id);

            var championshipDto = new ChampionshipDTO
            {
                ChampionshipId = championship!.ChampionshipId,
                Name = championship.Name,
                Prize = championship.Prize,
                QuantityTeams = championship.QunaityTeams,
                Teams = championship.TeamChampionshipLinks!.Select(tcl => tcl.Team!.Name!).ToList()
            };

            return championshipDto;
        }

        public Championship AddChampionship(Championship championship)
        {
            _context.Championships.Add(championship);
            _context.SaveChanges();
            return championship;
        }

        public Championship UpdateChampionship(Championship championship)
        {
            _context.Championships.Update(championship);
            _context.SaveChanges();
            return championship;
        }

        public void DeleteChampionship(int id)
        {
            var championship = _context.Championships.Find(id);
            if (championship != null)
            {
                _context.Championships.Remove(championship);
                _context.SaveChanges();
            }
        }
    }
}