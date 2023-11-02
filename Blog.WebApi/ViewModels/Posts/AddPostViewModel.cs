using System.ComponentModel.DataAnnotations;

namespace Blog.WebApi.ViewModels.Posts;
public class AddPostViewModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
    [Required]
    [MaxLength(80)]
    public string Slug { get; set; }
    [Required]
    public IFormFile File { get; set; }
}
