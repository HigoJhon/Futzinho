using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace brasfut.Models
{
    public class TeamChampionshipLink
    {
        [Key, Column(Order = 1)]
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        [Key, Column(Order = 2)]
        public int ChampionshipId { get; set; }
        public Championship? Championship { get; set; }
    }
}