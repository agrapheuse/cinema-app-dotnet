using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shared.DataTransferObjects;

namespace Service;

internal sealed class LikeService : ILikeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public LikeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MovieDto> GetLikesOfUser(Guid userId, bool trackChanges)
    {
        try
        {
            var movies = _repository.Like.GetLikeOfUser(userId, trackChanges);
            var movieDtos = movies.Select(m => new MovieDto(
                m.Uuid,
                m.Title,
                m.Director ?? string.Empty,
                m.Category ?? string.Empty,
                m.Description ?? string.Empty,
                m.Cinema,
                m.Country,
                m.City,
                m.DateTime,
                m.ImageUrl,
                m.InfoLink,
                m.TicketLink ?? string.Empty
            )).ToList();

            return movieDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetLikesOfUser)} service method {ex}");
            throw;
        }


    }

    public bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges)
    {
        try
        {
            var isLiked = _repository.Like.IsMovieLikedByUser(userId, movieId, trackChanges);
            return isLiked;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(IsMovieLikedByUser)} service method {ex}");
            throw;
        }
    }
}
