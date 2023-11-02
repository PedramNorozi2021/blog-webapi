namespace Blog.Core.Repositories.Posts.DTOs;

public class PostDetailDto : PostDto
{
    public List<PostCommentDto> Comments { get; set; }
}

public class PostCommentDto
{
    public string UserName { get; set; }
    public string Text { get; set; }
    public string CreateDate { get; set; }
}
