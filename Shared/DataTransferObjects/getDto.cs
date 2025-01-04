namespace Shared.DataTransferObjects;

public record MovieDto(
    Guid Id,
    string Title,
    string? Director,
    string? Category,
    string? Description,
    string ImageUrl,
    IEnumerable<ShowingDto> Showings
);

public record ShowingDto(
    Guid Id,
    DateTime DateTime,
    string InfoLink,
    string? TicketLink,
    CinemaDto Cinema
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
    Guid Uuid,
    string? Name,
    string? Country,
    string? City
    );

public record UserCinemaDto(
    string UserId,
    string CinemaId
);
