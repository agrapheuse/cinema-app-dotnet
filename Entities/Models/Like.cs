using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class Like
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }

    [ForeignKey(nameof(Movie))] 
    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }
}
