using System.ComponentModel.DataAnnotations;

namespace Nazory.Data;

public class Nazor
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set;}
    public string Description { get; set;}
}
