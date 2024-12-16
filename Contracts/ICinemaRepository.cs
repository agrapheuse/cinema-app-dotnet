using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface ICinemaRepository
{
    IEnumerable<Cinema> getAllCinemas(bool trackChanges);
    IEnumerable<Cinema> getCinemaById(Guid id, bool trackChanges);
}