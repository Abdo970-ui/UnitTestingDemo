var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var posts = new List<Post>
{
    new(1, 1, "First post", "Body of the first post"),
    new(2, 1, "Second post", "Body of the second post"),
    new(3, 2, "Third post", "Body of the third post"),
};

app.MapGet("/posts", (int? userId) =>
    posts.Where(p => userId is null || p.UserId == userId));

app.MapGet("/posts/{id:int}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    return post is null ? Results.NotFound() : Results.Ok(post);
});

app.MapPost("/posts", (NewPost input) =>
{
    var post = new Post(posts.Max(p => p.Id) + 1, input.UserId, input.Title, input.Body);
    posts.Add(post);
    return Results.Created($"/posts/{post.Id}", post);
});

app.Run();

record Post(int Id, int UserId, string Title, string Body);
record NewPost(int UserId, string Title, string Body);
public partial class Program { }