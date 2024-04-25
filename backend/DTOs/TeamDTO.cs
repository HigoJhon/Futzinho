namespace backend.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public int Attack { get; set; }
        public int Midfield { get; set; }
        public int Defense { get; set; }
        public List<string>? Championships { get; set; }
    }
}