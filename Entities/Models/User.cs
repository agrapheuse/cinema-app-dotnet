using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models;

public class User
{
    [Key]
    [Column("uuid")]
    public Guid Uuid { get; set; }
}
