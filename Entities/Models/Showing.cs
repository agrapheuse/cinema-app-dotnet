using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Showing
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [ForeignKey(nameof(Cinema))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }

    [ForeignKey(nameof(Movie))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    [Required(ErrorMessage = "Date and Time is a required field.")]
    [Column("date_time")]
    public DateTime DateTime { get; set; }

    [Required(ErrorMessage = "Info link is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Info Link is 255 characters.")]
    [Column("info_link")]
    public string? InfoLink { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Ticket Link is 255 characters.")]
    [Column("ticket_link")]
    public string? TicketLink { get; set; }
    public ICollection<Like>? Like { get; set; }
}