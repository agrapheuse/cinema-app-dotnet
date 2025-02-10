namespace Shared.DataTransferObjects;

public record UserForCreationDto(string Email, string FullName);
public record LikeForCreation(string ShowingId, string UserId);