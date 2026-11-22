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
    if (!HasValidTitle(input))
        return Results.BadRequest("Title is required");

    var post = new Post(posts.Max(p => p.Id) + 1, input.UserId, input.Title, input.Body);
    posts.Add(post);
    return Results.Created($"/posts/{post.Id}", post);
});


app.MapPut("/posts/{id:int}", (int id, NewPost input) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post is null) return Results.NotFound();
    if (!HasValidTitle(input))
        return Results.BadRequest("Title is required");
    var updatedPost = new Post(post.Id, input.UserId, input.Title, input.Body);
    posts[posts.IndexOf(post)] = updatedPost;
    return Results.Ok(updatedPost);
});

app.MapDelete("/posts/{id:int}", (int id) =>
{
    var post = posts.FirstOrDefault(p => p.Id == id);
    if (post is null) return Results.NotFound();

    posts.Remove(post);
    return Results.NoContent();
});
static bool HasValidTitle(NewPost input) => !string.IsNullOrWhiteSpace(input.Title);
app.Run();

record Post(int Id, int UserId, string Title, string Body);
record NewPost(int UserId, string Title, string Body);
public partial class Program { }