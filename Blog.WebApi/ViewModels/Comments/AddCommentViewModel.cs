using System.ComponentModel.DataAnnotations;

namespace Blog.WebApi.ViewModels.Comments;
public class AddCommentViewModel
{
    public long PostId { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }
}
