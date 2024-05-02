using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public interface IBrasContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamChampionshipLink> TeamChampionshipLinks { get; set; }

        int SaveChanges();
    }
}