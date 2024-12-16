using Contracts;
using Entities.Models;

namespace Repository;

public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
{
    public CinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Cinema> geCinemasOfCity(string city, bool trackChanges) =>
        FindByCondition(cinema => cinema.City == city, trackChanges).ToList();

    public IEnumerable<Cinema> getAllCinemas(bool trackChanges) => FindAll(trackChanges);

    public Cinema getCinemaById(Guid id, bool trackChanges) =>
        FindByCondition(cinema => cinema.Uuid == id, trackChanges).FirstOrDefault();
}