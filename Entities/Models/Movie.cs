using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public class Movie
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Required(ErrorMessage = "Movie name is a required field.")]
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

    [Required(ErrorMessage = "Cinema is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Cinema is 255 characters.")]
    [Column("cinema")]
    public string? Cinema { get; set; }

    [Required(ErrorMessage = "Country is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Country is 255 characters.")]
    [Column("country")]
    public string? Country { get; set; }

    [Required(ErrorMessage = "City is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the City is 255 characters.")]
    [Column("city")]
    public string? City { get; set; }

    [Required(ErrorMessage = "Date and Time is a required field.")]
    [Column("date_time")]
    public DateTime DateTime { get; set; }

    [Required(ErrorMessage = "Image URL is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Image URL is 255 characters.")]
    [Column("image_url")]
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Info link is a required field.")]
    [MaxLength(255, ErrorMessage = "Maximum length for the Info Link is 255 characters.")]
    [Column("info_link")]
    public string? InfoLink { get; set; }

    [MaxLength(255, ErrorMessage = "Maximum length for the Ticket Link is 255 characters.")]
    [Column("ticket_link")]
    public string? TicketLink { get; set; }
}
