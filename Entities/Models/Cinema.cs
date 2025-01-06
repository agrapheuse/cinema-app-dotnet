using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Required(ErrorMessage = "Color is a required field.")]
    [MaxLength(10, ErrorMessage = "Maximum length for the Color is 10 characters.")]
    [Column("color")]
    public string? Color { get; set; }

    [Required(ErrorMessage = "LogoUrl is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the LogoUrl is 255 characters.")]
    [Column("logoUrl")]
    public string? LogoUrl { get; set; }
}