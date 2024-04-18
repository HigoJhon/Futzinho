using System.ComponentModel.DataAnnotations;

namespace brasfut.Models
{
    public class TeamChampionshipLink
    {
        [Key]
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public int ChampionshipId { get; set; }
        public Championship? Championship { get; set; }
    }

}