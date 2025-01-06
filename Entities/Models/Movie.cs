using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Movie
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Required(ErrorMessage = "MovieShowingRaw name is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Title is 255 characters.")]
    [Column("title")]
    public string? Title { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Director is 255 characters.")]
    [Column("director")]
    public string? Director { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Category is 255 characters.")]
    [Column("category")]
    public string? Category { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the image url is 255 characters.")]
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [ForeignKey(nameof(Cinema))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    public ICollection<Showing>? Showings { get; set; }
}