using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class CinemaService : ICinemaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CinemaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CinemaDto> GetCinemaByCity(string city, bool trackChanges)
    {
        try
        {
            var cinemas = _repository.Cinema.geCinemasOfCity(city, trackChanges);

            var cinemaDtos = cinemas.Select(c => new CinemaDto(
                c.Name,
                c.Country,
                c.City
            )).ToList();

            return cinemaDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in the {nameof(GetCinemaByCity)} service method: {ex}");
            throw;
        }
    }

    public IEnumerable<CinemaDto> GetUserPreference(Guid userId, bool trackChanges)
    {
        try
        {
            var cinemas = _repository.UserCinema.GetUserPreference(userId, trackChanges);

            var cinemaDtos = cinemas.Select(c => new CinemaDto(
                c.Name,
                c.Country,
                c.City
            )).ToList();

            return cinemaDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in the {nameof(GetUserPreference)} service method: {ex}");
            throw;
        }
    }

    public UserCinemaDto CreateUserPreference(UserCinemaDto userCinema)
    {
        var userCinemaEntity = _mapper.Map<UserCinema>(userCinema);

        _repository.UserCinema.CreateUserPreference(userCinemaEntity);
        _repository.Save();

        return userCinema;
    }
}