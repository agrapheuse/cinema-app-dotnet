using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICinemaService
{
    IEnumerable<CinemaDto> GetCinemaByCity(string city, bool trackChanges);
}