using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyApp.ApiTests;

public class PostsApiTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory = new();
    private readonly HttpClient _client;

    public PostsApiTests()
    {
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Fact]
    public async Task GetPost_ExistingId_ReturnsOk()
    {
        // Act
        var response = await _client.GetAsync("/posts/1");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task GetPost_ExistingId_ReturnsCorrectPost()
    {
        var post = await _client.GetFromJsonAsync<Post>("/posts/1");

        Assert.NotNull(post);
        Assert.Equal(1, post.Id);
        Assert.Equal(1, post.UserId);
        Assert.Equal("First post", post.Title);
    }

    [Fact]
    public async Task GetPosts_FilterByUserId_ReturnsOnlyThatUsersPosts()
    {
        var posts = await _client.GetFromJsonAsync<List<Post>>("/posts?userId=1");

        Assert.NotNull(posts);
        Assert.Equal(2, posts.Count);
        Assert.All(posts, p => Assert.Equal(1, p.UserId));
    }
    [Fact]
    public async Task CreatePost_ValidData_ReturnsCreatedWithNewPost()
    {
        // Arrange
        var newPost = new { UserId = 99, Title = "My new post", Body = "Hello" };

        // Act
        var response = await _client.PostAsJsonAsync("/posts", newPost);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var created = await response.Content.ReadFromJsonAsync<Post>();
        Assert.NotNull(created);
        Assert.True(created.Id > 0);
        Assert.Equal("My new post", created.Title);
        Assert.Equal(99, created.UserId);
    }
    [Fact]
    public async Task UpdatePost_ExistingId_ReturnsUpdatedPost()
    {
        // Arrange
        var update = new { UserId = 1, Title = "Updated title", Body = "Updated body" };

        // Act
        var response = await _client.PutAsJsonAsync("/posts/1", update);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var updated = await response.Content.ReadFromJsonAsync<Post>();
        Assert.NotNull(updated);
        Assert.Equal(1, updated.Id);
        Assert.Equal("Updated title", updated.Title);

        // نتأكد إن التعديل اتحفظ فعلاً
        var fetched = await _client.GetFromJsonAsync<Post>("/posts/1");
        Assert.Equal("Updated title", fetched!.Title);
    }

    [Fact]
    public async Task DeletePost_ExistingId_ReturnsNoContentAndPostIsGone()
    {
        // Act
        var deleteResponse = await _client.DeleteAsync("/posts/1");

        // Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        var getResponse = await _client.GetAsync("/posts/1");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
    [Fact]
    public async Task UpdatePost_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        var update = new { UserId = 1, Title = "Updated title", Body = "Updated body" };
        // Act
        var response = await _client.PutAsJsonAsync("/posts/999", update);
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    [Fact]
    public async Task DeletePost_NonExistingId_ReturnsNotFound()
    {
        // Act
        var response = await _client.DeleteAsync("/posts/999");
        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task CreatePost_EmptyTitle_ReturnsBadRequest(string title)
    {
        // Arrange
        var invalidPost = new { UserId = 1, Title = title, Body = "Some body" };

        // Act
        var response = await _client.PostAsJsonAsync("/posts", invalidPost);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task UpdatePost_EmptyTitle_ReturnsBadRequest(string title)
    {
        // Arrange
        var invalidUpdate = new { UserId = 1, Title = title, Body = "Some body" };
        // Act
        var response = await _client.PutAsJsonAsync("/posts/1", invalidUpdate);
        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
public record Post(int Id, int UserId, string Title, string Body);