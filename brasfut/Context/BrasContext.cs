using brasfut.Models;
using Microsoft.EntityFrameworkCore;

namespace brasfut.Context
{
    public class BrasContext : DbContext, IBrasContext
    {
        public BrasContext(DbContextOptions<BrasContext> options) : base(options)
        {
        }

        public DbSet<Championship> Championships { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamChampionshipLink> TeamChampionshipLinks { get; set; }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Championship>()
                .Property(t => t.Prize)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TeamChampionshipLink>()
                .HasKey(tcl => new { tcl.TeamId, tcl.ChampionshipId });

            modelBuilder.Entity<TeamChampionshipLink>()
                .HasOne(tcl => tcl.Team)
                .WithMany(t => t.TeamChampionshipLinks)
                .HasForeignKey(tcl => tcl.TeamId);

            modelBuilder.Entity<TeamChampionshipLink>()
                .HasOne(tcl => tcl.Championship)
                .WithMany(c => c.TeamChampionshipLinks)
                .HasForeignKey(tcl => tcl.ChampionshipId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=brasfut;User=Sa;Password=SqlServer123!;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}