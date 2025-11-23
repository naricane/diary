using Diary.Core.Dto;
using Diary.Core.Entities;
using Diary.Core.Repositories;
using Diary.Core.Services;

namespace Diary.BusinessLogic.Services;

public class PostService(IPostRepository repo) : IPostService
{
    public async IAsyncEnumerable<PostResponseDto> GetAllAsync() {
        await foreach (var p in repo.GetAllAsync())
        {
            yield return new PostResponseDto(
                p.Id,
                p.Content,
                p.CreatedAt
            );
        }
    }

    public async Task<PostResponseDto> CreateAsync(PostCreateDto dto)
    {
        var post = new Post
        {
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow
        };

        await repo.CreateAsync(post);

        return new PostResponseDto(post.Id, post.Content, post.CreatedAt);
    }
}