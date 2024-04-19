using System.ComponentModel.DataAnnotations;

namespace brasfut.Models
{
    public class Championship
    {
        [Key]
        public int ChampionshipId { get; set; }
        public string? Name { get; set; }
        public decimal? Prize { get; set; }
        public int? QunaityTeams { get; set; }
        public ICollection<TeamChampionshipLink>? TeamChampionshipLinks { get; set; }
    }
}