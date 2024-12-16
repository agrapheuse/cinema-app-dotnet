using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Cinema
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Required(ErrorMessage = "Cinema name is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the name is 255 characters.")]
    [Column("name")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Country is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Country is 255 characters.")]
    [Column("country")]
    public string? Country { get; set; }

    [Required(ErrorMessage = "City is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the City is 255 characters.")]
    [Column("city")]
    public string? City { get; set; }
}