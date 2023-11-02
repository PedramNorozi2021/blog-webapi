
using Microsoft.AspNetCore.Http;

namespace Blog.Core.Repositories.Posts.DTOs;
public class AddPostDto
{
    public string UserName { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public IFormFile File { get; set; }
}
