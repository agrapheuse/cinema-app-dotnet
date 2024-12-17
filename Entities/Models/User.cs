using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class User
{

    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [Required(ErrorMessage = "Email is a required field.")]
    [Column("email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Full Name is a required field.")]
    [Column("fullName")]
    public string? FullName { get; set; }

    public ICollection<Like>? Like { get; set; }

    public ICollection<UserCinema>? UserCinemas { get; set; }
}
