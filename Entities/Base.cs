using System.ComponentModel.DataAnnotations;

namespace ScorerApp;

public class Base
{
    [Key]
    public string? Id { get; set; }
    public DateTime CreateTime { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;

}
