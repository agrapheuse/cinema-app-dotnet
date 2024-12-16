using Entities.Models;

namespace Contracts;

public interface ICinemaRepository
{
    IEnumerable<Cinema> geCinemasOfCity(string city, bool trackChanges);
    IEnumerable<Cinema> getAllCinemas(bool trackChanges);
    Cinema getCinemaById(Guid id, bool trackChanges);
}