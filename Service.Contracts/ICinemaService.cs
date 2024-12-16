using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICinemaService
{
    CinemaDto GetCinemaByCity(string city, bool trackChanges);
}