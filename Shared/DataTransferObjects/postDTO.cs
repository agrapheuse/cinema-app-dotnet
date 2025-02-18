namespace Shared.DataTransferObjects;

public record UserForCreationDto(string Email, string FullName);
public record LikeForCreationDto(string ShowingId, string UserId);