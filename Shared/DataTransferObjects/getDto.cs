namespace Shared.DataTransferObjects;

public record MovieDto(
    Guid Id,
    string Title,
    string? Director,
    string? Category,
    string? Description,
    Guid CinemaId,
    DateTime DateTime,
    string ImageUrl,
    string InfoLink,
    string? TicketLink
    );

public record LikeDto(
    Guid Uuid,
    Guid MovieId,
    Guid UserId
    );

public record UserDto(
    Guid Uuid,
    string Email,
    string? FullName
    );

public record CinemaDto(
    string? Name,
    string? Country,
    string? City
    );

public record UserCinemaDto(
    string UserId,
    string CinemaId
);
