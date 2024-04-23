using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace backend.Models;

public class Team
{
    [Key]
    public int TeamId { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }
    public ICollection<TeamChampionshipLink>? TeamChampionshipLinks { get; set; }
}