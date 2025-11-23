using Diary.Core.Entities;
using Diary.Core.Repositories;
using Diary.Infrastructure.Persistence.Sqlite;

namespace Diary.Infrastructure.Repositories.Sqlite;

public class PostRepository(AppDbContext db) : IPostRepository
{
    public IAsyncEnumerable<Post> GetAllAsync()
    {
        return db.Posts.AsAsyncEnumerable();
    }

    public async Task<Post> CreateAsync(Post post)
    {
        db.Posts.Add(post);
        await db.SaveChangesAsync();
        return post;
    }
}