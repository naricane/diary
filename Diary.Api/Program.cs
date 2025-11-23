using Diary.BusinessLogic.Services;
using Diary.Core.Dto;
using Diary.Infrastructure.Persistence.Sqlite;
using Microsoft.EntityFrameworkCore;
using Diary.Core.Repositories;
using Diary.Core.Services;
using Diary.Infrastructure.Repositories.Sqlite;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Frontend");

app.MapGet("/posts", ([FromServices]IPostService service) =>
{
    var posts = service.GetAllAsync();
    return Results.Ok(posts);
});

app.MapPost("/posts", async ([FromServices]IPostService service, [FromBody]PostCreateDto dto) =>
{
    var post = await service.CreateAsync(dto);
    return Results.Created($"/posts/{post.Id}", post);
});

app.Run();
