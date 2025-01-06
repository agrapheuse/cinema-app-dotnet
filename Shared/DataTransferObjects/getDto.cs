namespace Shared.DataTransferObjects;

public record MovieDto(
    Guid Id,
    string Title,
    string? Director,
    string? Category,
    string? Description,
    string ImageUrl,
    CinemaDto cinema,
    IEnumerable<ShowingDto> Showings
);

public record ShowingDto(
    Guid Id,
    DateTime DateTime,
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
    Guid Uuid,
    string? Name,
    string? Country,
    string? City,
    string? Color,
    string? LogoUrl
    );

public record UserCinemaDto(
    string UserId,
    string CinemaId
);
