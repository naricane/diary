using Diary.Core.Dto;

namespace Diary.Core.Services;

public interface IPostService
{
    IAsyncEnumerable<PostResponseDto> GetAllAsync();
    Task<PostResponseDto> CreateAsync(PostCreateDto dto);
}