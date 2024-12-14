namespace Shared.DataTransferObjects;

public record MovieDto(
    Guid Id, 
    string Title, 
    string? Director, 
    string? Category, 
    string? Description, 
    string Cinema, 
    string Country, 
    string City, 
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