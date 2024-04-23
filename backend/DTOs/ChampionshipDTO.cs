namespace backend.DTOs
{
    public class ChampionshipDTO
    {
        public int ChampionshipId { get; set; }
        public string? Name { get; set; }
        public decimal? Prize { get; set; }
        public int? QuantityTeams { get; set; }
        public List<string>? Teams { get; set; }
    }
}