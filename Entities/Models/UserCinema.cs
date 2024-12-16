using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class UserCinema // user preference for certain cinemas
{
    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    [ForeignKey(nameof(Cinema))]
    public Guid CinemaId { get; set; }
    public Cinema? Cinema { get; set; }
}