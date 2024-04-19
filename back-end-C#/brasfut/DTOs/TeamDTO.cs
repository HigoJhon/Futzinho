using brasfut.Models;

namespace brasfut.DTOs
{
    public class TeamDTO
    {
        public int TeamId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public List<string>? Championships { get; set; }
    }
}