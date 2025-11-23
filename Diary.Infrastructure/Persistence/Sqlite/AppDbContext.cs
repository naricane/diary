using Microsoft.EntityFrameworkCore;
using Diary.Core.Entities;

namespace Diary.Infrastructure.Persistence.Sqlite;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Post> Posts { get; set; }
}

