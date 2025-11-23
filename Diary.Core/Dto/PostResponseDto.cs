namespace Diary.Core.Dto;

public record PostResponseDto(Guid Id, string Content, DateTime CreatedAt);