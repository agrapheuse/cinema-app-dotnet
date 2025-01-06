using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Like
{
    [ForeignKey(nameof(Showing))]
    public Guid ShowingId { get; set; }
    public Showing? Showing { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
