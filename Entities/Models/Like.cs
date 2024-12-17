using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Like
{
    [ForeignKey(nameof(Movie))]
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
